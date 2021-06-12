using Ex1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1.Entities
{
    public class ItemEntity
    {
        public ItemEntity(string itemCode, string itemString)
        {
            ItemCode = itemCode;
            ItemString = itemString;
        }

        public string ItemCode { get; set; }
        public string ItemString { get; set; }
    }
}
