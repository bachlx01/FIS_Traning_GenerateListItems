using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1.Models
{
    public class ProductEntity
    {
        public ProductEntity(string id, string productName)
        {
            ProductId = id;
            ProductName = productName;
        }

        public string ProductId { get; set; }
        public string ProductName { get; set; }

    }
}
