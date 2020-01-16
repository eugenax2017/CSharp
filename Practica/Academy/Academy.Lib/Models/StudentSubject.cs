using Common.Lib.Core;
using Common.Lib.Core.Context;
using Common.Lib.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Lib.Models
{
    public class StudentSubject : Entity
    {
        public Guid StudentId { get; set; }

        private Student student;
        public Student Student
        {
            get
            {
                var repo = Entity.DepCon.Resolve<IRepository<Student>>();
                return repo.QueryAll().Where(x => x.Id == this.StudentId).FirstOrDefault();

            }
            set
            {
                student = value;
            }
        }
        public Guid SubjectId { get; set; }

        private Subject subject;
        public Subject Subject
        {
            get
            {
                var repo = Entity.DepCon.Resolve<IRepository<Subject>>();
                return repo.QueryAll().Where(x => x.Id == this.SubjectId).FirstOrDefault();

            }
            set
            {
                subject = value;
            }
        }

        public SaveResult<StudentSubject> Save()
        {
            return base.Save<StudentSubject>();
        }
        public DeleteResult<StudentSubject> Delete()
        {
            return base.Delete<StudentSubject>();
        }
    }
}
