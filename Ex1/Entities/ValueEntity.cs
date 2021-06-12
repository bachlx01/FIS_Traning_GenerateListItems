using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1.Models
{
    public class ValueEntity
    {
        public ValueEntity(string valueId, string valueName)
        {
            ValueId = valueId;
            ValueName = valueName;
        }

        public string ValueId { get; set; }
        public string ValueName { get; set; }
    }
}
