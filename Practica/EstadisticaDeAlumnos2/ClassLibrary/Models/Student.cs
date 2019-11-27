using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Models
{
    public class Student
    {
        public string Dni { get; set; }

        public string Name { get; set; }

        public List<double> Marks { get; set; }
    }
}
