using Common.Lib.Context.Interfaces;
using Common.Lib.Models;
using Common.Lib.Models.Core;
using Common.Lib.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace EstadisticaDeAlumnos3_WPF_Core.ViewModels
{
    public class StudentsViewModel : ViewModelBase
    {
        public Student SelectedStudent { get; set; }

        private List<Student> _students;
        public List<Student> Students
        {
            get
            {
                return _students;
            }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }
        public StudentsViewModel()
        {            
            AddStudentCommand = new RouteCommand(AddStudent);
            GetStudentsCommand = new RouteCommand(GetStudents);
            DeleteStudentCommand = new RouteCommand(DeleteStudent);
        }

        public void GetStudents()
        {
            var repo = Entity.DepCon.Resolve<IRepository<Student>>();

            Students = repo.QueryAll().ToList();
        }

        public void AddStudent()
        {
            EditStudent subWindow = new EditStudent();
            //subWindow.Owner = this;
            subWindow.DBStudents = Students;
            subWindow.Show();
        }

        public void DeleteStudent()
        {            
            if (SelectedStudent != null)
            {
                SelectedStudent.Delete();
                GetStudents();
            }
            
        }

        #region Commands
        public ICommand AddStudentCommand { get; set; }
        public ICommand GetStudentsCommand { get; set; }
        public ICommand DeleteStudentCommand { get; set; }
        #endregion
    }

}
