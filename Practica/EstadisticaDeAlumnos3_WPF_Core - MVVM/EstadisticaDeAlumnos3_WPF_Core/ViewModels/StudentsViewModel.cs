using Common.Lib.Context.Interfaces;
using Common.Lib.Models;
using Common.Lib.Models.Core;
using Common.Lib.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace EstadisticaDeAlumnos3_WPF_Core.ViewModels
{
    public class StudentsViewModel : ViewModelBase
    {
        public Student SelectedStudent { get; set; }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set 
            {
                name = value;
                OnPropertyChanged();
            }
        }
        private string dni;
        public string Dni
        {
            get
            {
                return dni;
            }
            set
            {
                dni = value;
                OnPropertyChanged();
            }
        }

        private string chairNumber;
        public string ChairNumber
        {
            get
            {
                return chairNumber;
            }
            set
            {
                chairNumber = value;
                OnPropertyChanged();
            }
        }
       

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
            EditStudentCommand = new RouteCommand(EditStudent);
            GetStudents();
        }

        public void GetStudents()
        {
            var repo = Entity.DepCon.Resolve<IRepository<Student>>();

            Students = repo.QueryAll().ToList();
        }

        public void AddStudent()
        {
            var repo = Entity.DepCon.Resolve<IRepository<Student>>();
            var output_chair = Student.ValidateChairNumber(this.ChairNumber.ToString());
            if (!output_chair.IsSuccess)
                MessageBox.Show(output_chair.AllErrors, "Warning!", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                var output_dni = Student.ValidateDni(this.Dni);
                if (!output_dni.IsSuccess)
                    MessageBox.Show(output_dni.AllErrors, "Warning!", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    Student newStudent = new Student { Name = this.Name, Dni = this.Dni, ChairNumber = output_chair.ValidatedResult };
                    var res_save = newStudent.Save();
                    if (res_save.IsSuccess)
                        GetStudents();

                }
            }
        }

        public void DeleteStudent()
        {            
            if (SelectedStudent != null)
            {
                SelectedStudent.Delete();
                GetStudents();
            }
            
        }

        public void EditStudent()
        {
            if (SelectedStudent != null)
            {
                //var res_save = SelectedStudent.Save();
                //if (res_save.IsSuccess)
                //    GetStudents();
                Name = SelectedStudent.Name;
                Dni = SelectedStudent.Dni;
                ChairNumber = SelectedStudent.ChairNumber.ToString();
            }
        }

        #region Commands
        public ICommand AddStudentCommand { get; set; }
        public ICommand GetStudentsCommand { get; set; }
        public ICommand DeleteStudentCommand { get; set; }
        public ICommand EditStudentCommand { get; set; }
        #endregion
    }

}
