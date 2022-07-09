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
        public ArrayList BigData = Transaction.get();
        public ArrayList isbnList = new ArrayList();
        public ArrayList nameList = new ArrayList();
        public ArrayList quantityList = new ArrayList();
        public ArrayList dateList = new ArrayList();
        public ArrayList timeList = new ArrayList();
        public ArrayList dateTimeList = new ArrayList();
        public ArrayList totalList = new ArrayList();
        int Row;
        private int Y_Axis = 400;

        public TransactionPage()
        {
            InitializeComponent();
            SetupAndReset_Page();
        }
        private void SetupAndReset_Page() 
        {
            ClearArrayList();
            ClearPageList();
            Row = BigData.Count / 6;
            Thread thread1 = new Thread(ManageData2);
            thread1.Start();
            ManageData1();
            ISBNBlock.Text = MainWindow.ArrayListTostring(isbnList);
            for (int i = 0; i < Row; i++) { PriceBlock.Text += (int.Parse(totalList[i].ToString()) / int.Parse(quantityList[i].ToString())).ToString() + "\n"; }
            DateTimeBlock.Text = MainWindow.ArrayListTostring(dateTimeList);
            QuantityBlock.Text = MainWindow.ArrayListTostring(quantityList);
            TotalBlock.Text = MainWindow.ArrayListTostring(totalList);
            CustomerBlock.Text = MainWindow.ArrayListTostring(nameList);
        }
        private void ClearArrayList() {

            BigData = Transaction.get();
            isbnList = new ArrayList();
            nameList = new ArrayList();
            quantityList = new ArrayList();
            dateList = new ArrayList();
            timeList = new ArrayList();
            dateTimeList = new ArrayList();
            totalList = new ArrayList();
        }
        private void ManageData1() 
        {
            for (int i = 2; i < BigData.Count; i += 6)
            {
                quantityList.Add(BigData[i]);
            }
            for (int i = 3; i < BigData.Count; i += 6)
            {
                dateList.Add(BigData[i]);
            }

            for (int i =1;i<BigData.Count;i+=6) 
            {
                nameList.Add(Customers.get((int.Parse(BigData[i].ToString())))[1].ToString());
            }
            for (int i = 4; i < BigData.Count; i += 6)
            {
                timeList.Add(BigData[i]);
            }
            for (int i = 0; i < Row; i++)
            {
                dateTimeList.Add(dateList[i] + "-" + timeList[i]);
            }
        }
        private void ManageData2() 
        {
            for (int i =0;i<BigData.Count;i+=6) 
            {
                isbnList.Add(BigData[i]);
            }
            for (int i=5;i<BigData.Count;i+=6) 
            {
                totalList.Add(BigData[i]);
            }
        }

        private void Mouse_Wheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta>0&&Y_Axis<399) { Y_Axis += 40; }//Up
            else if(e.Delta < 0) { Y_Axis -= 40; }//Down
            ISBNBlock.Margin = new Thickness(200,Y_Axis,0,0);
            CustomerBlock.Margin = new Thickness(440, Y_Axis,0,0);
            DateTimeBlock.Margin = new Thickness(950, Y_Axis,0,0);
            QuantityBlock.Margin = new Thickness(1220, Y_Axis,0,0);
            PriceBlock.Margin = new Thickness(1425, Y_Axis,0,0);
            TotalBlock.Margin = new Thickness(1635, Y_Axis,0,0);
        }

        private void ClearPageList()
        {
            ISBNBlock.Text = "";
            PriceBlock.Text = "";
            DateTimeBlock.Text = "";
            QuantityBlock.Text = "";
            TotalBlock.Text = "";
            CustomerBlock.Text = "";
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (SearchBox.Text.Length!=0) 
            {
                if (MainWindow.IsNumber(SearchBox.Text))
                {
                    ArrayList SearchResult = new ArrayList();
                    ClearPageList();

                    for (int i = 0; i < Row; i++)
                    {
                        if (SearchBox.Text == BigData[(i * 6) + 1].ToString())
                        {
                            SearchResult.Add(i);
                        }
                    }
                    for (int i = 0; i < SearchResult.Count; i++)
                    {

                        ISBNBlock.Text += isbnList[int.Parse(SearchResult[i].ToString())].ToString() + "\n";
                        PriceBlock.Text += int.Parse(totalList[int.Parse(SearchResult[i].ToString())].ToString()) / int.Parse(quantityList[int.Parse(SearchResult[i].ToString())].ToString()) + "\n";
                        DateTimeBlock.Text += dateList[int.Parse(SearchResult[i].ToString())].ToString() + "-" + timeList[int.Parse(SearchResult[i].ToString())].ToString() + "\n";
                        QuantityBlock.Text += quantityList[int.Parse(SearchResult[i].ToString())].ToString() + "\n";
                        TotalBlock.Text += totalList[int.Parse(SearchResult[i].ToString())].ToString() + "\n";
                        CustomerBlock.Text += nameList[int.Parse(SearchResult[i].ToString())].ToString() + "\n";
                    }
                }
                else
                {
                    char[] UserInput = SearchBox.Text.ToCharArray();
                    if (UserInput[2] == '/'||UserInput[5]=='/') 
                    {
                        ArrayList SearchResult = new ArrayList();
                        ClearPageList();

                        for (int i = 0; i < Row; i++)
                        {
                            if (SearchBox.Text == BigData[(i * 6) + 3].ToString())
                            {
                                SearchResult.Add(i);
                            }
                        }
                        for (int i = 0; i < SearchResult.Count; i++)
                        {

                            ISBNBlock.Text += isbnList[int.Parse(SearchResult[i].ToString())].ToString() + "\n";
                            PriceBlock.Text += int.Parse(totalList[int.Parse(SearchResult[i].ToString())].ToString()) / int.Parse(quantityList[int.Parse(SearchResult[i].ToString())].ToString()) + "\n";
                            DateTimeBlock.Text += dateList[int.Parse(SearchResult[i].ToString())].ToString() + "-" + timeList[int.Parse(SearchResult[i].ToString())].ToString() + "\n";
                            QuantityBlock.Text += quantityList[int.Parse(SearchResult[i].ToString())].ToString() + "\n";
                            TotalBlock.Text += totalList[int.Parse(SearchResult[i].ToString())].ToString() + "\n";
                            CustomerBlock.Text += nameList[int.Parse(SearchResult[i].ToString())].ToString() + "\n";
                        } 
                    }
                }
            }
            else
            {
                SetupAndReset_Page(); 
            }
        }
        
    }
}
