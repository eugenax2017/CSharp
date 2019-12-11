using Common.Lib.Infrastructure;
using Common.Lib.Models.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Lib.Models
{
    public class Student : Entity
    {
        public string Name { get; set; }

        public string Dni { get; set; }

        public SaveResult<Student> Save()
        {
            return base.Save<Student>();
        }

        public SaveResult<Student> Delete()
        {
            return base.Delete<Student>();
        }
    }
}
