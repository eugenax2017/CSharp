using Common.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Lib.Context.Interfaces
{
    public interface ISubjectsRepository : IRepository<Subject>
    {
        Subject FindByName(string name);
    }
}
