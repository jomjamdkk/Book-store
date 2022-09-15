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
using System.Collections;

namespace Book_store
{
    /// <summary>
    /// Interaction logic for NewCustomerPage.xaml
    /// </summary>
    public partial class NewCustomerPage : Page
    {
        public NewCustomerPage()
        {
            InitializeComponent();
        }

        private void Confirm_BTN_Click(object sender, RoutedEventArgs e)
        {
            int NewID = Customers.getMaxID() + 1;
            ArrayList Email = Customers.getEmail();
            int Count = 0;
            for (int i = 0;i<Email.Count;i++) 
            {
                if (Email[i].ToString()!=CustomerEmail_BOX.Text) { Count++; }
            }
            if (CustomerName_BOX.Text != "" && CustomerEmail_BOX.Text != "" && CustomerAddress_BOX.Text != "" && Count == Email.Count)
            {
                Customers.add(NewID, CustomerName_BOX.Text, CustomerAddress_BOX.Text, CustomerEmail_BOX.Text);
                MessageBox.Show("Complete!!!","Register");
            }
            else { MessageBox.Show("Fail   : (", "Register"); }
        }
    }
}
