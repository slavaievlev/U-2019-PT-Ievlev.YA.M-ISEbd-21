using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.Interface;
using RepairWorkSoftwareDAL.ViewModel;
using RepairWorkSoftwareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementsDatabase.Implementations
{
    public class WorkServiceDB : IWorkService
    {
        private AbstractDbContext context;

        public WorkServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }
        public List<WorkViewModel> GetList()
        {
            List<WorkViewModel> result = context.Works.Select(rec => new WorkViewModel
            {
                Id = rec.Id,
                WorkName = rec.WorkName,
                Price = rec.Price,
                WorkMaterials = context.WorkMaterials
                .Where(recPC => recPC.WorkId == rec.Id)
                   .Select(recPC => new WorkMaterialViewModel
                   {
                       Id = recPC.Id,
                       WorkId = recPC.WorkId,
                       MaterialId = recPC.MaterialId,
                       MaterialName = recPC.Material.MaterialName,
                       Count = recPC.Count
                   })
               .ToList()
                })
                .ToList();
            return result;
        }
        public WorkViewModel GetElement(int id)
        {
            Work element = context.Works.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new WorkViewModel
            {
                    Id = element.Id,
                    WorkName = element.WorkName,
                    Price = element.Price,
                    WorkMaterials = context.WorkMaterials
                     .Where(recPC => recPC.WorkId == element.Id)
                     .Select(recPC => new WorkMaterialViewModel
                     {
                         Id = recPC.Id,
                         WorkId = recPC.WorkId,
                         MaterialId = recPC.MaterialId,
                         MaterialName = recPC.Material.MaterialName,
                         Count = recPC.Count
                     })
                     .ToList()
                     };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(WorkBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Work element = context.Works.FirstOrDefault(rec => rec.WorkName == model.WorkName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = new Work
                    {
                        WorkName = model.WorkName,
                        Price = model.Price
                    };
                    context.Works.Add(element);
                    context.SaveChanges();

                    var groupComponents = model.WorkMaterials
                     .GroupBy(rec => rec.MaterialId)
                    .Select(rec => new
                    {
                        MaterialId = rec.Key,
                        Count = rec.Sum(r => r.Count)
                    });

                    foreach (var groupComponent in groupComponents)
                    {
                        context.WorkMaterials.Add(new MaterialWork
                        {
                            WorkId = element.Id,
                            MaterialId = groupComponent.MaterialId,
                            Count = groupComponent.Count
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void UpdElement(WorkBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Work element = context.Works.FirstOrDefault(rec =>
                   rec.WorkName == model.WorkName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = context.Works.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.WorkName = model.WorkName;
                    element.Price = model.Price;
                    context.SaveChanges();

                    var compIds = model.WorkMaterials.Select(rec => rec.MaterialId).Distinct();
                    var updateComponents = context.WorkMaterials.Where(rec => rec.WorkId == model.Id && compIds.Contains(rec.MaterialId));
                    foreach (var updateComponent in updateComponents)
                    {
                        updateComponent.Count = model.WorkMaterials.FirstOrDefault(rec => rec.Id == updateComponent.Id).Count;
                    }
                    context.SaveChanges();
                    context.WorkMaterials.RemoveRange(context.WorkMaterials.Where(rec =>
                    rec.WorkId == model.Id && !compIds.Contains(rec.MaterialId)));
                    context.SaveChanges();

                    var groupComponents = model.WorkMaterials
                    .Where(rec => rec.Id == 0)
                   .GroupBy(rec => rec.MaterialId)
                   .Select(rec => new
                   {
                       MaterialId = rec.Key,
                       Count = rec.Sum(r => r.Count)
                   });
                    foreach (var groupComponent in groupComponents)
                    {
                        MaterialWork elementPC = context.WorkMaterials.FirstOrDefault(rec => rec.WorkId == model.Id &&
                            rec.MaterialId == groupComponent.MaterialId);
                        if (elementPC != null)
                        {
                            elementPC.Count += groupComponent.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.WorkMaterials.Add(new MaterialWork
                            {
                                WorkId = model.Id,
                                MaterialId = groupComponent.MaterialId,
                                Count = groupComponent.Count
                            });
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Work element = context.Works.FirstOrDefault(rec => rec.Id ==
                   id);
                    if (element != null)
                    {
                        context.WorkMaterials.RemoveRange(context.WorkMaterials.Where(rec =>
                        rec.WorkId == id));
                        context.Works.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
