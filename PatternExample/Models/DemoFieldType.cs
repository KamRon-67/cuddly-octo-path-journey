using System;
using System.ComponentModel;

namespace PatternExample.Models
{
    public enum DemoFieldType
    {
        [Description("DEMO_NAME")]
        DemoName,
        [Description("DEMO_DESCRIPTION")]
        DemoDescription
    }
}

