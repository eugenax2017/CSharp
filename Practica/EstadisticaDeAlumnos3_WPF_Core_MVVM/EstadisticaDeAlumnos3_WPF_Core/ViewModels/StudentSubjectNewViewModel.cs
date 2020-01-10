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
    public class StudentSubjectNewViewModel : ViewModelBase
    {
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
                    var repo = Entity.DepCon.Resolve<IRepository<StudentSubject>>();
                    SubjectsByStudent = repo.QueryAll().Where(x => x.Student.Dni == dniEntry).Select(x => x.Subject).ToList();
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


        private List<Student> _students;
        public List<Student> Students { 
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

        public StudentSubjectNewViewModel()
        {

            AddStudentSubjectCommand = new RouteCommand(AddStudentSubject);
            GetStudents();
        }      
        
        public void AddStudentSubject()
        {

        }
        public void GetStudents()
        {
            var repo = Entity.DepCon.Resolve<IRepository<Student>>();

            Students = repo.QueryAll().ToList();
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
