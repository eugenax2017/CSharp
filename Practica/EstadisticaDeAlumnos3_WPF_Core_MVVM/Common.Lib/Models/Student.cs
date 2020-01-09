using Common.Lib.Context.Interfaces;
using Common.Lib.Infrastructure;
using Common.Lib.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Lib.Models
{
    public class Student : Entity
    {        
        public string Name { get; set; }

        public int ChairNumber { get; set; }
        public string Dni { get; set; }

        //Foreign key for Examen
        public List<StudentSubject> StudentSubject 
        {
            get
            {
                var repo = DepCon.Resolve<IRepository<StudentSubject>>();
                return repo.QueryAll().Where(x=>x.StudentId==this.Id).ToList();
            }
        }

        public SaveResult<Student> Save()
        {
            return base.Save<Student>();
        }

        public SaveResult<Student> Delete()
        {
            return base.Delete<Student>();
        }               

        #region Static Validations

        public static ValidationResult<string> ValidateDni(string dni, Guid currentId = default)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(dni))
            {
                output.IsSuccess = false;
                output.Errors.Add("el dni del alumno no puede estar vacío");
            }

            #region check duplication
            var repo = DepCon.Resolve<IRepository<Student>>();
            var entityWithDni = repo.QueryAll().Where(x => x.Dni == dni).FirstOrDefault(); 

            if (currentId == default && entityWithDni != null)
            {
                // on create
                output.IsSuccess = false;
                output.Errors.Add("ya existe un alumno con ese dni");
            }
            else if (currentId != default && entityWithDni.Id != currentId)
            {
                // on update
                output.IsSuccess = false;
                output.Errors.Add("ya existe un alumno con ese dni");
            }
            #endregion

            if (output.IsSuccess)
            {
                output.ValidatedResult = dni;

            }

            return output;
        }

        public static ValidationResult<int> ValidateChairNumber(string chairNumberText, bool dublicate = true )
        {
            var output = new ValidationResult<int>()
            {
                IsSuccess = true
            };

            var chairNumber = 0;
            var isConversionOk = false;

            #region check null or empty
            if (string.IsNullOrEmpty(chairNumberText))
            {
                output.IsSuccess = false;
                output.Errors.Add("el número de la silla no puede estar vacío o nulo");
            }
            #endregion

            #region check format conversion

            isConversionOk = int.TryParse(chairNumberText, out chairNumber);

            if (!isConversionOk)
            {
                output.IsSuccess = false;
                output.Errors.Add($"no se puede convertir {chairNumber} en número");
            }

            #endregion

            #region check if the char is already in use

            if (isConversionOk && dublicate)
            {                
                var repoStudents = DepCon.Resolve<IRepository<Student>>(); 
                var currentStudentInChair = repoStudents.QueryAll().FirstOrDefault(s => s.ChairNumber == chairNumber);

                if (currentStudentInChair != null)
                {
                    output.IsSuccess = false;
                    output.Errors.Add($"ya hay un alumno {currentStudentInChair.Name} en la silla {chairNumber}");
                }
            }
            #endregion

            if (output.IsSuccess)
                output.ValidatedResult = chairNumber;

            return output;
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
                output.Errors.Add("el nombre delalumno no puede estar vacío");
            }

            if (output.IsSuccess)
            {
                output.ValidatedResult = name;
            }

            return output;
        }

        #endregion

        #region Domain Validations

        public void ValidateName(ValidationResult validationResult)
        {
            var validateNameResult = ValidateName(this.Name);
            if (!validateNameResult.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(validateNameResult.Errors);
            }
        }

        public void ValidateDni(ValidationResult validationResult)
        {            
            var vr = ValidateDni(this.Dni, this.Id);

            if (!vr.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(vr.Errors);
            }
        }

        public void ValidateChairNumber(ValidationResult validationResult)
        {
            var vr = ValidateChairNumber(this.ChairNumber.ToString());

            if (!vr.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(vr.Errors);
            }
        }
        public override ValidationResult Validate()
        {
            var output = base.Validate();

            // cambiar ValidateName para que sea igual que ValidateDni
            ValidateName(output);
            if (this.Id == default)
            {
                ValidateDni(output);
                ValidateChairNumber(output);
            }                            
            return output;
        }

        public Student Clone(Student oldStudent)
        {
            var type = oldStudent.GetType();
            var props = type.GetProperties();
            Student newStudent = new Student();
            foreach (var prop in props)
            { 
                var r = 0;
            //    newStudent[prop] = oldStudent[prop];
            }
            return new Student
            {
                Id = oldStudent.Id,
                Name = oldStudent.Name,
                Dni = oldStudent.Dni,
                ChairNumber = oldStudent.ChairNumber                
            };
        }

        #endregion
    }
}
