using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Invoice.Properties;
using Microsoft.Reporting.WinForms;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using Label = System.Windows.Controls.Label;

namespace Invoice
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           
            InitializeComponent();
            var loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
            var client = new Client();
            client.CheckWl("6972171117","2020-04-30");
            
            FakturyDrukujMenuItem.Click += DrukujMenuItem_Click;
            
            
            var dt = new DataTable();
            var db = new DataBase();
            filter1Lbl.Content = "Numer faktury";
            filter2Lbl.Content = "Nazwa klienta";
            dateFilterLbl.Content = "Data od:";
            dateLbl2.Content = "do:";
            dt = db.InvoiceList();
            //dt.DefaultView.AllowNew = false;
            //dt.DefaultView.AllowDelete = false;
            //dt.DefaultView.AllowEdit = false;
            //listDataGrid.DataContext = dt.DefaultView;
            
            InvoiceList(dt);
           

            
        }

        private void DrukujMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ReportsWindow reports = new ReportsWindow(1, 2);
            reports.ShowDialog();
        }

        

        public void InvoiceList(DataTable dt)
        {
            List<DataRow> invoiceList = new List<DataRow>();
            var panel = new WrapPanel();
            invoiceGrid.Children.Add(panel);
            try
            {
                
                foreach (DataRow dr in dt.Rows)
                {
                    int.TryParse(dr["InvoiceID"].ToString(), out var id);
                    //invoiceList.Add(dr);
                    //panel.Children.Add(InvoiceCanvas(dr["Issue_Date"].ToString().Remove(10), dr["Client_Name"].ToString(),
                    //    dr["Gross_Value"].ToString() +" "+ dr["Currency"], dr["Invoice_Number"].ToString(), "status"));
                    panel.Children.Add(new InvoiceCanvasClass(id, dr["Issue_Date"].ToString().Remove(10), dr["Client_Name"].ToString(),
                        dr["Gross_Value"].ToString() + " " + dr["Currency"], dr["Invoice_Number"].ToString(), "status"));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

          

        }

        private void filterBtn_Click(object sender, RoutedEventArgs e)
        {
            invoiceGrid.Children.Clear();
            var dateFrom =  new DateTime();
            var dateTo = new DateTime();
            if (dateFromDate.SelectedDate == null)
            {
                dateFrom = DateTime.MinValue;
            }
            else
            {
                dateFrom = (DateTime) dateFromDate.SelectedDate;
            }

            if (dateToDate.SelectedDate == null)
            {
                dateTo = DateTime.MaxValue;
            }
            else
            {
                dateTo = (DateTime) dateToDate.SelectedDate;
            }
            var db = new DataBase();
            var dt = new DataTable();
            dt = db.InvoiceListFilter(filter1TxtBox.Text, dateFrom, dateTo,
                filter2TxtBox.Text);
            List<DataRow> invoiceList = new List<DataRow>();
            var panel = new WrapPanel();
            invoiceGrid.Children.Add(panel);
            try
            {

                foreach (DataRow dr in dt.Rows)
                {
                    int.TryParse(dr["InvoiceID"].ToString(), out var id);

                    //invoiceList.Add(dr);
                    //panel.Children.Add(InvoiceCanvas(dr["Issue_Date"].ToString().Remove(10), dr["Client_Name"].ToString(),
                    //    dr["Gross_Value"].ToString() + " " + dr["Currency"], dr["Invoice_Number"].ToString(), "status"));
                    panel.Children.Add(new InvoiceCanvasClass(id,dr["Issue_Date"].ToString().Remove(10), dr["Client_Name"].ToString(),
                        dr["Gross_Value"].ToString() + " " + dr["Currency"], dr["Invoice_Number"].ToString(), "status"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
