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
            this.Content=new MainPage();
        }
        public static void showArrayList(ArrayList DataList){
            string Data = "    Data\n";
            foreach (string MiniData in DataList)
            {
                Data += MiniData + "\n";
            }
            MessageBox.Show(Data);
        }

    }
}
