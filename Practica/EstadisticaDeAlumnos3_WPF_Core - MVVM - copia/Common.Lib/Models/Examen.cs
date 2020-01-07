using Common.Lib.Models.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Lib.Models
{
    public class Examen : Entity
    {
        public ICollection<Student> Students { get; set; }

        public ICollection<Subject> Subject { get; set; }

        public int Mark { get; set; }

    }
}
