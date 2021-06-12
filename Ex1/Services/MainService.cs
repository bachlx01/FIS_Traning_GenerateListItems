using Ex1.Entities;
using Ex1.Models;
using System;
using System.Collections.Generic;

namespace Ex1.Services
{
    interface IMainService
    {
        bool AddValue(Dictionary<string, string> values);
        List<List<ValueEntity>> GenAllOption();
        List<OptionEntity> GetOptions();
    }
    public class MainService : IMainService
    {
        List<OptionEntity> dataOption;

        OptionEntity Product = new OptionEntity("S00", "Product");
        OptionEntity Color = new OptionEntity("S01", "Color");
        OptionEntity Size = new OptionEntity("S02", "Size");
        OptionEntity Material = new OptionEntity("S03", "Metarial");
        OptionEntity Model = new OptionEntity("S04", "Model");
        public MainService()
        {
            dataOption = new List<OptionEntity>();

            Color.Values.AddRange(new ValueEntity[] { new ValueEntity("C01", "Black"), new ValueEntity("C02", "Yealow"), new ValueEntity("C03", "White") });
            Size.Values.AddRange(new ValueEntity[] { new ValueEntity("SZ01", "Small"), new ValueEntity("SZ02", "Medium"), new ValueEntity("SZ01", "Large") });
            Material.Values.AddRange(new ValueEntity[] { new ValueEntity("M01", "Leather"), new ValueEntity("M02", "Polime"), new ValueEntity("M03", "Paper") });
            Model.Values.AddRange(new ValueEntity[] { new ValueEntity("M20", "2020"), new ValueEntity("M21", "2021") });
            Product.Values.AddRange(new ValueEntity[] { new ValueEntity("P01", "Shoes") });

            dataOption.AddRange(new OptionEntity[] { Product, Color});
        }

        public bool AddValue(Dictionary<string, string> values)
        {
            bool result = false;

            string optionId_ = "";
            string optionName_ = "";
            List<ValueEntity> listValue = new List<ValueEntity>();

            foreach (KeyValuePair<string, string> value_ in values)
            {
                if (value_.Key == "optionId")
                {
                    optionId_ = value_.Value;
                    continue;
                }
                if (value_.Key == "optionName")
                {
                    optionName_ = value_.Value;
                    continue;
                }

                listValue.Add(new ValueEntity(value_.Key, value_.Value));
            }


            OptionEntity option_ = new OptionEntity(optionId_, optionName_);

            option_.Values.AddRange(listValue);
            dataOption.Add(option_);

            result = true;
            return result;
        }

        public List<List<ValueEntity>> GenAllOption()
        {
            List<List<ValueEntity>> mixes= new List<List<ValueEntity>>();
            foreach (var option in dataOption)
            {
                mixes = addOption(mixes, option.Values);
            }
            return mixes;
        }

        List<List<ValueEntity>> addOption(List<List<ValueEntity>> mixes, List<ValueEntity> optionValues)
        {
            List<List<ValueEntity>> newMixes = new List<List<ValueEntity>>();
            if (mixes.Count == 0)
            {
                for (int j = 0; j < optionValues.Count; j++)
                {
                    List<ValueEntity> item = new List<ValueEntity>();
                    item.Add(optionValues[j]);
                    newMixes.Add(item);
                }
            }
            else
            {
                for (int i = 0; i < mixes.Count; i++)
                {
                    for (int j = 0; j < optionValues.Count; j++)
                    {
                        List<ValueEntity> item = new List<ValueEntity>();
                        item.AddRange(mixes[i]);
                        item.Add(optionValues[j]);
                        newMixes.Add(item);
                    }
                }
            }
            return newMixes;
        }
        public List<OptionEntity> GetOptions()
        {
            return dataOption;
        }

    }
}
