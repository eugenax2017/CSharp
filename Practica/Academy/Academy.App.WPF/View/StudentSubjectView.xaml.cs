using Academy.App.WPF.ViewModel;
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

namespace Academy.App.WPF.View
{
    /// <summary>
    /// Interaction logic for StudentSubjectView.xaml
    /// </summary>
    public partial class StudentSubjectView : UserControl
    {
        public StudentSubjectView()
        {
            InitializeComponent();
            var vm = new StudentSubjectViewModel();
            this.DataContext = vm;
        }
    }
}
