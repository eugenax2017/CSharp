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
    public class ExamViewModel : ViewModelBase
    {
        private String title;
        public String Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        private String text;
        public String Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged();
            }
        }

        private DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged();
            }
        }

        private Subject subjectEntry;
        public Subject SubjectEntry
        {
            get
            {
                return subjectEntry;
            }
            set
            {
                subjectEntry = value;
                OnPropertyChanged();
            }
        }

        private List<Exam> exams;
        public List<Exam> Exams
        {
            get
            {
                return exams;
            }
            set
            {
                exams = value;
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

        public ExamViewModel()
        {
            AddExamCommand = new RouteCommand(AddExam);
            GetSubjects();
        }
        public void GetSubjects()
        {
            var repo = Entity.DepCon.Resolve<IRepository<Subject>>();

            Subjects = repo.QueryAll().ToList();
        }

        public void AddExam()
        {
            if (SubjectEntry != null)
            {
                if (Date != null)
                {                    
                    Exam newExam = new Exam { Title = Title, Date = Date, Text = Text,  Subject = SubjectEntry, SubjectId = SubjectEntry.Id};
                    var res_save = newExam.Save();
                    if (res_save.IsSuccess)
                    {
                        GetExams();                       
                    }

                }
            }
        }

        public void GetExams()
        {
            var repo = Entity.DepCon.Resolve<IRepository<Exam>>();
            Exams = repo.QueryAll().ToList();
        }

        #region Commands
        public ICommand AddExamCommand { get; set; }
        public ICommand GetStudentsCommand { get; set; }
        public ICommand DeleteStudentSubjectCommand { get; set; }
        public ICommand EditStudentCommand { get; set; }
        //public ICommand ClearStudentCommand { get; set; }
        public ICommand UpdateStudentSubjectCommand { get; set; }
        #endregion

    }
}
