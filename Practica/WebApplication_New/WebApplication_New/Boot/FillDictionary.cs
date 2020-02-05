using Academy.Lib.Models;
using Common.Lib.Core;
using Common.Lib.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_New.Boot
{
    public class FillDictionary
    {
        public FillDictionary()
        {
            var repo = Entity.DepCon.Resolve<IRepository<Student>>();
            var count = repo.QueryAll().ToList().Count();
            if (count == 0)
            {
                Student newStudent = new Student { Name = "Eugene", Email = "eugene", Dni = "5455", ChairNumber = 5 };
                newStudent.Save();
                Student newStudent2 = new Student { Name = "Marta", Email = "marta", Dni = "4456", ChairNumber = 6 };
                newStudent2.Save();
                Student newStudent3 = new Student { Name = "Lucy", Email = "lucy", Dni = "3456", ChairNumber = 7 };
                newStudent3.Save();
            }
            if (count > 3)
            {
                var students = repo.QueryAll().ToList();
                for (var i=3; i<students.Count(); i++)
                {
                    students[i].Delete();
                }
            }
        }
        
    }
}
