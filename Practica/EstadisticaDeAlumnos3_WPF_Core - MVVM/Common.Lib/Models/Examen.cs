using Common.Lib.Models.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Lib.Models
{
    public class Examen : Entity 
    {
        public Guid StudentID { get; set; }
        public Student Student { get; set; }
        public Guid SubjectID { get; set; }
        public Subject Subject { get; set; }
        public DateTime Date { get; set; }
        public int Mark { get; set; }

    }
}
