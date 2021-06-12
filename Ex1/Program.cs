using Ex1.Entities;
using Ex1.Models;
using Ex1.Services;
using System;
using System.Collections.Generic;
using static Ex1.Common.Common;


namespace Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            IMainService main = new MainService();

            int choice;

            do
            {
                ShowMenu();
                choice = Int32.Parse(Prompt("Enter your choice: "));

                switch (choice)
                {
                    case 1:
                        List<ProductEntity> dataProduct = main.GetProducts();
                        List<OptionEntity> dataOption = main.GetOptions();
                        ShowExitsOption(dataProduct, dataOption);
                        break;

                    case 2:
                        ShowAllOption(main);
                        break;

                    case 3:
                        List<string> variables = getRequest();
                        bool result = main.AddValue(variables);
                        Print(result ? "Them thanh cong" : "That bai");
                        break;
                }

            } while (choice != 0);
        }

        private static void ShowExitsOption(List<ProductEntity> dataProduct, List<OptionEntity> dataOption)
        {
            foreach (var product in dataProduct)
            {
                Print($"Product Id: { product.ProductId}; Product name: {product.ProductName}");
            }
            foreach (var option in dataOption)
            {
                string optionValue = "";
                foreach (var value in option.Values)
                {
                    optionValue += value.ValueName + ", ";
                }
                Print($"Option: {option.OptionName} => {optionValue}");
            }
        }

        private static void ShowAllOption(IMainService main)
        {
            List<ItemEntity> mixes = new List<ItemEntity>();
            mixes = main.GetAllOption(mixes);
            int count = 1;
            foreach (var mix in mixes)
            {
                Print($"{ count++ }. {mix.ItemCode} <=> {mix.ItemString}");
            }
        }

        static List<string> getRequest()
        {
            Print("1. Mau sac");
            Print("2. kich co");
            Print("3. Chat lieu");
            string option = Prompt("Chon bien the muon them gia tri: ");
            string valueId = Prompt("Nhap ma gia tri moi: ");
            string valueName = Prompt("Nhap ten gia tri moi: ");
            return new List<string>() { option, valueId, valueName};
        }

        static void ShowMenu()
        {
            Print("");
            Print("************ MENU ***********");
            Print("1. Hien thi cac bien the co san.");
            Print("2. Hien thi tat ca cac tuy chon san pham.");
            Print("3. Them gia tri cho bien the.");
            Print("0. Exit.");

            Print("");
        }
    }
}
