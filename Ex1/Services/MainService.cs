using Ex1.Entities;
using Ex1.Models;
using System;
using System.Collections.Generic;

namespace Ex1.Services
{
    interface IMainService
    {
        bool AddValue(List<string> variables);
        List<ItemEntity> GetAllOption(List<ItemEntity> mixes);
        List<ProductEntity> GetProducts();
        List<OptionEntity> GetOptions();
    }
    public class MainService : IMainService
    {
        List<ProductEntity> dataProduct;
        List<OptionEntity> dataOption;
        OptionEntity Color = new OptionEntity("S01", "Color");
        OptionEntity Size = new OptionEntity("S02", "Size");
        OptionEntity Material = new OptionEntity("S03", "Material");
        public MainService()
        {
            dataProduct = new List<ProductEntity>() { new ProductEntity("P01", "Shoes"), new ProductEntity("P02", "Shock") };
            dataOption = new List<OptionEntity>();

            Color.Values.AddRange(new ValueEntity[] { new ValueEntity("C01", "Black"), new ValueEntity("C02", "Yealow"), new ValueEntity("C01", "White") });
            Size.Values.AddRange(new ValueEntity[] { new ValueEntity("SZ01", "Small"), new ValueEntity("SZ02", "Medium"), new ValueEntity("SZ01", "Large") });
            Material.Values.AddRange(new ValueEntity[] { new ValueEntity("M01", "Polime"), new ValueEntity("M02", "Leather") });
            dataOption.AddRange(new OptionEntity[] { Color, Size, Material });
        }

        public bool AddValue(List<string> variables)
        {
            bool result = false;
            string option = Int32.Parse(variables[0]) == 1? "Color": Int32.Parse(variables[0]) == 2 ? "Size": "Material";

            foreach (var item in dataOption)
            {
                if (item.OptionName == option)
                {
                    item.Values.Add(new ValueEntity(variables[1], variables[2]));
                    result = true;
                }
            }
            return result;
        }

        public List<ItemEntity> GetAllOption(List<ItemEntity> mixes)
        {
            foreach (var product in dataProduct)
            {
                foreach (var color in Color.Values)
                {
                    foreach (var size in Size.Values)
                    {
                        foreach (var material in Material.Values)
                        {
                            string itemCode = $"{product.ProductId}-{color.ValueId}-{size.ValueId}-{material.ValueId}";
                            string itemString = $"{product.ProductName}-{color.ValueName}-{size.ValueName}-{material.ValueName}";
                            mixes.Add(new ItemEntity(itemCode, itemString));
                        }
                    }
                }
            }
            return mixes;
        }
        public List<OptionEntity> GetOptions()
        {
            return dataOption;
        }
        public List<ProductEntity> GetProducts()
        {
            return dataProduct;
        }
    }
}
