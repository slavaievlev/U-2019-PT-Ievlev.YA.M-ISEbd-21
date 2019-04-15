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
    public class MaterialServiceDB : IMaterialService
    {
        private AbstractDbContext context;

        public MaterialServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }
        public List<MaterialViewModel> GetList()
        {
            List<MaterialViewModel> result = context.Materials.Select(rec => new MaterialViewModel
            {
                Id = rec.Id,
                MaterialName = rec.MaterialName
            }).ToList();
            return result;
        }
        public MaterialViewModel GetElement(int id)
        {
            Material element = context.Materials.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new MaterialViewModel
                {
                    Id = element.Id,
                    MaterialName = element.MaterialName
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(MaterialBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Material element = context.Materials.FirstOrDefault(rec => rec.MaterialName == model.MaterialName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть материал с таким названием");
                    }
                    element = new Material
                    {
                        MaterialName = model.MaterialName
                    };
                    context.Materials.Add(element);
                    context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void UpdElement(MaterialBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Material element = context.Materials.FirstOrDefault(rec =>
                        rec.MaterialName == model.MaterialName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть материал с таким названием");
                    }
                    element = context.Materials.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.MaterialName = model.MaterialName;
                    context.SaveChanges();

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
                    Material element = context.Materials.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        context.WorkMaterials.RemoveRange(context.WorkMaterials.Where(rec =>
                            rec.MaterialId == id));
                        context.Materials.Remove(element);
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
