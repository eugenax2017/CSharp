using Academy.App.WPF.UI;
using Academy.Lib.Models;
using Common.Lib.Core;
using Common.Lib.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Academy.App.WPF.ViewModel
{
    public class SubjectViewModel : ViewModelBase
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


        private List<Subject> _subjects;
        public List<Subject> Subjects
        {
            get
            {
                return _subjects;
            }
            set
            {
                _subjects = value;
                OnPropertyChanged();
            }
        }
        public SubjectViewModel()
        {
            AddSubjectCommand = new RouteCommand(AddSubject);
            GetSubjectsCommand = new RouteCommand(GetSubjects);
            DeleteSubjectCommand = new RouteCommand(DeleteSubject);
            EditSubjectCommand = new RouteCommand(EditSubject);
            ClearSubjectCommand = new RouteCommand(ClearSubject);
            UpdateSubjectCommand = new RouteCommand(UpdateSubject);
            GetSubjects();
        }

        public void GetSubjects()
        {
            var repo = Entity.DepCon.Resolve<IRepository<Subject>>();

            Subjects = repo.QueryAll().ToList();
        }

        public void AddSubject()
        {
            var repo = Entity.DepCon.Resolve<IRepository<Subject>>();
            Subject newSubject = new Subject { Name = this.Name };
            var res_save = newSubject.Save();
            if (res_save.IsSuccess)
                GetSubjects();
            else
            {
                MessageBox.Show(res_save.AllErrors, "Warning!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Enable = !Enable;
            Enable_N = !Enable_N;

        }

        public void ClearSubject()
        {
            Name = string.Empty;
            Enable = false;
            Enable_N = !Enable;
        }
        public void DeleteSubject()
        {
            if (SelectedSubject != null)
            {
                SelectedSubject.Delete();
                GetSubjects();
            }
        }

        public void EditSubject()
        {
            if (SelectedSubject != null)
            {
                Name = SelectedSubject.Name;
                Enable = true;
                Enable_N = !Enable;
            }
        }

        public void UpdateSubject()
        {
            if (SelectedSubject != null)
            {
                var output_chair = Subject.ValidateName(Name);
                if (!output_chair.IsSuccess)
                    MessageBox.Show(output_chair.AllErrors, "Warning!", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    SelectedSubject.Name = Name;
                    var res_save = SelectedSubject.Save();
                    if (!res_save.IsSuccess)
                    {
                        MessageBox.Show(res_save.AllErrors, "Warning!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        GetSubjects();
                        ClearSubject();
                    }

                }
            }
        }


        #region Commands
        public ICommand AddSubjectCommand { get; set; }
        public ICommand GetSubjectsCommand { get; set; }
        public ICommand DeleteSubjectCommand { get; set; }
        public ICommand EditSubjectCommand { get; set; }
        public ICommand ClearSubjectCommand { get; set; }
        public ICommand UpdateSubjectCommand { get; set; }
        #endregion
    }
}
