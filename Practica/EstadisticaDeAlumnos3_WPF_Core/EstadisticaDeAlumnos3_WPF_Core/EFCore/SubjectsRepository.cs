using Common.Lib.Context.Interfaces;
using Common.Lib.Infrastructure;
using Common.Lib.Models;
using EstadisticaDeAlumnos3_WPF_Core.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstadisticaDeAlumnos3_WPF_Core.EFCore
{
    public class SubjectsRepository : GenericRepository<Subject>, ISubjectsRepository
    {
        private static Dictionary<string, Subject> SubjectsByName { get; set; }

        public SubjectsRepository(ProjectDbContext dbContext)
            : base(dbContext)
        {
            if (SubjectsByName == null)
            {
                SubjectsByName = new Dictionary<string, Subject>();

                foreach (var subject in dbContext.Subjects)
                    SubjectsByName.Add(subject.Name, subject);

            }
        }

        public override SaveResult<Subject> Add(Subject entity)
        {
            var output = base.Add(entity);

            if (output.IsSuccess)
            {
                SubjectsByName.Add(entity.Name, entity);
            }

            return output;
        }

        public Subject FindByName(string name)
        {
            return SubjectsByName[name];
        }

        public SaveResult<Subject> Update(Subject entity)
        {
            throw new NotImplementedException();
        }
    }
}
