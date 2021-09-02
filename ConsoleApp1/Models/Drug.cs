using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    class Drug
    {
        public string Name { get; set; }
        public DrugType Type { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public int Id { get; }

        public static int _id = 0;

        public Drug()
        {
            _id++;
            Id = _id;
        }
        public Drug(string name, DrugType type, int count, int price) :this()
        {
            Name = name;
            Type = type;
            Count = count;
            Price = price;
        }
        public override string ToString()
        {
            return $"Kodu:{Id} Ad:{Name} Say:{Count} Qiymet:{Price}";
        }
    }
}
