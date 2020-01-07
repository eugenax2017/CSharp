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

            var bootstrapper = new Bootstrapper();

            var dbConnection = ConfigurationManager.ConnectionStrings["ProjectDb"].ConnectionString;

            Entity.DepCon = new SimpleDependencyContainer();

            bootstrapper.Init(Entity.DepCon, GetDbConstructor(dbConnection));

            InitializeComponent();           

            //using (var db = new ProjectDbContext()) // 1 variant
            //{
            //    db.Database.Migrate();
            //}
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

 

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (e.OriginalSource is TabControl)
            //{
            //    TabControl tab = sender as TabControl;
            //    if (tab != null)
            //    {
            //        TabItem tabItem = tab.SelectedValue as TabItem;
            //        if (tabItem.Name == "Subjects")
            //            RefreshData_sb();
            //    }
            //}           
            
            //if (MyTabItem1 != null && MyTabItem1.IsSelected)
            //    // do your staff
            //if (MyTabItem2 != null && MyTabItem2.IsSelected)
            //        // do your staff
            //if (MyTabItem3 != null && MyTabItem3.IsSelected)
            //        // do your staff
        }
       
        
    }
}