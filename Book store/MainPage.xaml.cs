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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Book_store
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private bool Menu_Opening;
        public MainPage()
        {
            InitializeComponent();
            Menu_Opening = false;
        }

        private void MenuBut_Click(object sender, RoutedEventArgs e)
        {
            if (Menu_Opening)
            {
                Storyboard closeMenu = (Storyboard)this.Resources["CloseMenu"];
                closeMenu.Begin();
                Menu_Opening = false;
            }
            else
            {
                Storyboard openMenu = (Storyboard)this.Resources["OpenMenu"];
                openMenu.Begin();
                Menu_Opening = true;
            }
        }

        private void BrowseCsData_Click(object sender, RoutedEventArgs e)
        {
            
            this.Content=new BrowseCsDataPage();
        }
    }

}
