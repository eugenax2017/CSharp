using Common.Lib.Core;
using Common.Lib.Core.Context;
using Common.Lib.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Lib.Models
{
    public class Exam : Entity
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

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

        public Guid SubjectId { get; set; }

        public Exam()
        {

        }

        public SaveResult<Exam> Save()
        {
            return base.Save<Exam>();
        }
        public DeleteResult<Exam> Delete()
        {
            return base.Delete<Exam>();
        }

        public static ValidationResult<string> ValidateName(string name)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(name))
            {
                output.IsSuccess = false;
                output.Errors.Add("el title del exam no puede estar vacío");
            }

            if (output.IsSuccess)
            {
                output.ValidatedResult = name;
            }

            return output;
        }
        public void ValidateName(ValidationResult validationResult)
        {
            var validateNameResult = ValidateName(this.Title);
            if (!validateNameResult.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(validateNameResult.Errors);
            }
        }
        public override ValidationResult Validate()
        {
            var output = base.Validate();

            // cambiar ValidateName para que sea igual que ValidateDni
            ValidateName(output);
            return output;
        }
    }
}
