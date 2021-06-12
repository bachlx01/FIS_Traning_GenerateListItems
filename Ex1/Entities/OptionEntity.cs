using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1.Models
{
    public class OptionEntity
    {
        public OptionEntity(string optionId, string optionName)
        {
            OptionId = optionId;
            OptionName = optionName;
            Values = new List<ValueEntity>();
        }

        public string OptionId { get; set; }
        public string OptionName { get; set; }

        public List<ValueEntity> Values;

    }
}
