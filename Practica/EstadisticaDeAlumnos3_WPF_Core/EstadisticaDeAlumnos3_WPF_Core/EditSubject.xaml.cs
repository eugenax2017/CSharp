using Common.Lib.Context.Interfaces;
using Common.Lib.Infrastructure;
using Common.Lib.Models;
using Common.Lib.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EstadisticaDeAlumnos3_WPF_Core
{
    /// <summary>
    /// Interaction logic for EditSubject.xaml
    /// </summary>    
    public partial class EditSubject : Window
    {
        private bool Update = false;
        Subject subject_for_update;
        public EditSubject()
        {
            InitializeComponent();
        }
        public EditSubject(Student student)
        {
            InitializeComponent();

            txtName.Text = student.Name;
            
            Update = true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var repo = Entity.DepCon.Resolve<IRepository<Subject>>();
            var res_save = new SaveResult<Subject>();

            if (!Update)
            {
                var output_dni = Subject.ValidateName(txtName.Text);
                if (!output_dni.IsSuccess)
                    MessageBox.Show(output_dni.AllErrors, "Warning!", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    Subject newSubject = new Subject { Name = txtName.Text};
                    res_save = newSubject.Save();
                    //exit = true;
                }
            }
            else
            {
                //check por si acaso
               

                if (subject_for_update != null)
                {
                    subject_for_update.Name = txtName.Text;                    
                    res_save = subject_for_update.Save();
                    //exit = true;
                }
            }

            if (res_save.IsSuccess)
            {
                (this.Owner as MainWindow).lstbox_sb.ItemsSource = repo.QueryAll().ToList();
                this.Close();
            }
            else if (!string.IsNullOrWhiteSpace(res_save.AllErrors))
                MessageBox.Show(res_save.AllErrors, "Warning!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
