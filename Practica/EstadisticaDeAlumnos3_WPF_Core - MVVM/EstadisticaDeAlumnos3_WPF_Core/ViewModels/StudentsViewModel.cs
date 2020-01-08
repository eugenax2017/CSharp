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
        private Student selectedStudent;
        public Student SelectedStudent
        {
            get
            {
                return selectedStudent;
            }
            set
            {
                selectedStudent = value;
                OnPropertyChanged();
            }
        }

        private bool enable = false;
        public bool Enable
        {
            get
            {
                return enable;
            }
            set
            {
                enable = value;
                OnPropertyChanged();
            }
        }

        private bool enable_n = true;
        public bool Enable_N
        {
            get
            {
                return enable_n;
            }
            set
            {
                enable_n = value;
                OnPropertyChanged();
            }
        }

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
            ClearStudentCommand = new RouteCommand(ClearStudent);
            UpdateStudentCommand = new RouteCommand(UpdateStudent);
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
                    Enable = !Enable;
                    Enable_N = !Enable_N;
                }
            }
        }

        public void ClearStudent()
        {
            Name = string.Empty;
            Dni = string.Empty;
            ChairNumber = string.Empty;
            Enable = false;
            Enable_N = !Enable;
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
                Enable = true;
                Enable_N = !Enable;
            }
        }
        public void UpdateStudent()
        {
            if (SelectedStudent != null)
            {
                var output_chair = Student.ValidateChairNumber(ChairNumber);
                if (!output_chair.IsSuccess)
                    MessageBox.Show(output_chair.AllErrors, "Warning!", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    SelectedStudent.Name = Name;
                    SelectedStudent.ChairNumber = output_chair.ValidatedResult;
                    SelectedStudent.Dni = Dni;
                    var res_save = SelectedStudent.Save();
                    if (!res_save.IsSuccess)
                    {
                        MessageBox.Show(res_save.AllErrors, "Warning!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        GetStudents();
                        ClearStudent();
                    }
                        
                }          
            }
        }
        #region Commands
        public ICommand AddStudentCommand { get; set; }
        public ICommand GetStudentsCommand { get; set; }
        public ICommand DeleteStudentCommand { get; set; }
        public ICommand EditStudentCommand { get; set; }
        public ICommand ClearStudentCommand { get; set; }
        public ICommand UpdateStudentCommand {get; set;}
        #endregion
    }

}
