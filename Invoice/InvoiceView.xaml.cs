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
        private int _id;
        private int firstLoad = 1;

        public InvoiceView(int id)
        {
            this._id = id;
            InitializeComponent();
            var db = new DataBase(); 
            var dt = db.SelectInvoicePos(id);
            var di = db.SelectInvoiceAndClient(id);
           


            

            try
            {
                foreach (DataRow dr in di.Rows)
                {
                    int.TryParse(dr["InvoiceID"].ToString(), out var id_pos);
                    int index = 1;


                    //positionsStack.Children.Add(new InvoicePossitionViewClass(id_pos, index.ToString(), dr["Product_Name"].ToString(), dr["Product_Code"].ToString(),
                    //    dr["Quantity"].ToString(), dr["Unit_Of_Measure"].ToString(), dr["Net_Value"].ToString(), dr["VAT"].ToString(), dr["VAT_Value"].ToString(), dr["Gross_Value"].ToString()));
                    clientNameTxtBox.Text = dr["Client_Name"].ToString();
                    clientAddressTxtBox.Text = dr["Client_Address_Street"].ToString() + dr["Client_Address_Pos_Number"].ToString() + dr["Client_Address_Loc_Number"].ToString();
                    ClientPostalCodeTxtBox.Text = dr["Client_Address_Postal_Code"].ToString();
                    ClientCityTxtBox.Text = dr["Client_Address_City"].ToString();
                    ClientCountryTxtBox.Text = dr["Client_Address_Country"].ToString();
                    NipTxtBox.Text = dr["NIP"].ToString();
                    TelephoneTxtBox.Text = dr["Phone_Number"].ToString();
                    EMailTxtBox.Text = dr["Email"].ToString();

                    index++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            InvoicePositionViewLoad(id);
            positionsStack.SizeChanged += PositionsStack_SizeChanged;
            
        }

        private void PositionsStack_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           // MessageBox.Show("zmiana");
            if (firstLoad == 0)
            {
                MessageBox.Show("zmiana");
                InvoicePositionViewLoad(_id);
            }
        }

        private void InvoicePositionViewLoad(int id)
        {
            var db = new DataBase();
            var dt = db.SelectInvoicePos(id);
            int index = 1;
            firstLoad = 1;
            positionsStack.Children.Clear();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int.TryParse(dr["InvoicePosID"].ToString(), out var id_pos);
                    


                    positionsStack.Children.Add(new InvoicePossitionViewClass(id_pos, index.ToString(), dr["Product_Name"].ToString(), dr["Product_Code"].ToString(),
                        dr["Quantity"].ToString(), dr["Unit_Of_Measure"].ToString(), dr["Net_Value"].ToString(), dr["VAT"].ToString(), dr["VAT_Value"].ToString(), dr["Gross_Value"].ToString()));
                   
                    index++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            firstLoad = 0;
        }
    }
}
