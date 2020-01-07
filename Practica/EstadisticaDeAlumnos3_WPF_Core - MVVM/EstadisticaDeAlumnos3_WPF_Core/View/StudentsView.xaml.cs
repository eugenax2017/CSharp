using Common.Lib.Context.Interfaces;
using Common.Lib.Models;
using Common.Lib.Models.Core;
using Common.Lib.UI;
using EstadisticaDeAlumnos3_WPF_Core.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EstadisticaDeAlumnos3_WPF_Core.View
{
    /// <summary>
    /// Interaction logic for StudentsView.xaml
    /// </summary>
    public partial class StudentsView : UserControl
    {
        public StudentsView()
        {
            InitializeComponent();

            var vm = new ExamensViewModel();
            this.DataContext = vm;
            
        }  
        

    }
}
