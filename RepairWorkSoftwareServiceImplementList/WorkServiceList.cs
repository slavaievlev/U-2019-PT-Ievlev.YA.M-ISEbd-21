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
            int maxId = 0;
            for (int i = 0; i < source.Works.Count; i++)
            {
                if (source.Works[i].Id > maxId)
                {
                    maxId = source.Works[i].Id;
                }

                if (source.Works[i].WorkName.Equals(model.WorkName))
                {
                    throw new Exception("Уже есть услуга с таким названием");
                }
            }

            source.Works.Add(new Work
            {
                Id = maxId + 1,
                WorkName = model.WorkName,
                Price = model.Price
            });

            int maxMWId = 0;
            for (int i = 0; i < source.WorkMaterials.Count; i++)
            {
                if (source.WorkMaterials[i].Id > maxMWId)
                {
                    maxMWId = source.WorkMaterials[i].Id;
                }
            }

            for (int i = 0; i < model.WorkMaterials.Count; i++)
            {
                for (int j = i + 1; j < model.WorkMaterials.Count; j++)
                {
                    if (model.WorkMaterials[i].MaterialId == model.WorkMaterials[j].MaterialId)
                    {
                        model.WorkMaterials[i].Count += model.WorkMaterials[j].Count;
                        model.WorkMaterials.RemoveAt(j--);
                    }
                }
            }

            for (int i = 0; i < model.WorkMaterials.Count; i++)
            {
                source.WorkMaterials.Add(new MaterialWork
                {
                    Id = ++maxMWId,
                    WorkId = maxId + 1,
                    MaterialId = model.WorkMaterials[i].MaterialId,
                    Count = model.WorkMaterials[i].Count
                });
            }
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.WorkMaterials.Count; i++)
            {
                if (source.WorkMaterials[i].WorkId == id)
                {
                    source.WorkMaterials.RemoveAt(i--);
                }
            }

            for (int i = 0; i < source.Works.Count; i++)
            {
                if (source.Works[i].Id == id)
                {
                    source.Works.RemoveAt(i);
                    return;
                }
            }

            throw new Exception("Элемент не найден");
        }

        public WorkViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Works.Count; i++)
            {
                if (source.Works[i].Id == id)
                {
                    return new WorkViewModel
                    {
                        Id = source.Works[i].Id,
                        WorkName = source.Works[i].WorkName,
                        Price = Convert.ToString(source.Works[i].Price),
                        WorkMaterials = GetWorkMaterials(i)
                    };
                }
            }

            throw new Exception("Элемент не найден");
        }

        public List<WorkViewModel> GetList()
        {
            List<WorkViewModel> result = new List<WorkViewModel>();
            for (int i = 0; i < source.Works.Count; i++)
            {
                result.Add(new WorkViewModel
                {
                    Id = source.Works[i].Id,
                    WorkName = source.Works[i].WorkName,
                    Price = Convert.ToString(source.Works[i].Price),
                    WorkMaterials = GetWorkMaterials(i)
                });
            }
            return result;
        }

        private List<MaterialWorkViewModel> GetWorkMaterials(int workIndex)
        {
            List<MaterialWorkViewModel> workMaterials = new List<MaterialWorkViewModel>();
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
                    workMaterials.Add(new MaterialWorkViewModel
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
            int index = -1;
            for (int i = 0; i < source.Works.Count; i++)
            {
                if (source.Works[i].Id == model.Id)
                {
                    index = i;
                }

                if (source.Works[i].WorkName == model.WorkName &&
                    source.Works[i].Id != model.Id)
                {
                    throw new Exception("Уже есть услуга с таким названием");
                }
            }

            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }

            source.Works[index].WorkName = model.WorkName;
            source.Works[index].Price = model.Price;

            int maxWMId = 0;
            for (int i = 0; i < source.WorkMaterials.Count; i++)
            {
                if (source.WorkMaterials[i].Id > maxWMId)
                {
                    maxWMId = source.WorkMaterials[i].Id;
                }
            }

            for (int i = 0; i < source.WorkMaterials.Count; i++)
            {
                if (source.WorkMaterials[i].WorkId == model.Id)
                {
                    bool flag = true;
                    for (int j = 0; j < model.WorkMaterials.Count; j++)
                    {
                        if (source.WorkMaterials[i].Id == model.WorkMaterials[j].Id)
                        {
                            source.WorkMaterials[i].Count = model.WorkMaterials[j].Count;
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        source.WorkMaterials.RemoveAt(i--);
                    }
                }
            }

            for (int i = 0; i < model.WorkMaterials.Count; i++)
            {
                if (model.WorkMaterials[i].Id == 0)
                {
                    for (int j = 0; j < source.WorkMaterials.Count; j++)
                    {
                        if (source.WorkMaterials[j].WorkId == model.Id &&
                            source.WorkMaterials[j].MaterialId == model.WorkMaterials[i].MaterialId)
                        {
                            source.WorkMaterials[j].Count += model.WorkMaterials[i].Count;
                            model.WorkMaterials[i].Id = source.WorkMaterials[j].Id;
                            break;
                        }
                    }

                    if (model.WorkMaterials[i].Id == 0)
                    {
                        source.WorkMaterials.Add(new MaterialWork
                        {
                            Id = ++maxWMId,
                            WorkId = model.Id,
                            MaterialId = model.WorkMaterials[i].MaterialId,
                            Count = model.WorkMaterials[i].Count
                        });
                    }
                }
            }
        }
    }
}
