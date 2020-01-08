using System;

namespace RepairWorkSoftwareDAL.Attribute
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class CustomInterfaceAttribute : System.Attribute
    {
        public CustomInterfaceAttribute(string description)
        {
            Description = string.Format("Описание интерфейса: ", description);
        }
        
        public string Description { get; }
    }
}