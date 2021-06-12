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
                        List<OptionEntity> dataOption = main.GetOptions();
                        ShowExitsOption(dataOption);
                        break;

                    case 2:
                        List<List<ValueEntity>> mixes1 = main.GenAllOption();
                        ShowAllOption(mixes1);
                        break;

                    case 3:
                        Dictionary<string, string> variables = getRequest();
                        bool result = main.AddValue(variables);
                        Print(result ? "Them thanh cong" : "That bai");
                        break;


                    case 4:
                        
                        break;

                }

            } while (choice != 0);
        }

        private static void ShowExitsOption(List<OptionEntity> dataOption)
        {
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

        private static void ShowAllOption(List<List<ValueEntity>> mixes)
        {
            int count = 1;
            foreach (var listValues in mixes)
            {
                string itemStr = "";
                foreach (var value in listValues)
                {
                    itemStr += value.ValueId + "; ";
                }
                itemStr += " <=> ";
                foreach (var value in listValues)
                {
                    itemStr += value.ValueName + "; ";
                }
                Print($"{count++}. {itemStr}");
            }
        }

        static Dictionary<string, string> getRequest()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            string optionId = Prompt("Option Id: ");
            string optionName = Prompt("Option Name: ");
            data.Add("optionId", optionId);
            data.Add("optionName", optionName);

            string confirm = "n";
            do
            {
                string valueId = Prompt("Value Id: ");
                string valueName = Prompt("Value Name: ");
                data.Add(valueId, valueName);
                confirm = Prompt("Tiep tuc them value(y/n): ");
            } while (confirm == "y");

            return data;
        }

        static void ShowMenu()
        {
            Print("");
            Print("************ MENU ***********");
            Print("1. Hien thi cac bien the hien tai.");
            Print("2. Hien thi tat ca cac tuy chon san pham.");
            Print("3. Them gia tri cho bien the.");
            Print("4. ...");
            Print("0. Exit.");

            Print("");
        }
    }
}
