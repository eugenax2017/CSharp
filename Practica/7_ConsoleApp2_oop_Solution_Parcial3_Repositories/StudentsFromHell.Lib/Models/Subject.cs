using Academy.Lib.Context;
using Academy.Lib.Infrastructure;
using System;

namespace Academy.Lib.Models
{
    public class Subject : Entity
    {
        public string Name { get; set; }

        public Guid Guid { get; private set; }
        
        public void ValidateName(ValidationResult validationResult)
        {
            validationResult.IsSuccess = true;

            if (string.IsNullOrEmpty(this.Name))
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.Add("el nombre de la asignatura no puede estar vacío");
            }

            if (SubjectRepository.SubjectsByName.ContainsKey(this.Name))
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.Add($"Ya existe una asignatura que se llama {this.Name}");
            }           
        }

        public override ValidationResult Validate()
        {
            var validationResult = new ValidationResult
            {
                IsSuccess = true
            };

            ValidateName(validationResult);

            return validationResult;
        }

        public SaveResult<Subject> SaveSubject()
        {
            var saveResult = base.Save<Subject>();
            return saveResult.Cast<Subject>();
        }

        public SaveResult<Subject> Save()
        {
            var saveResult = base.Save<Subject>();
            return saveResult;
        }
    }
}
