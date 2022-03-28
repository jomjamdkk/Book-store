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
        private bool Menu_Opening = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        public static void showArrayList(ArrayList DataList){
            string Data = "    Data\n";
            foreach (string MiniData in DataList)
            {
                Data += MiniData + "\n";
            }
            MessageBox.Show(Data);
        }

        private void MenuBut_Click(object sender, RoutedEventArgs e)
        {
            if (Menu_Opening) {
                
                Storyboard openMenu = (Storyboard)this.Resources["CloseMenu"];
                openMenu.Begin();
                Menu_Opening = false;
            }
            else
            {
                Storyboard closeMenu = (Storyboard)this.Resources["OpenMenu"];
                closeMenu.Begin();
                Menu_Opening = true;
            }
        }

        private void EditCsInfor_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
