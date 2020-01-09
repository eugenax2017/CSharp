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
        private StudentSubject selectedStudentSubject;
        public StudentSubject SelectedStudentSubject
        {
            get
            {
                return selectedStudentSubject;
            }
            set
            {
                selectedStudentSubject = value;
                OnPropertyChanged();
            }
        }
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
            DeleteStudentSubjectCommand = new RouteCommand(DeleteStudentSubject);
            GetStudentSubjects();
        }

        public void GetStudentSubjects()
        {
            var repo = Entity.DepCon.Resolve<IRepository<StudentSubject>>();

            StudentSubjects = repo.QueryAll().ToList();
        }

        public void AddStudentSubject()
        {
            var repo1 = Entity.DepCon.Resolve<IRepository<Student>>();
            var stud = repo1.QueryAll().FirstOrDefault();
            var repo2 = Entity.DepCon.Resolve<IRepository<Subject>>();
            var subj = repo2.QueryAll().FirstOrDefault();            
            StudentSubject newStudent = new StudentSubject { StudentId = stud.Id, SubjectId = subj.Id};           
            var res_save = newStudent.Save();
            stud.StudentSubject.Add(newStudent);
            var res_save1 = stud.Save();            
            if (res_save.IsSuccess && res_save1.IsSuccess) 
                GetStudentSubjects();
        }

        public void DeleteStudentSubject()
        {
            if (SelectedStudentSubject != null)
            {
                SelectedStudentSubject.Delete();
                GetStudentSubjects();
            }
        }

        #region Commands
        public ICommand AddStudentSubjectCommand { get; set; }
        public ICommand GetStudentsCommand { get; set; }
        public ICommand DeleteStudentSubjectCommand { get; set; }
        public ICommand EditStudentCommand { get; set; }
        public ICommand ClearStudentCommand { get; set; }
        public ICommand UpdateStudentCommand { get; set; }
        #endregion

    }
}
