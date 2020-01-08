using Common.Lib.Context.Interfaces;
using Common.Lib.Models;
using Common.Lib.Models.Core;
using Common.Lib.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace EstadisticaDeAlumnos3_WPF_Core.ViewModels
{
    class StudentSubjectViewModel : ViewModelBase
    {
        private string studentDni;
        public string StudentDni
        {
            get
            {
                return studentDni;
            }
            set
            {
                studentDni = value;
                OnPropertyChanged();
            }
        }

        private string subjectName;
        public string SubjectName
        {
            get
            {
                return subjectName;
            }
            set
            {
                subjectName = value;
                OnPropertyChanged();
            }
        }

        private List<StudentSubject> _studentSubjects;
        public List<StudentSubject> StudentSubjects
        {
            get
            {
                return _studentSubjects;
            }
            set
            {
                _studentSubjects = value;
                OnPropertyChanged();
            }
        }

        public StudentSubjectViewModel()
        {
            AddStudentSubjectCommand = new RouteCommand(AddStudentSubject);
        }

        public void GetStudentSubjects()
        {
            var repo = Entity.DepCon.Resolve<IRepository<StudentSubject>>();

            StudentSubjects = repo.QueryAll().ToList();
        }

        public void AddStudentSubject()
        {
            var repo = Entity.DepCon.Resolve<IRepository<StudentSubject>>();
            //StudentSubject newStudent = new StudentSubject { Name = this.Name, Dni = this.Dni, ChairNumber = output_chair.ValidatedResult };
            //var res_save = newStudent.Save();
            //if (res_save.IsSuccess)
            //    GetStudents();
        }

        #region Commands
        public ICommand AddStudentSubjectCommand { get; set; }
        public ICommand GetStudentsCommand { get; set; }
        public ICommand DeleteStudentCommand { get; set; }
        public ICommand EditStudentCommand { get; set; }
        public ICommand ClearStudentCommand { get; set; }
        public ICommand UpdateStudentCommand { get; set; }
        #endregion

    }
}
