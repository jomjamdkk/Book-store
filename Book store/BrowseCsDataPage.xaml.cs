using System;
using System.Collections;
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

namespace Book_store {
    /// <summary>
    /// Interaction logic for BrowseCsDataPage.xaml
    /// </summary>
    public partial class BrowseCsDataPage : Page {
        public BrowseCsDataPage() {
            InitializeComponent();
            NotFound.Visibility = Visibility.Hidden;
        }

        private void Back(object sender, RoutedEventArgs e) {
            Content = null;
        }

        private void SearchByID_Click(object sender, RoutedEventArgs e)
        {
            ArrayList Data = Customers.get(int.Parse(SearchBox.Text));
            if (Data.Count != 0)
            {
                IDBlock.Text = Data[0].ToString();
                NameBlock.Text = Data[1].ToString();
                AddressBlock.Text = Data[2].ToString();
                EmailBlock.Text = Data[3].ToString();
                NotFound.Visibility = Visibility.Hidden;
            }
            else { NotFound.Visibility = Visibility.Visible;
                string s = "Not found";
                IDBlock.Text = s;
                NameBlock.Text = s;
                AddressBlock.Text = s;
                EmailBlock.Text = s;
            }
        }
    }
}
