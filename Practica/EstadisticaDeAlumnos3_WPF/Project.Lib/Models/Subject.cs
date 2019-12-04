﻿using Common.Lib.Core;
using Common.Lib.Infrastructure;

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
