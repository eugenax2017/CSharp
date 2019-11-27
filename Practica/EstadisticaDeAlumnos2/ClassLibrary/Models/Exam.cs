using System;

namespace ClassLibrary.Models
{
    public class Exam
    {
        public DateTime DateStamp { get; set; }

        public Student Student { get; set; }

        public Subject Subject { get; set; }    

        public double Nota { get; set; }
    }
   
}
