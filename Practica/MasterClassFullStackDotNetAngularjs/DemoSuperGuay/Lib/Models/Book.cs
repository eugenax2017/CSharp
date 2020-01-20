using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoSuperGuay.Lib.Models
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Edition { get; set; }
        public int Year { get; set; }

        public int Quantity { get; set; }

        public List<Lend> Lends { get; set; }
    }
}
