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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Invoice
{
    /// <summary>
    /// Logika interakcji dla klasy InvoiceView.xaml
    /// </summary>
    public partial class InvoiceView : Window
    {
        public InvoiceView(int id)
        {
            InitializeComponent();
            var db = new DataBase(); 
            var dt = db.SelectInvoicePos(id);
            var di = db.InvoiceList();
            MessageBox.Show(id.ToString());

           

            foreach (DataRow dr in dt.Rows)
                {
                    //int.TryParse(dr["InvoiceID"].ToString(), out var id_pos);
                    int index = 1;
                    //invoiceList.Add(dr);
                    //panel.Children.Add(InvoiceCanvas(dr["Issue_Date"].ToString().Remove(10), dr["Client_Name"].ToString(),
                    //    dr["Gross_Value"].ToString() +" "+ dr["Currency"], dr["Invoice_Number"].ToString(), "status"));
                    
                    positionsStack.Children.Add(new InvoicePossitionViewClass(index.ToString(), dr["Product_Name"].ToString(), dr["Product_Code"].ToString(),
                        dr["Quantity"].ToString() , dr["Unit_Of_Measure"].ToString(), dr["Net_Value"].ToString(), dr["VAT"].ToString(), dr["VAT_Value"].ToString(), dr["Gross_Value"].ToString()));
                    MessageBox.Show(dr["Product_Name"].ToString());
                    index++;
                }
            
           
            // Positions.Children.Add(new InvoicePossitionViewClass();

        }
    }
}
