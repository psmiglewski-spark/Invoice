using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Reporting.WinForms;
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
            //    float kwotaDec = 12453.99f;
            //    int zlote = (int)kwotaDec;
            //    int grosze = (int)(100 * kwotaDec) % 100;
            //    MessageBox.Show(String.Format("{0} {1}, {2} {3}",
            //    KwotaSlownie.LiczbaSlownie(zlote),
            //    KwotaSlownie.WalutaSlownie(zlote, "PLN"),
            //    KwotaSlownie.LiczbaSlownie(grosze),
            //    KwotaSlownie.WalutaSlownie(grosze, ".PLN")));
            //////osiemset pięćdziesiąt dwa złote, dziewięćdziesiąt cztery grosze
            
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
            var ListaFaktur = new List<InvoiceClass>();

            dt = db.SelectAllInvoices();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var invoice = new InvoiceClass();
                var label = new Label();
                invoice.Invoice_Number = dt.Rows[i]["Invoice_Number"].ToString();
                   // invoice.Invoice_Number = dt.Rows[i]["Invoice_Number"].ToString();
               // invoice.ID_Client = (int) dt.Rows[i]["ID_Client"];
               // invoice.Client_Name = dt.Rows[i]["Client_Name"].ToString(); 
                //dt.Rows[i]["Client_NIP"].ToString(), 
                //dt.Rows[i]["Client_Address_Street"].ToString(), 
                //dt.Rows[i]["Client_Address_Pos_Number"].ToString(), 
                //dt.Rows[i]["Client_Address_Loc_Number"].ToString(), 
                //dt.Rows[i]["Client_Address_Postal_Code"].ToString(), 
                //dt.Rows[i]["Client_Address_City"].ToString(), 
                //dt.Rows[i]["Client_Address_Country"].ToString(), 
                //(DateTime)dt.Rows[i]["Issue_Date"], 
                //(DateTime)dt.Rows[i]["Sale_Date"], 
                //(DateTime)dt.Rows[i]["Payment_Date"], 
                //dt.Rows[i]["Payment_Method"].ToString(), 
                //dt.Rows[i]["Payment_Account"].ToString(), 
                //(int)dt.Rows[i]["SplitPayment"], 
                //dt.Rows[i]["Note"].ToString(), 
                //(float)dt.Rows[i]["Net_Value"], 
                //(float)dt.Rows[i]["Gross_Value"], 
                //(float)dt.Rows[i]["VAT_Value"], 
                //(int)dt.Rows[i]["VAT"], 
                //dt.Rows[i]["Issuing_User"].ToString(), 
                //dt.Rows[i]["Currency"].ToString(), 
                //(float)dt.Rows[i]["Currency_Change_Rate"], 
                //dt.Rows[i]["KwotaSlownie"].ToString(), 
                //dt.Rows[i]["VAT_Account"].ToString()
                ListaFaktur.Add(invoice);
            }

            
            


        }

        private void DrukujMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ReportsWindow reports = new ReportsWindow(1, 1);
            reports.ShowDialog();
        }

       
    }
}
