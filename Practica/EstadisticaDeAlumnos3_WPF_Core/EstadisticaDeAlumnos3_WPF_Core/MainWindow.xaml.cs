//using Common.Lib.DAL.EFCore.Context;
using Common.Lib.Context.Interfaces;
using Common.Lib.Infrastructure;
using Common.Lib.Models;
using Common.Lib.Models.Core;
using EstadisticaDeAlumnos3_WPF_Core.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EstadisticaDeAlumnos3_WPF_Core
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var bootstrapper = new Bootstrapper();

            var dbConnection = ConfigurationManager.ConnectionStrings["ProjectDb"].ConnectionString;

            Entity.DepCon = new SimpleDependencyContainer();

            bootstrapper.Init(Entity.DepCon, GetDbConstructor(dbConnection));

            //using (var db = new ProjectDbContext()) // 1 variant
            //{
            //    db.Database.Migrate();
            //}
        }

        public void RefreshData()
        {
            var repo = Entity.DepCon.Resolve<IRepository<Student>>();

            lstbox.ItemsSource = repo.QueryAll().ToList();  
            
        }

        public void RefreshData_sb()
        {
            var repo = Entity.DepCon.Resolve<IRepository<Subject>>();

            lstbox_sb.ItemsSource = repo.QueryAll().ToList();

        }

        private static Func<ProjectDbContext> GetDbConstructor(string dbConnection)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectDbContext>();

            optionsBuilder.UseSqlite(dbConnection);

            var dbContextConst = new Func<ProjectDbContext>(() =>
            {
                return new ProjectDbContext(optionsBuilder.Options);
            });
            return dbContextConst;
        }

        private void butt1_Click(object sender, RoutedEventArgs e)
        {
            EditStudent subWindow = new EditStudent();
            subWindow.Owner = this;
            subWindow.Show();           

            //using (var db = new ProjectDbContext())
            //{
            //    Student item = new Student { Name = "Evgenii", Dni = "123" };
            //    db.Students.Add(item);
            //    db.SaveChanges();
            //    lstbox.ItemsSource = db.Students.ToList();
            //}
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //using (var db = new ProjectDbContext())
            //{
            //    lstbox.ItemsSource = db.Students.ToList();
            //}
            RefreshData();

        }

        private void butt2_Click(object sender, RoutedEventArgs e)
        {
            //using (var db = new ProjectDbContext())
            //{
            //    //db.Students.
            //}
        }

        private void butt2_Click_1(object sender, RoutedEventArgs e)
        {
            var selectItem = (Student)lstbox.SelectedValue;

            selectItem.Delete();

            RefreshData();
        }

        private void butt3_Click(object sender, RoutedEventArgs e)
        {
            var selectItem = (Student)lstbox.SelectedValue;
            EditStudent subWindow = new EditStudent(selectItem);
            subWindow.Owner = this;
            subWindow.Show();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tab = sender as TabItem;
            if (tab != null)
            {
                if (tab.Header == "Subjects")
                    RefreshData_sb();
            }
        }
    }
}