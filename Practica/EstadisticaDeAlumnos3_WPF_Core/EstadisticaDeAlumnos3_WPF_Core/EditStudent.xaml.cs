using Common.Lib.Context.Interfaces;
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
    /// Interaction logic for EditStudent.xaml
    /// </summary>
    public partial class EditStudent : Window
    {
        public EditStudent()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Student newStudent = new Student {Name = txtName.Text, Dni = txtDni.Text };

            newStudent.Save();

            var repo = Entity.DepCon.Resolve<IRepository<Student>>();

            (this.Owner as MainWindow).lstbox.ItemsSource = repo.QueryAll().ToList();

            //this.Owner
            //lstbox.ItemsSource = repo.QueryAll().ToList();

            this.Close();
        }
    }
}
