using System;
using System.Collections.Generic;
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
using System.ComponentModel;
using System.Data.Entity;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PeopleContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new PeopleContext();
            db.Persons.Load();
            People.ItemsSource = db.Persons.Local.ToBindingList();

            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void Btn_Update(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void Btn_Delete(object sender, RoutedEventArgs e)
        {
            if(People.SelectedItems.Count > 0)
            {
                for(int i = 0; i < People.SelectedItems.Count; i++)
                {
                    Person pers = People.SelectedItems[i] as Person;
                    if(pers != null)
                    {
                        db.Persons.Remove(pers);
                    }
                }
            }
            db.SaveChanges();
        }
    }
}
    