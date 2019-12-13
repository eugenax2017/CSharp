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
        Student student_for_update;
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
            student_for_update = student;
            Update = true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            //bool exit = false;
            var repo = Entity.DepCon.Resolve<IRepository<Student>>();
            var res_save = new SaveResult<Student>();            
            var output_chair = Student.ValidateChairNumber(txtChair.Text, !Update);
            if (!output_chair.IsSuccess)
                MessageBox.Show(output_chair.AllErrors, "Warning!", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                if (!Update)
                {
                    var output_dni = Student.ValidateDni(txtDni.Text);
                    if (!output_dni.IsSuccess)
                        MessageBox.Show(output_dni.AllErrors, "Warning!", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                    {
                        Student newStudent = new Student { Name = txtName.Text, Dni = txtDni.Text, ChairNumber = output_chair.ValidatedResult };
                        res_save = newStudent.Save();                        
                        //exit = true;
                    }                        
                }
                else
                {
                    //check por si acaso
                    var resList_dni = repo.QueryAll().Where(x => x.Dni == txtDni.Text.Trim() && x!= student_for_update).ToList();
                    var resList_chair = repo.QueryAll().Where(x => x.ChairNumber == output_chair.ValidatedResult && x != student_for_update).ToList();

                    if (resList_dni.Count() > 0 || resList_chair.Count() > 0)
                    {
                        MessageBox.Show("Dni i chair_number must be unique!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Error);                        
                    }
                    else if (student_for_update != null)
                    {
                        student_for_update.Name = txtName.Text;
                        student_for_update.Dni = txtDni.Text;
                        student_for_update.ChairNumber = output_chair.ValidatedResult;
                        res_save = student_for_update.Save();
                        //exit = true;
                    }
                }
            }
            if (res_save.IsSuccess)
            {
                (this.Owner as MainWindow).lstbox.ItemsSource = repo.QueryAll().ToList();
                this.Close();
            }
            else if (!string.IsNullOrWhiteSpace(res_save.AllErrors))
                MessageBox.Show(res_save.AllErrors, "Warning!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
