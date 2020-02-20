using Common.Lib.Core;
using Common.Lib.Core.Context;
using Common.Lib.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Lib.Models
{
    public class Subject : Entity
    {
        public string Name { get; set; }
        public string Teacher { get; set; }

        public Subject()
        {

        }
        public SaveResult<Subject> Save()
        {
            return base.Save<Subject>();
        }
        public DeleteResult<Subject> Delete()
        {
            return base.Delete<Subject>();
        }

        public static ValidationResult<string> ValidateName(string name, Guid currentId = default, bool dublicate = true)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(name))
            {
                output.IsSuccess = false;
                output.Errors.Add("el nombre de sujeto no puede estar vacío");
            }

            var repoSubjects = Entity.DepCon.Resolve<IRepository<Subject>>();

            var subjectByName = repoSubjects.QueryAll().FirstOrDefault(s => s.Name == name);

            if (currentId == default)
            {
                if (subjectByName != null) //save new element
                {
                    output.IsSuccess = false;
                    output.Errors.Add($"ya hay un subject {subjectByName.Name}");
                }
            }
            else if (subjectByName.Id != currentId) //update
            {
                output.IsSuccess = false;
                output.Errors.Add($"ya hay un subject {subjectByName.Name}");
            }

            if (output.IsSuccess)
            {
                output.ValidatedResult = name;
            }

            return output;
        }
        public void ValidateName(ValidationResult validationResult)
        {
            var validateNameResult = ValidateName(this.Name, this.Id);
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
