using Academy.App.WPF.UI;
using Academy.Lib.Models;
using Common.Lib.Core;
using Common.Lib.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Academy.App.WPF.ViewModel
{
    public class StudentSubjectViewModel : ViewModelBase
    {
        private Subject selectedSubject;

        public Subject SelectedSubject
        {
            get
            {
                return selectedSubject;
            }
            set
            {
                selectedSubject = value;
                OnPropertyChanged();
            }
        }
        private Subject selectedStudentSubject;

        public Subject SelectedStudentSubject
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
        private string dniEntry;

        public string DniEntry
        {
            get
            {
                return dniEntry;
            }
            set
            {
                dniEntry = value;
                if (!string.IsNullOrEmpty(dniEntry))
                {
                    GetSubjectsByStudent();
                }
                OnPropertyChanged();
            }
        }

        private List<Subject> subjectsByStudent;
        public List<Subject> SubjectsByStudent
        {
            get
            {
                return subjectsByStudent;
            }
            set
            {
                subjectsByStudent = value;
                OnPropertyChanged();
            }
        }

        private List<Subject> subjects;
        public List<Subject> Subjects
        {
            get
            {
                return subjects;
            }
            set
            {
                subjects = value;
                OnPropertyChanged();
            }
        }

        private List<Student> _students;
        public List<Student> Students
        {
            get
            {
                //var repo = Entity.DepCon.Resolve<IRepository<Student>>();
                //_students = repo.QueryAll().ToList();
                return _students;
            }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        public StudentSubjectViewModel()
        {
            AddStudentSubjectCommand = new RouteCommand(AddStudentSubject);
            DeleteStudentSubjectCommand = new RouteCommand(DeleteStudentSubject);
            UpdateStudentSubjectCommand = new RouteCommand(UpdateStudentSubject);
            UpdateStudentSubject();
        }
        public void AddStudentSubject()
        {
            if (SelectedSubject != null)
            {
                if (!string.IsNullOrEmpty(dniEntry))
                {
                    var repo = Entity.DepCon.Resolve<IRepository<Student>>();
                    var stud = repo.QueryAll().Where(x => x.Dni == dniEntry).FirstOrDefault();
                    StudentSubject newStudent = new StudentSubject { StudentId = stud.Id, SubjectId = SelectedSubject.Id };
                    var res_save = newStudent.Save();
                    if (res_save.IsSuccess)
                    {
                        if (!string.IsNullOrEmpty(dniEntry))
                        {
                            GetSubjectsByStudent();
                        }
                    }

                }
            }
        }
        public void DeleteStudentSubject()
        {
            if (!string.IsNullOrEmpty(dniEntry))
            {
                if (SelectedStudentSubject != null)
                {
                    var repo = Entity.DepCon.Resolve<IRepository<StudentSubject>>();
                    var element = repo.QueryAll().Where(x => (x.Student.Dni == dniEntry && x.SubjectId == SelectedStudentSubject.Id)).FirstOrDefault();
                    if (element != null)
                    {
                        element.Delete();
                        GetSubjectsByStudent();
                    }
                }
            }
        }
        public void UpdateStudentSubject()
        {
            var current = DniEntry;
            GetStudents();
            GetSubjects();
            DniEntry = current;

        }
        public void GetStudents()
        {
            var repo = Entity.DepCon.Resolve<IRepository<Student>>();

            Students = repo.QueryAll().ToList();
        }
        public void GetSubjects()
        {
            var repo = Entity.DepCon.Resolve<IRepository<Subject>>();

            Subjects = repo.QueryAll().ToList();
        }

        public void GetSubjectsByStudent()
        {
            var repo = Entity.DepCon.Resolve<IRepository<StudentSubject>>();

            SubjectsByStudent = repo.QueryAll().Where(x => x.Student.Dni == dniEntry).Select(x => x.Subject).ToList();
        }


        #region Commands
        public ICommand AddStudentSubjectCommand { get; set; }
        public ICommand GetStudentsCommand { get; set; }
        public ICommand DeleteStudentSubjectCommand { get; set; }
        public ICommand EditStudentCommand { get; set; }
        //public ICommand ClearStudentCommand { get; set; }
        public ICommand UpdateStudentSubjectCommand { get; set; }
        #endregion
    }
}
