using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
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
            Main.NavigationUIVisibility = NavigationUIVisibility.Hidden; //Customers.add(1,"JOMJAM DKK","Chiangmai","jomjamdkk@gmail.com");
            MessageBox.Show("MaxID = "+Customers.getMaxID().ToString());
            //Transaction.add(1,2,8);

            /*Random ran = new Random();
            for (int i = 1; i<=20;i++) {
                Employee.add(i,"","",i,ran.Next(100000,1000000)); 
            }*/
        }
        public static string ArrayListTostring(ArrayList DataList)
        {
            string Data = "";
            foreach (string MiniData in DataList)
            {
                Data += MiniData + "\n";
            }
            //MessageBox.Show(Data);
            return Data;
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
        private void CustomersBTN_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = null;
            Main.Content = new CustomersPage();
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

        private void Transac_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = null;
            Main.Content = new TransactionPage();
            CloseMenu();

        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Main.Content = null;
        }
        public static bool IsNumber(string S)
        {
            char[] charArray=S.ToCharArray();
            for (int i=0;i<S.Length;i++) 
            {
                if (!(charArray[i] == '1'|| charArray[i] == '2'||charArray[i]=='3'|| charArray[i] == '4'|| charArray[i] == '5' || charArray[i] == '6' || charArray[i] == '7' || charArray[i] == '8' || charArray[i] == '9' || charArray[i] == '0' )) 
                {
                    return false;
                }
            }
            return true;
        }
    }
}
