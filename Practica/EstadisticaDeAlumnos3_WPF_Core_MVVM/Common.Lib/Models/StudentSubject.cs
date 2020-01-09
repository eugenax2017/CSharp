using Common.Lib.Infrastructure;
using Common.Lib.Models.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Lib.Models
{
    public class StudentSubject : Entity
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public SaveResult<StudentSubject> Save()
        {
            return base.Save<StudentSubject>();
        }
        public SaveResult<StudentSubject> Delete()
        {
            return base.Delete<StudentSubject>();
        }

    }
}
