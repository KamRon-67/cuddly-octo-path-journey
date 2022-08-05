using System;
using PatternExample.Models.Attributes;
using PatternExample.Models;

namespace PatternExample.Database
{
    internal class DemoExpressions
    {
        internal static IDictionary<DemoFieldType, Func<IQueryable<DataFromDBCall>, DemoSearchModel, IQueryable<DataFromDBCall>>>
            Filter = new Dictionary<DemoFieldType, Func<IQueryable<DataFromDBCall>, DemoSearchModel, IQueryable<DataFromDBCall>>>
            {
                { DemoFieldType.DemoName, (q, m) => {return q.Where(o => o.Name.ToLower().Contains(m.Name.ToLower())); } },
                { DemoFieldType.DemoDescription, (q, m) => {return q.Where(o => o.Description.ToLower().Contains(m.Description.ToLower())); } }

            };
    }
}

