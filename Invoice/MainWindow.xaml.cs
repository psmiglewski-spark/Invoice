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
using MessageBox = System.Windows.MessageBox;

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
            // client.CheckWl("6972171117","2020-04-30");
            var dt = new DataTable();
            var db = new DataBase();
            FakturyDrukujMenuItem.Click += DrukujMenuItem_Click;
            CurrencyTable currency = new CurrencyTable();
            var listaWalut = currency.Currencies();
            
            //foreach (var waluta in listaWalut)
            //{
            //    db.InsertCurrencyList(waluta.currency,waluta.code,"");
            //}

            MessageBox.Show(currency.CheckExchangeRate("EUR", DateTime.Today).ToString());
            
            
            filter1Lbl.Content = "Numer faktury";
            filter2Lbl.Content = "Nazwa klienta";
            dateFilterLbl.Content = "Data od:";
            dateLbl2.Content = "do:";
            dt = db.InvoiceList();
           
            //dt.DefaultView.AllowNew = false;
            //dt.DefaultView.AllowDelete = false;
            //dt.DefaultView.AllowEdit = false;
            //listDataGrid.DataContext = dt.DefaultView;
            this.GotFocus += MainWindow_GotFocus;
            InvoiceList(dt);
           

            
        }

        private void MainWindow_GotFocus(object sender, RoutedEventArgs e)
        {
            var db = new DataBase();
            var dt = db.InvoiceList();
            InvoiceList(dt);
        }

        private void DrukujMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ReportsWindow reports = new ReportsWindow(4, 1);
            reports.ShowDialog();
        }

        

        public void InvoiceList(DataTable dt)
        {
            List<DataRow> invoiceList = new List<DataRow>();
            var panel = new WrapPanel();
            invoiceGrid.Children.Clear();
            invoiceGrid.Children.Add(panel);
            try
            {
                
                foreach (DataRow dr in dt.Rows)
                {
                    int.TryParse(dr["InvoiceID"].ToString(), out var id);
                    float.TryParse(dr["Gross_Value"].ToString(), out var grossValue);
                    //invoiceList.Add(dr);
                    //panel.Children.Add(InvoiceCanvas(dr["Issue_Date"].ToString().Remove(10), dr["Client_Name"].ToString(),
                    //    dr["Gross_Value"].ToString() +" "+ dr["Currency"], dr["Invoice_Number"].ToString(), "status"));
                    panel.Children.Add(new InvoiceCanvasClass(id, dr["Issue_Date"].ToString().Remove(10), dr["Client_Name"].ToString(),
                        grossValue.ToString("F") + " " + dr["Currency"], dr["Invoice_Number"].ToString(), "status"));
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

        private void FakturyAddMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var db = new DataBase();
            db.InsertInvoice("new", 0, " ", " ", " ", " ", " ", " ", " ", " ", DateTime.Today, DateTime.Today, DateTime.Today, " ", " ", 1, " ", 0f, 0f, 0, 0f, " ", " ", 1f, " ", " ");
            try
            {
                var did = db.SelectInvoiceId("new");
                int.TryParse(did.Rows[0]["InvoiceID"].ToString(), out var invoiceIdResult);
                int _id = invoiceIdResult;
                var invoice = new InvoiceView(_id);
                invoice.ShowDialog();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                
            }
           
            
            // MessageBox.Show(this._id.ToString());
            
        }
    }
}
