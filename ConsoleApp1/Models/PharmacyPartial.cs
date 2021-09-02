using ConsoleApp1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    partial class Pharmacy
    {
        public override string ToString()
        {
            return Id + " " + Name;
        }
        public bool AddDrug(Drug drug)
        {
            bool isFalse = false;
            foreach (var item in _listofdrugs)
            {
                if (drug.Name==item.Name)
                {
                    item.Count = item.Count + drug.Count;
                    isFalse = true;
                }
            }
            if (isFalse == false)
            {
                _listofdrugs.Add(drug);
            }
            return false;
        }
        public bool InfoDrug(string name)
        {
            Drug existDrug = _listofdrugs.Find(x => x.Name.ToLower() == name.ToLower());
            if (existDrug == null)
            {
                return false;
            }
            Console.WriteLine(existDrug);
            return true;
        }
        public void ShowDrugItems()
        {
            foreach (Drug drug in _listofdrugs)
            {
                Console.WriteLine(drug);
            }
        }
        public bool SaleDrug(string name, int count, int payment)
        {
            var existDrug = _listofdrugs.Find(x => x.Name.ToLower() == name.ToLower());
            if (existDrug == null)
            {
                Helper.Print(ConsoleColor.Red, "Belə bir dərman yoxdur");
                return false;
            }
            else if ( count > existDrug.Count)
            {
                Helper.Print(ConsoleColor.Red, "Yetərli qədər dərman yoxdur");
            }
            else if (payment < count * existDrug.Price) 
            {
                Helper.Print(ConsoleColor.Red, "Məbləğ çatışmır");
            }
            else if (existDrug.Count - count == 0)
            {
                var balance = payment - existDrug.Price * count;
                _listofdrugs.Remove(existDrug);
                Helper.Print(ConsoleColor.Magenta, $" Satıldı Qalıq: {balance} ");
                return true;
            }
            else
            {
                var balance = payment - existDrug.Price * count;
                existDrug.Count -= count;
                Helper.Print(ConsoleColor.Magenta, $" Satıldı Qalıq: {balance} ");
                return true;
            }
            return true;
        }
    }
}
