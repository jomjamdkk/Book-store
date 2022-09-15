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

namespace Book_store
{
    /// <summary>
    /// Interaction logic for CustomersPage.xaml
    /// </summary>
    public partial class CustomersPage : Page
    {
        bool ThePageIsCurrentlyOpen_CustomersPage = true;//True means Opening BrowseCsDataPage   False means Opening NewCustomerPage
        public CustomersPage()
        {
            InitializeComponent();
            CustomersPageFrame.Content = new BrowseCsDataPage();
        }

        private void TogglePage_CustomersPage_Click(object sender, RoutedEventArgs e)
        {

            ThePageIsCurrentlyOpen_CustomersPage = !ThePageIsCurrentlyOpen_CustomersPage;
            if (ThePageIsCurrentlyOpen_CustomersPage) 
            {
                CustomersPageFrame.Content = new BrowseCsDataPage(); TogglePage_CustomersPage.Content = "New Customer";
            }
            else 
            {
                CustomersPageFrame.Content = new NewCustomerPage(); TogglePage_CustomersPage.Content = "Browse Customer";
            }

        }
    }
}
