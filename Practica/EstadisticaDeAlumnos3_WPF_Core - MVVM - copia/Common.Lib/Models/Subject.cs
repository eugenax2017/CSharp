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

        //Foreign key for Examen
        //public int ExamenId { get; set; }
        //public Examen Examen { get; set; }

        public SaveResult<Subject> Save()
        {
            return base.Save<Subject>();
        }   
        public SaveResult<Subject> Delete()
        {
            return base.Delete<Subject>();
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
                output.Errors.Add("el nombre de sujeto no puede estar vacío");
            }

            if (output.IsSuccess)
            {
                output.ValidatedResult = name;
            }

            return output;
        }
        public void ValidateName(ValidationResult validationResult)
        {
            var validateNameResult = ValidateName(this.Name);
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
