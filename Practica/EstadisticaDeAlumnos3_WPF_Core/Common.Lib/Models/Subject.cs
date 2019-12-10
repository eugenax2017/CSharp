using Common.Lib.Infrastructure;
using Common.Lib.Models.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Lib.Models
{
    public class Subject : Entity
    {
        public string Name { get; set; }

        public SaveResult<Subject> Save()
        {
            return base.Save<Subject>();
        }
    }
}
