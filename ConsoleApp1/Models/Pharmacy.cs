using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    partial class Pharmacy
    {
        public string Name { get; set; }
        public int Id { get; }
        public static int _id = 0;
        public List<Drug> _listofdrugs;
        public Pharmacy()
        {
            _id++;
            Id = _id;
            _listofdrugs = new List<Drug>();
        }
        public Pharmacy(string name) :this()
        {
            Name = name;
        }
    }
}
