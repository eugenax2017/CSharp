using Common.Lib.Core;
using Common.Lib.Infrastructure;
using System;

namespace Academy.Lib.Models
{
    public class StudentExam : Entity
    {
        public Exam Exam { get; set; }
        public Guid ExamId { get; set; }

        public Student Student { get; set; }
        public Guid StudentId { get; set; }

        public double Mark { get; set; }

        public bool HasCheated { get; set; }

        public StudentExam()
        {

        }
        public SaveResult<StudentExam> Save()
        {
            return base.Save<StudentExam>();
        }
        public DeleteResult<StudentExam> Delete()
        {
            return base.Delete<StudentExam>();
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
                output.Errors.Add("el nombre del examen no puede estar vacío");
            }

            if (output.IsSuccess)
            {
                output.ValidatedResult = name;
            }

            return output;
        }
        public void ValidateName(ValidationResult validationResult)
        {
            var validateNameResult = ValidateName(this.Exam.Title);
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
