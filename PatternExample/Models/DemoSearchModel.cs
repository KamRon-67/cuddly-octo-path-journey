using System;
using PatternExample.Models.Attributes;

namespace PatternExample.Models
{
    public class DemoSearchModel
    {
        [DemoFilter(DemoFieldType.DemoName)]
        public string Name { get; set; }

        [DemoFilter(DemoFieldType.DemoDescription)]
        public string Description { get; set; }
    }
}

