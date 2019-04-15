using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.Interface;
using RepairWorkSoftwareDAL.ViewModel;
using RepairWorkSoftwareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareServiceImplementList
{
    public class WorkServiceList : IWorkService
    {
        private DataListSingleton source;

        public WorkServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public void AddElement(WorkBindingModel model)
        {
            Work element = source.Works.FirstOrDefault(rec => rec.WorkName == model.WorkName);
            if (element != null)
            {
                throw new Exception("Уже есть услуга с таким названием");
            }
            int maxId = source.Works.Count > 0 ? source.Works.Max(rec => rec.Id) : 0;
            source.Works.Add(new Work
            {
                Id = maxId + 1,
                WorkName = model.WorkName,
                Price = model.Price
            });

            int maxPCId = source.WorkMaterials.Count > 0 ? source.WorkMaterials.Max(rec => rec.Id) : 0;

            var groupComponents = model.WorkMaterials
            .GroupBy(rec => rec.MaterialId)
            .Select(rec => new
            {
                ComponentId = rec.Key,
                Count = rec.Sum(r => r.Count)
            });

            foreach (var groupComponent in groupComponents)
            {
                source.WorkMaterials.Add(new MaterialWork
                {
                    Id = ++maxPCId,
                    WorkId = maxId + 1,
                    MaterialId = groupComponent.ComponentId,
                    Count = groupComponent.Count
                });
            }
        }

        public void DelElement(int id)
        {
            Work element = source.Works.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                source.WorkMaterials.RemoveAll(rec => rec.WorkId == id);
                source.Works.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public WorkViewModel GetElement(int id)
        {
            Work element = source.Works.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new WorkViewModel
                {
                    Id = element.Id,
                    WorkName = element.WorkName,
                    Price = element.Price,
                    WorkMaterials = source.WorkMaterials
                .Where(recPC => recPC.WorkId == element.Id)
                .Select(recPC => new WorkMaterialViewModel
                {
                    Id = recPC.Id,
                    WorkId = recPC.WorkId,
                    MaterialId = recPC.MaterialId,
                    MaterialName = source.Materials.FirstOrDefault(recC =>
                        recC.Id == recPC.MaterialId)?.MaterialName,
                    Count = recPC.Count
                })
               .ToList()
                };
            }
            throw new Exception("Элемент не найден");

        }

        public List<WorkViewModel> GetList()
        {
            List<WorkViewModel> result = source.Works.Select(rec => new WorkViewModel
            {
                Id = rec.Id,
                WorkName = rec.WorkName,
                Price = rec.Price,
                WorkMaterials = source.WorkMaterials
                    .Where(recWM => recWM.WorkId == rec.Id)
                    .Select(recWM => new WorkMaterialViewModel
                    {
                        Id = recWM.Id,
                        WorkId = recWM.WorkId,
                        MaterialId = recWM.MaterialId,
                        MaterialName = source.Materials.FirstOrDefault(recM => recM.Id == recWM.MaterialId)?.MaterialName,
                        Count = recWM.Count
                    }).ToList()
            }).ToList();
            return result;
        }

        private List<WorkMaterialViewModel> GetWorkMaterials(int workIndex)
        {
            List<WorkMaterialViewModel> workMaterials = new List<WorkMaterialViewModel>();
            for (int j = 0; j < source.WorkMaterials.Count; j++)
            {
                if (source.WorkMaterials[j].WorkId == source.Works[workIndex].Id)
                {
                    string materialName = string.Empty;
                    for (int k = 0; k < source.Materials.Count; k++)
                    {
                        if (source.WorkMaterials[j].MaterialId == source.Materials[k].Id)
                        {
                            materialName = source.Materials[k].MaterialName;
                            break;
                        }
                    }
                    workMaterials.Add(new WorkMaterialViewModel
                    {
                        Id = source.WorkMaterials[j].Id,
                        WorkId = source.WorkMaterials[j].WorkId,
                        MaterialId = source.WorkMaterials[j].MaterialId,
                        MaterialName = materialName,
                        Count = source.WorkMaterials[j].Count
                    });
                }
            }
            return workMaterials;
        }

        public void UpdElement(WorkBindingModel model)
        {
            Work element = source.Works.FirstOrDefault(rec => rec.WorkName ==
                model.WorkName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            element = source.Works.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.WorkName = model.WorkName;
            element.Price = model.Price;
            int maxPCId = source.WorkMaterials.Count > 0 ?
                source.WorkMaterials.Max(rec => rec.Id) : 0;

            var compIds = model.WorkMaterials.Select(rec =>
                rec.MaterialId).Distinct();
            var updateComponents = source.WorkMaterials.Where(rec => rec.WorkId ==
                model.Id && compIds.Contains(rec.MaterialId));
            foreach (var updateComponent in updateComponents)
            {
                updateComponent.Count = model.WorkMaterials.FirstOrDefault(rec =>
               rec.Id == updateComponent.Id).Count;
            }
            source.WorkMaterials.RemoveAll(rec => rec.WorkId == model.Id && !compIds.Contains(rec.MaterialId));

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
                MaterialWork elementPC = source.WorkMaterials.FirstOrDefault(rec => 
                    rec.WorkId == model.Id && rec.MaterialId == groupComponent.MaterialId);
                if (elementPC != null)
                {
                    elementPC.Count += groupComponent.Count;
                }
                else
                {
                    source.WorkMaterials.Add(new MaterialWork
                    {
                        Id = ++maxPCId,
                        WorkId = model.Id,
                        MaterialId = groupComponent.MaterialId,
                        Count = groupComponent.Count
                    });
                }
            }
        }
    }
}
