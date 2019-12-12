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
    /// Interaction logic for EditStudent.xaml
    /// </summary>
    public partial class EditStudent : Window
    {
        private bool Update = false;
        public EditStudent()
        {
            InitializeComponent();
        }

        public EditStudent(Student student)
        {
            InitializeComponent();

            txtName.Text = student.Name;
            txtDni.Text = student.Dni;
            txtChair.Text = student.ChairNumber.ToString();
            Update = true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Student newStudent = new Student {Name = txtName.Text, Dni = txtDni.Text, ChairNumber = (txtChair.Text.Trim() == "" ? 0 : int.Parse(txtChair.Text))};

            SaveResult<Student> output;

            if (!Update)
                output = newStudent.Save();

            var repo = Entity.DepCon.Resolve<IRepository<Student>>();

            (this.Owner as MainWindow).lstbox.ItemsSource = repo.QueryAll().ToList();

            if (!output.IsSuccess)
            {                
                MessageBox.Show(output.AllErrors, "Warning!", MessageBoxButton.OK, MessageBoxImage.Error);                
            }
            else
            {
                this.Close();
            }
            
        }
    }
}
