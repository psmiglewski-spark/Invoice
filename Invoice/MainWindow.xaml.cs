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
            
            
            FakturyDrukujMenuItem.Click += DrukujMenuItem_Click;
            //List<Student> studentList = new List<Student>();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    Student student = new Student();
            //    student.StudentId = Convert.ToInt32(dt.Rows[i]["StudentId"]);
            //    student.StudentName = dt.Rows[i]["StudentName"].ToString();
            //    student.Address = dt.Rows[i]["Address"].ToString();
            //    student.MobileNo = dt.Rows[i]["MobileNo"].ToString();
            //    studentList.Add(student);
            //}
            
            var dt = new DataTable();
            var db = new DataBase();
            filter1Lbl.Content = "Numer faktury";
            filter2Lbl.Content = "Nazwa klienta";
            dateFilterLbl.Content = "Data od:";
            dateLbl2.Content = "do:";
            dt = db.InvoiceList();
            dt.DefaultView.AllowNew = false;
            dt.DefaultView.AllowDelete = false;
            dt.DefaultView.AllowEdit = false;
            listDataGrid.DataContext = dt.DefaultView;
            InvoiceList(dt);
           

            
        }

        private void DrukujMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ReportsWindow reports = new ReportsWindow(1, 2);
            reports.ShowDialog();
        }

        public Canvas InvoiceCanvas(string issueDate, string client, string grossValue, string invoiceNr, string status)
        {
            var fv = new Canvas();
            fv.HorizontalAlignment = HorizontalAlignment.Left;
            fv.VerticalAlignment = VerticalAlignment.Top;
            fv.Height = 106;
            fv.Width = 230;
            fv.Margin = new Thickness(87, 56, 0, 0);
            fv.Background = new RadialGradientBrush(Colors.White, Colors.Gray);
            fv.Effect = new DropShadowEffect();
            var issueDateLbl = new Label();
            issueDateLbl.Content = issueDate;
            issueDateLbl.RenderTransformOrigin = new Point(0.639, -0.096);
            
            var clientLbl = new Label();
            clientLbl.Content = client;
            clientLbl.RenderTransformOrigin = new Point(-0.408, 0.846);
            clientLbl.FontSize = 16;
            clientLbl.Margin = new Thickness(13, 29, 0, 0);
            var grossLbl = new Label();
            grossLbl.Content = grossValue;
            grossLbl.RenderTransformOrigin = new Point(-0.408, 0.846);
            
            grossLbl.Margin = new Thickness(0, 67, 0, 0);
            grossLbl.FontSize = 14;
            var invoiceNrLbl = new Label();
            invoiceNrLbl.Content = invoiceNr;
            invoiceNrLbl.RenderTransformOrigin = new Point(-0.408, 0.846);
            
            invoiceNrLbl.Margin = new Thickness(120, 67, 0, 0);
            invoiceNrLbl.FontSize = 14;
            var statusLbl = new Label();
            statusLbl.Content = status;
            statusLbl.RenderTransformOrigin = new Point(0.639, -0.096);
            
            statusLbl.Margin = new Thickness(141, 0, 0, 0);
            fv.Children.Add(issueDateLbl);
            fv.Children.Add(clientLbl);
            fv.Children.Add(grossLbl);
            fv.Children.Add(invoiceNrLbl);
            fv.Children.Add(statusLbl);

            return fv;
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
                    
                    //invoiceList.Add(dr);
                    panel.Children.Add(InvoiceCanvas(dr["Issue_Date"].ToString().Remove(10), dr["Client_Name"].ToString(),
                        dr["Gross_Value"].ToString() +" "+ dr["Currency"], dr["Invoice_Number"].ToString(), "status"));
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

                    //invoiceList.Add(dr);
                    panel.Children.Add(InvoiceCanvas(dr["Issue_Date"].ToString().Remove(10), dr["Client_Name"].ToString(),
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
