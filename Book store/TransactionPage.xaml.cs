using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for TransactionPage.xaml
    /// </summary>
    public partial class TransactionPage : Page
    {

        bool ThePageIsCurrentlyOpen=true;//True means Opening BrowseTransactionPage   False means Opening NewTransactionPag
        public TransactionPage()
        {
            InitializeComponent();
            TransactionFrame.Content = new BrowseTransactionPage();
        }

        private void TogglePage_Click(object sender, RoutedEventArgs e)
        {
            ThePageIsCurrentlyOpen = !ThePageIsCurrentlyOpen;
            if (ThePageIsCurrentlyOpen) { TransactionFrame.Content = new BrowseTransactionPage(); }
            else { TransactionFrame.Content = new NewTransactionPage(); }
        }
    }
}
