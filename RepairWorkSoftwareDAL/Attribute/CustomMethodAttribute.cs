using System;

namespace RepairWorkSoftwareDAL.Attribute
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomMethodAttribute : System.Attribute
    {
        public CustomMethodAttribute(string description)
        {
            Description = string.Format("Описание метода: ", description);
        }
        
        public string Description { get; }
    }
}