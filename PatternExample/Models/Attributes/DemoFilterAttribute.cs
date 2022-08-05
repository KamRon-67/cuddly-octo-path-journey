using System;
namespace PatternExample.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DemoFilterAttribute : Attribute
    {
        public DemoFieldType _fieldType { get; set; }

        public DemoFilterAttribute(DemoFieldType fieldType)
        {
            _fieldType = fieldType;
        }
    }
}

