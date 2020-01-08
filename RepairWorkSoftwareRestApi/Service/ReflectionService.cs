using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RepairWorkSoftwareRestApi.Service
{
    public class ReflectionService
    {
        public List<string> GetInfoByAssembly()
        {
            List<string> infos = new List<string>();
            Assembly assembly = GetAssembly("RepairWorkSoftwareDAL");
            List<Type> interfaces = GetInterfaces(assembly);
            foreach (var inter in interfaces)
            {
                CustomAttributeData attr =
                    inter.CustomAttributes.FirstOrDefault(x => x.AttributeType.Name == "CustomInterfaceAttribute");
                if (attr != null)
                {
                    infos.Add(string.Format("Интерфейс: {0}. {1}", inter.Name, attr.ConstructorArguments[0].Value));
                    infos.AddRange(GetMethodInfos(inter));
                }
            }

            return infos;
        }

        private Assembly GetAssembly(string assemblyName)
        {
            return Assembly.Load(assemblyName);
        }

        private List<Type> GetInterfaces(Assembly assembly)
        {
            return assembly.GetTypes().Where(x => x.IsInterface).ToList();
        }

        private List<string> GetMethodInfos(Type inter)
        {
            List<string> infos = new List<string>();
            MethodInfo[] methods = inter.GetMethods();

            foreach (var method in methods)
            {
                CustomAttributeData attr = method.CustomAttributes
                    .FirstOrDefault(x => x.AttributeType.Name == "CustomMethodAttribute");
                if (attr != null)
                {
                    infos.Add(string.Format("--> Метод: {0}. {1}", method.Name, attr.ConstructorArguments[0].Value));
                }
            }

            return infos;
        }
    }
}