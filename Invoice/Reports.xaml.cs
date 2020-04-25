using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Reporting.WinForms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Invoice
{
    /// <summary>
    /// Logika interakcji dla klasy Reports.xaml
    /// </summary>
    public partial class Reports : Window
    {
        //konstruktor wydruku faktury
        public Reports(int issuingId, int invoiceId)
        {
            
            InitializeComponent();
           // invoiceReport(issuingId,invoiceId);
            invoiceReportStd(issuingId,invoiceId);
                    
        }

        //public void invoiceReport(int issuingId, int invoiceId)
        //{
        //    DateTime value = new DateTime(2020, 3, 18);
        //    var data = new DataBase();
        //    Client klient = new Client();


        //    try
        //    {
        //        Report1.Reset();
        //        var db = new DataBase();
        //        var ds = db.SelectClient(issuingId);
        //        var di = db.SelectInvoice(invoiceId);
        //        var dp = db.SelectInvoicePos(invoiceId);
        //        klient.CheckWl("6972171117", "2020-03-30");
        //        var clientReportDataSource = new ReportDataSource("Client", ds);
        //        var invoiceReportDataSource = new ReportDataSource("Invoice", di);
        //        var invoicePosReportDataSource = new ReportDataSource("Invoice_pos", dp);
        //        Report1.LocalReport.ReportEmbeddedResource = "Invoice.PL_VAT_Invoice.rdlc";
        //        Report1.LocalReport.DataSources.Add(clientReportDataSource);
        //        Report1.LocalReport.DataSources.Add(invoiceReportDataSource);
        //        Report1.LocalReport.DataSources.Add(invoicePosReportDataSource);
        //        Report1.RefreshReport();
        //        var dataBase = new DataBase();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.ToString());
        //    }
        //}

        public void invoiceReportStd(int issuingId, int invoiceId)
        {
            
            var data = new DataBase();
            Client klient = new Client();


            try
            {
                Report1.Reset();
                var db = new DataBase();
                var ds = db.SelectClient(issuingId);
                var di = db.SelectInvoice(invoiceId);
                var dp = db.SelectInvoicePos(invoiceId);
               // klient.CheckWl("6972171117", "2020-03-30");
                var clientReportDataSource = new ReportDataSource("Client", ds);
                var invoiceReportDataSource = new ReportDataSource("Invoice", di);
                var invoicePosReportDataSource = new ReportDataSource("Invoice_pos", dp);
                Report1.LocalReport.ReportPath = Directory.GetCurrentDirectory() + @"\PrintReports\Invoice\PL_VAT_Invoice_std.rdlc";
                Report1.LocalReport.DataSources.Add(clientReportDataSource);
                Report1.LocalReport.DataSources.Add(invoiceReportDataSource);
                Report1.LocalReport.DataSources.Add(invoicePosReportDataSource);
                Report1.RefreshReport();
                var dataBase = new DataBase();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

    }
}
