using System;
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
using System.Windows.Shapes;

namespace Book_store
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(IDBox.Text);
            if (CheckPassword(id, PWBox.Password)) { GoMain(); Close(); }
            else { PWBox.Foreground = new SolidColorBrush(Colors.Red); }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            int EID = int.Parse(EIDBox.Text);
            if (CheckPassword(EID,OldPassword_Box.Text)) { 
                Employee.set(EID,"Employee_Name",NameBox.Text);
                Employee.set(EID,"Address",AddressBox.Text);
                Employee.set(EID,"NationalID",NIDBox.Text);
                Employee.set(EID,"Password",NewPassword_Box.Text);
                
                GoMain();Close();
            }
            else { OldPassword_Box.Foreground = new SolidColorBrush(Colors.Red); }
        }
        public static bool CheckPassword(int ID,string Password) {
            ArrayList E_Data = new ArrayList();
            E_Data = Employee.get(ID);
            if (E_Data[4].ToString() == Password){ return true; }
            else{ return false; }
        }
        private void GoMain() 
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
