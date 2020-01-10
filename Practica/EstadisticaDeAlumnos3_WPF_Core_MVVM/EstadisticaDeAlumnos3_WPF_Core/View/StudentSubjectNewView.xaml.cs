using EstadisticaDeAlumnos3_WPF_Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EstadisticaDeAlumnos3_WPF_Core.View
{
    /// <summary>
    /// Interaction logic for StudentSubjectNewView.xaml
    /// </summary>
    public partial class StudentSubjectNewView : UserControl
    {
        public StudentSubjectNewView()
        {
            InitializeComponent();
            var vm = new StudentSubjectNewViewModel();
            this.DataContext = vm;
        }
       
    }
}
