using System;
using System.Collections.Generic;
using System.Collections;
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
using System.Windows.Media.Animation;
 
namespace Book_store
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            new Customers();
            new Books();
            new Transaction();
            new Employee();
            Main.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }
        public static void showArrayList(ArrayList DataList){
            string Data = "    Data\n";
            foreach (string MiniData in DataList)
            {
                Data += MiniData + "\n";
            }
            MessageBox.Show(Data);
        }
        private bool Menu_Opening;
        private void MenuBut_Click(object sender, RoutedEventArgs e)
        {
            if (Menu_Opening)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }

        private void BrowseCsData_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = null;
            Main.Content = new BrowseCsDataPage();
            CloseMenu();
        }
        public void OpenMenu()
        {
            Storyboard openMenu = (Storyboard)this.Resources["OpenMenu"];
            openMenu.Begin();
            Menu_Opening = true;
        }
        public void CloseMenu()
        {
            Storyboard closeMenu = (Storyboard)this.Resources["CloseMenu"];
            closeMenu.Begin();
            Menu_Opening = false;
        }
    }
}
