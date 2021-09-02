using ConsoleApp1.Models;
using ConsoleApp1.Utils;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<Pharmacy> _pharmacies = new List<Pharmacy>();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Seçim edin");
                Console.WriteLine("1. Aptek yaradın");
                Console.WriteLine("2. Dərman əlavə edin");
                Console.WriteLine("3. Dərman haqqında məlumat");
                Console.WriteLine("4. Dərmanların siyahısını gostər");
                Console.WriteLine("5  Dərmanların satışı");
                Console.WriteLine("6. Çıxış");
                Console.ResetColor();
                string input = Console.ReadLine();
                bool isInt = int.TryParse(input, out int choice);
                if (isInt && (choice > 0 && choice < 7))
                {
                    if (choice==6)
                    {
                        break;
                    }
                    switch (choice)
                    {
                        case 1:

                            Helper.Print(ConsoleColor.Cyan,"Aptekin adını yaradın");
                            string nameOfPharmacy = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(nameOfPharmacy))
                            {
                                Helper.Print(ConsoleColor.Red, "Adı düzgün daxil edin!");
                                return;
                            }
                            bool isExistPharmacy = _pharmacies.Exists(x => x.Name.ToLower() == nameOfPharmacy.ToLower());
                            if (isExistPharmacy)
                            {
                                Helper.Print(ConsoleColor.Red,"Bu adda aptek var");
                                goto case 1;
                            }
                            Pharmacy pharmacy = new Pharmacy(nameOfPharmacy);
                            _pharmacies.Add(pharmacy);
                            Helper.Print(ConsoleColor.Yellow, nameOfPharmacy + " " + "adda aptek yarandı");
                            break;
                        case 2:

                            choicePharmacy:
                            Helper.Print(ConsoleColor.Cyan, "Dərmanı əlavə edəcəyiniz apteki seçin");
                            foreach (var item in _pharmacies)
                            {
                                Console.WriteLine(item);
                            }
                            input = Console.ReadLine();
                            isInt = int.TryParse(input, out int idOfPharmacy);
                            Pharmacy isChoiceExistPharmacy = _pharmacies.Find(x => x.Id == idOfPharmacy);
                            if (isChoiceExistPharmacy == null)
                            {
                                Helper.Print(ConsoleColor.Red,"Belə aptek yoxdur");
                                goto choicePharmacy;
                            }
                            nameOfDrug:
                            Helper.Print(ConsoleColor.Cyan, "Dərman adını daxil edin");
                            string nameOfDrug = Console.ReadLine();
                            var selectedName = int.TryParse(nameOfDrug, out int chooseName);
                            if (selectedName)
                            {
                                Helper.Print(ConsoleColor.Red, "Zəhmət olmasa ad yazin");
                                goto nameOfDrug;
                            }
                            count: 
                            Helper.Print(ConsoleColor.Cyan,"Dərmanın sayını daxil edin");
                            input = Console.ReadLine();
                            isInt = int.TryParse(input, out int countOfDrug);
                            if (!isInt)
                            {
                                Helper.Print(ConsoleColor.Red, "Rəqəm daxil edin");
                                goto count;
                            }
                            price:
                            Helper.Print(ConsoleColor.Cyan, "Qiyməti təyin edin");
                            input = Console.ReadLine();
                            isInt = int.TryParse(input, out int priceOfDrug);
                            if (!isInt)
                            {
                                Helper.Print(ConsoleColor.Red, "Rəqəm daxil edin");
                                goto price;
                            }
                            typeOfDrug:
                            Helper.Print(ConsoleColor.Cyan, "Dərmanın növünü daxil edin");
                            var typeOfDrugSelect = Console.ReadLine();
                            var selectedType = int.TryParse(typeOfDrugSelect, out int chooseType);
                            if (selectedType)
                            {
                                Helper.Print(ConsoleColor.Red, "Rəqəm daxil etmək olmaz!");
                                goto typeOfDrug;
                            }
                            DrugType typeOfDrug = new DrugType(typeOfDrugSelect);
                            Drug drug = new Drug(nameOfDrug, typeOfDrug, countOfDrug, priceOfDrug);
                            isChoiceExistPharmacy.AddDrug(drug);
                            Helper.Print(ConsoleColor.Magenta, "Bu dərman aptekə əlavə edildi");
                            break;
                        case 3:

                            Helper.Print(ConsoleColor.Cyan, "Hansı aptekdəki dərmanı axtarırsınız?");
                            foreach (var item in _pharmacies)
                            {
                                Console.WriteLine(item);
                            }
                            input = Console.ReadLine();
                            isInt = int.TryParse(input, out int idOfDrugstore);
                            Pharmacy isChoiceExistDrugstore = _pharmacies.Find(x => x.Id == idOfDrugstore);
                            if (isChoiceExistDrugstore == null)
                            {
                                Helper.Print(ConsoleColor.Red, "Belə aptek yoxdur");
                                goto case 3;
                            }
                            Helper.Print(ConsoleColor.Cyan, "Axdardığınız dərmanın adını daxil edin");
                            string searchName = Console.ReadLine();
                                if (isChoiceExistDrugstore.InfoDrug(searchName) == false)
                                {
                                    Helper.Print(ConsoleColor.Red, "Aptekdə bu dərman yoxdur");
                                }
                            break;
                        case 4:

                            Helper.Print(ConsoleColor.Cyan, "Hansı aptekin dərmanlari lazımdır?");
                            foreach (var item in _pharmacies)
                            {
                                Console.WriteLine(item);
                            }
                            input = Console.ReadLine();
                            isInt = int.TryParse(input, out int idOfDrugList);
                            Pharmacy isChoiceExistDrugList = _pharmacies.Find(x => x.Id == idOfDrugList);
                            if (isChoiceExistDrugList == null)
                            {
                                Helper.Print(ConsoleColor.Red, "Belə aptek yoxdur");
                                goto case 4;
                            }
                            isChoiceExistDrugList.ShowDrugItems();
                            break;
                        case 5:

                            Helper.Print(ConsoleColor.Cyan, "Hansı aptekdən dərman almaq istəyirsiniz?");
                            foreach (var item in _pharmacies)
                            {
                                Console.WriteLine(item);
                            }
                            input = Console.ReadLine();
                            isInt = int.TryParse(input, out int idOfMyChoice);
                            Pharmacy isMyChoiceExist = _pharmacies.Find(x => x.Id == idOfMyChoice);
                            if (isMyChoiceExist == null)
                            {
                                Helper.Print(ConsoleColor.Red, "Belə aptek yoxdur");
                                goto case 5;
                            }
                            selectNameOfDrug:
                            Helper.Print(ConsoleColor.Cyan, "Almaq istədiyiniz dərmanin adını daxil edin");
                            string nameOfSale =Console.ReadLine(); 
                            var nameOfSaleNumber = int.TryParse(nameOfSale, out int result3);
                            if (string.IsNullOrWhiteSpace(nameOfSale))
                            {
                                Helper.Print(ConsoleColor.Red, "Düzgün yazın");
                                goto selectNameOfDrug;
                            }
                            if (nameOfSaleNumber)
                            {
                                Helper.Print(ConsoleColor.Red,"Düzgün daxil edin");
                                goto selectNameOfDrug;
                            }
                            Helper.Print(ConsoleColor.Cyan,"Dərmanın sayını yazın");
                            selectCount:
                            string countDrug = Console.ReadLine();
                            isInt = int.TryParse(countDrug, out int result);
                            if (!isInt)
                            {
                                Helper.Print(ConsoleColor.Red, "Düzgün yazın");
                                goto selectCount;
                            }
                            selectPayment:
                            Helper.Print(ConsoleColor.Cyan, "Kassaya ödəniş edin");
                            string nameOfSum = Console.ReadLine();
                            isInt = int.TryParse(nameOfSum, out int result1);
                            if (!isInt)
                            {
                                Helper.Print(ConsoleColor.Red, "Düzgün yazın");
                                goto selectPayment;
                            }
                            var saleDrugTrue=isMyChoiceExist.SaleDrug(nameOfSale, result, result1);
                            if (!saleDrugTrue)
                            {
                                goto case 5;
                            }                           
                            break;
                    }
                }
                else
                {
                    Helper.Print(ConsoleColor.Red,"Aşağıdakı ədədlərdən seçin: 1 2 3 4 5 6");
                }
            }
        }
    }
}
