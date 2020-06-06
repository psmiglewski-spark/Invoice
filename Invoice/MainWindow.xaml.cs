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
using Invoice.ViewElements;
using Microsoft.Reporting.WinForms;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using Label = System.Windows.Controls.Label;
using MessageBox = System.Windows.MessageBox;
using TextBox = System.Windows.Controls.TextBox;

namespace Invoice
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int selectedList = 1;

        Label lpLbl = new Label()
        {
            Content = "Lp.",
            Width = 27,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };

        Label clientIdLbl = new Label()
        {
            Content = "ID klienta",
            Width = 70,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };

        Label symbolLbl = new Label()
        {
            Content = "Symbol",
            Width = 120,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };

        Label nameLbl = new Label()
        {
            Content = "Nazwa firmy",
            Width = 300,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };

        Label addressLbl = new Label()
        {
            Content = "Adres",
            Width = 450,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };

        Label nipLbl = new Label()
        {
            Content = "NIP",
            Width = 160,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };

        Label phoneLbl = new Label()
        {
            Content = "Numer telefonu",
            Width = 160,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };

        TextBox lpTxtBox = new TextBox()
        {
            // Text = "Lp.",
            Width = 27,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };

        TextBox clientIdTxtBox = new TextBox()
        {
            // Text = "ID klienta",
            Width = 70,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };

        TextBox symbolTxtBox = new TextBox()
        {
            //  Text = "Symbol",
            Width = 120,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };

        TextBox nameTxtBox = new TextBox()
        {
            // Text = "Nazwa firmy",
            Width = 300,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };

        TextBox addressTxtBox = new TextBox()
        {
            //  Text = "Adres",
            Width = 450,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };

        TextBox nipTxtBox = new TextBox()
        {
            // Text = "NIP",
            Width = 160,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };

        TextBox phoneTxtBox = new TextBox()
        {
            //  Text = "Numer telefonu",
            Width = 160,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };

        WrapPanel wrapPanel = new WrapPanel();
        WrapPanel wrapPanelFilter = new WrapPanel();







       


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

            //MessageBox.Show(currency.CheckExchangeRate("EUR", DateTime.Today).ToString());
            
            
            filter1Lbl.Content = "Numer faktury";
            filter2Lbl.Content = "Nazwa klienta";
            dateFilterLbl.Content = "Data od:";
            dateLbl2.Content = "do:";
            dt = db.InvoiceList();
            wrapPanel.Margin = new Thickness(476, 295, 0, 0);
            wrapPanel.Children.Add(lpLbl);
            wrapPanel.Children.Add(clientIdLbl);
            wrapPanel.Children.Add(symbolLbl);
            wrapPanel.Children.Add(nameLbl);
            wrapPanel.Children.Add(addressLbl);
            wrapPanel.Children.Add(nipLbl);
            wrapPanel.Children.Add(phoneLbl);
            wrapPanelFilter.Margin = new Thickness(476, 315, 0, 0);
            wrapPanelFilter.Children.Add(lpTxtBox);
            wrapPanelFilter.Children.Add(clientIdTxtBox);
            wrapPanelFilter.Children.Add(symbolTxtBox);
            wrapPanelFilter.Children.Add(nameTxtBox);
            wrapPanelFilter.Children.Add(addressTxtBox);
            wrapPanelFilter.Children.Add(nipTxtBox);
            wrapPanelFilter.Children.Add(phoneTxtBox);
            
            //dt.DefaultView.AllowNew = false;
            //dt.DefaultView.AllowDelete = false;
            //dt.DefaultView.AllowEdit = false;
            //listDataGrid.DataContext = dt.DefaultView;
            this.GotFocus += MainWindow_GotFocus;
            InvoiceList(dt);
            lpTxtBox.IsEnabled = false;
            clientIdTxtBox.TextChanged += ClientIdTxtBox_TextChanged;
            symbolTxtBox.TextChanged += SymbolTxtBox_TextChanged;
            nameTxtBox.TextChanged += NameTxtBox_TextChanged;
            addressTxtBox.TextChanged += AddressTxtBox_TextChanged;
            nipTxtBox.TextChanged += NipTxtBox_TextChanged;
            phoneTxtBox.TextChanged += PhoneTxtBox_TextChanged;
            
        }

        private void PhoneTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            selectedList = 2;
            invoiceGrid.Children.Clear();
            var db = new DataBase();
            var index = 1;
            int.TryParse(clientIdTxtBox.Text, out var idClient);
            
            var dt = db.ClientListFiltered(idClient, symbolTxtBox.Text, nameTxtBox.Text, addressTxtBox.Text,
                addressTxtBox.Text, addressTxtBox.Text, addressTxtBox.Text, addressTxtBox.Text, nipTxtBox.Text,
                phoneTxtBox.Text);
            try
            {

                foreach (DataRow dr in dt.Rows)
                {
                    int.TryParse(dr["ClientId"].ToString(), out var id);
                    string _address = dr["Address_Street"] + " " + dr["Address_Pos_Number"] + " " +
                                      dr["Address_Loc_Number"] + ", " +
                                      dr["Address_Postal_Code"] + " " + dr["Address_City"];
                    invoiceGrid.Children.Add(new ClientListClass(index, id, dr["Short_Name"].ToString(),
                        dr["Name"].ToString(), _address, dr["nip"].ToString(), dr["Phone_Number"].ToString()));
                    //invoiceList.Add(dr);
                    //panel.Children.Add(InvoiceCanvas(dr["Issue_Date"].ToString().Remove(10), dr["Client_Name"].ToString(),
                    //    dr["Gross_Value"].ToString() +" "+ dr["Currency"], dr["Invoice_Number"].ToString(), "status"));
                    index++;
                }
            }
            catch (Exception fe)
            {
                Console.WriteLine(fe);
                throw;
            }
        }

        private void NipTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            selectedList = 2;
            invoiceGrid.Children.Clear();
            var db = new DataBase();
            var index = 1;
            int.TryParse(clientIdTxtBox.Text, out var idClient);

            var dt = db.ClientListFiltered(idClient, symbolTxtBox.Text, nameTxtBox.Text, addressTxtBox.Text,
                addressTxtBox.Text, addressTxtBox.Text, addressTxtBox.Text, addressTxtBox.Text, nipTxtBox.Text,
                phoneTxtBox.Text);
            try
            {

                foreach (DataRow dr in dt.Rows)
                {
                    int.TryParse(dr["ClientId"].ToString(), out var id);
                    string _address = dr["Address_Street"] + " " + dr["Address_Pos_Number"] + " " +
                                      dr["Address_Loc_Number"] + ", " +
                                      dr["Address_Postal_Code"] + " " + dr["Address_City"];
                    invoiceGrid.Children.Add(new ClientListClass(index, id, dr["Short_Name"].ToString(),
                        dr["Name"].ToString(), _address, dr["nip"].ToString(), dr["Phone_Number"].ToString()));
                    //invoiceList.Add(dr);
                    //panel.Children.Add(InvoiceCanvas(dr["Issue_Date"].ToString().Remove(10), dr["Client_Name"].ToString(),
                    //    dr["Gross_Value"].ToString() +" "+ dr["Currency"], dr["Invoice_Number"].ToString(), "status"));
                    index++;
                }
            }
            catch (Exception fe)
            {
                Console.WriteLine(fe);
                throw;
            }
        }

        private void AddressTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            selectedList = 2;
            invoiceGrid.Children.Clear();
            var db = new DataBase();
            var index = 1;
            int.TryParse(clientIdTxtBox.Text, out var idClient);

            var dt = db.ClientListFiltered(idClient, symbolTxtBox.Text, nameTxtBox.Text, addressTxtBox.Text,
                addressTxtBox.Text, addressTxtBox.Text, addressTxtBox.Text, addressTxtBox.Text, nipTxtBox.Text,
                phoneTxtBox.Text);
            try
            {

                foreach (DataRow dr in dt.Rows)
                {
                    int.TryParse(dr["ClientId"].ToString(), out var id);
                    string _address = dr["Address_Street"] + " " + dr["Address_Pos_Number"] + " " +
                                      dr["Address_Loc_Number"] + ", " +
                                      dr["Address_Postal_Code"] + " " + dr["Address_City"];
                    invoiceGrid.Children.Add(new ClientListClass(index, id, dr["Short_Name"].ToString(),
                        dr["Name"].ToString(), _address, dr["nip"].ToString(), dr["Phone_Number"].ToString()));
                    //invoiceList.Add(dr);
                    //panel.Children.Add(InvoiceCanvas(dr["Issue_Date"].ToString().Remove(10), dr["Client_Name"].ToString(),
                    //    dr["Gross_Value"].ToString() +" "+ dr["Currency"], dr["Invoice_Number"].ToString(), "status"));
                    index++;
                }
            }
            catch (Exception fe)
            {
                Console.WriteLine(fe);
                throw;
            }
        }

        private void NameTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            selectedList = 2;
            invoiceGrid.Children.Clear();
            var db = new DataBase();
            var index = 1;
            int.TryParse(clientIdTxtBox.Text, out var idClient);

            var dt = db.ClientListFiltered(idClient, symbolTxtBox.Text, nameTxtBox.Text, addressTxtBox.Text,
                addressTxtBox.Text, addressTxtBox.Text, addressTxtBox.Text, addressTxtBox.Text, nipTxtBox.Text,
                phoneTxtBox.Text);
            try
            {

                foreach (DataRow dr in dt.Rows)
                {
                    int.TryParse(dr["ClientId"].ToString(), out var id);
                    string _address = dr["Address_Street"] + " " + dr["Address_Pos_Number"] + " " +
                                      dr["Address_Loc_Number"] + ", " +
                                      dr["Address_Postal_Code"] + " " + dr["Address_City"];
                    invoiceGrid.Children.Add(new ClientListClass(index, id, dr["Short_Name"].ToString(),
                        dr["Name"].ToString(), _address, dr["nip"].ToString(), dr["Phone_Number"].ToString()));
                    //invoiceList.Add(dr);
                    //panel.Children.Add(InvoiceCanvas(dr["Issue_Date"].ToString().Remove(10), dr["Client_Name"].ToString(),
                    //    dr["Gross_Value"].ToString() +" "+ dr["Currency"], dr["Invoice_Number"].ToString(), "status"));
                    index++;
                }
            }
            catch (Exception fe)
            {
                Console.WriteLine(fe);
                throw;
            }
        }

        private void SymbolTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            selectedList = 2;
            invoiceGrid.Children.Clear();
            var db = new DataBase();
            var index = 1;
            int.TryParse(clientIdTxtBox.Text, out var idClient);

            var dt = db.ClientListFiltered(idClient, symbolTxtBox.Text, nameTxtBox.Text, addressTxtBox.Text,
                addressTxtBox.Text, addressTxtBox.Text, addressTxtBox.Text, addressTxtBox.Text, nipTxtBox.Text,
                phoneTxtBox.Text);
            try
            {

                foreach (DataRow dr in dt.Rows)
                {
                    int.TryParse(dr["ClientId"].ToString(), out var id);
                    string _address = dr["Address_Street"] + " " + dr["Address_Pos_Number"] + " " +
                                      dr["Address_Loc_Number"] + ", " +
                                      dr["Address_Postal_Code"] + " " + dr["Address_City"];
                    invoiceGrid.Children.Add(new ClientListClass(index, id, dr["Short_Name"].ToString(),
                        dr["Name"].ToString(), _address, dr["nip"].ToString(), dr["Phone_Number"].ToString()));
                    //invoiceList.Add(dr);
                    //panel.Children.Add(InvoiceCanvas(dr["Issue_Date"].ToString().Remove(10), dr["Client_Name"].ToString(),
                    //    dr["Gross_Value"].ToString() +" "+ dr["Currency"], dr["Invoice_Number"].ToString(), "status"));
                    index++;
                }
            }
            catch (Exception fe)
            {
                Console.WriteLine(fe);
                throw;
            }
        }

        private void ClientIdTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            selectedList = 2;
            invoiceGrid.Children.Clear();
            var db = new DataBase();
            var index = 1;
            int.TryParse(clientIdTxtBox.Text, out var idClient);

            var dt = db.ClientListFiltered(idClient, symbolTxtBox.Text, nameTxtBox.Text, addressTxtBox.Text,
                addressTxtBox.Text, addressTxtBox.Text, addressTxtBox.Text, addressTxtBox.Text, nipTxtBox.Text,
                phoneTxtBox.Text);
            try
            {

                foreach (DataRow dr in dt.Rows)
                {
                    int.TryParse(dr["ClientId"].ToString(), out var id);
                    string _address = dr["Address_Street"] + " " + dr["Address_Pos_Number"] + " " +
                                      dr["Address_Loc_Number"] + ", " +
                                      dr["Address_Postal_Code"] + " " + dr["Address_City"];
                    invoiceGrid.Children.Add(new ClientListClass(index, id, dr["Short_Name"].ToString(),
                        dr["Name"].ToString(), _address, dr["nip"].ToString(), dr["Phone_Number"].ToString()));
                    //invoiceList.Add(dr);
                    //panel.Children.Add(InvoiceCanvas(dr["Issue_Date"].ToString().Remove(10), dr["Client_Name"].ToString(),
                    //    dr["Gross_Value"].ToString() +" "+ dr["Currency"], dr["Invoice_Number"].ToString(), "status"));
                    index++;
                }
            }
            catch (Exception fe)
            {
                Console.WriteLine(fe);
                throw;
            }
        }

       

        private void MainWindow_GotFocus(object sender, RoutedEventArgs e)
        {
            if (selectedList == 1)
            {
               
                InvoiceFilter();
            }
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

        public void ClientList()
        {
            var clientListView = new ClientListView();
            var index = 1;
            var db = new DataBase();
            var dc = db.ClientList();
            invoiceGrid.Children.Clear();
            filterGrid.Children.Clear();
            filterGrid.Children.Add(mainLabel); 
            filterGrid.Children.Add(wrapPanel);
            filterGrid.Children.Add(wrapPanelFilter);
            

            try
            {

                foreach (DataRow dr in dc.Rows)
                {
                    int.TryParse(dr["ClientId"].ToString(), out var id);
                    string _address = dr["Address_Street"] + " " + dr["Address_Pos_Number"] + " " +
                                      dr["Address_Loc_Number"] + ", " +
                                      dr["Address_Postal_Code"] + " " + dr["Address_City"];
                    invoiceGrid.Children.Add(new ClientListClass(index, id, dr["Short_Name"].ToString(),
                        dr["Name"].ToString(), _address, dr["nip"].ToString(), dr["Phone_Number"].ToString()));
                    //invoiceList.Add(dr);
                    //panel.Children.Add(InvoiceCanvas(dr["Issue_Date"].ToString().Remove(10), dr["Client_Name"].ToString(),
                    //    dr["Gross_Value"].ToString() +" "+ dr["Currency"], dr["Invoice_Number"].ToString(), "status"));
                    index++;
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
            
            
            InvoiceFilter();
        }

        private void InvoiceFilter()
        {
            invoiceGrid.Children.Clear();
            var dateFrom = new DateTime();
            var dateTo = new DateTime();
            if (dateFromDate.SelectedDate == null)
            {
                dateFrom = DateTime.MinValue;
            }
            else
            {
                dateFrom = (DateTime)dateFromDate.SelectedDate;
            }

            if (dateToDate.SelectedDate == null)
            {
                dateTo = DateTime.MaxValue;
            }
            else
            {
                dateTo = (DateTime)dateToDate.SelectedDate;
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
                    float.TryParse(dr["Gross_Value"].ToString(), out var grossValue);

                    //invoiceList.Add(dr);
                    //panel.Children.Add(InvoiceCanvas(dr["Issue_Date"].ToString().Remove(10), dr["Client_Name"].ToString(),
                    //    dr["Gross_Value"].ToString() + " " + dr["Currency"], dr["Invoice_Number"].ToString(), "status"));
                    panel.Children.Add(new InvoiceCanvasClass(id, dr["Issue_Date"].ToString().Remove(10), dr["Client_Name"].ToString(),
                        grossValue.ToString("F") + " " + dr["Currency"], dr["Invoice_Number"].ToString(), "status"));
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

        private void fakturyListBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedList = 1;
            filterGrid.Children.Clear();
            filterGrid.Children.Add(filter2TxtBox);
            filterGrid.Children.Add(filter2Lbl);
            filterGrid.Children.Add(filter1TxtBox);
            filterGrid.Children.Add(filter1Lbl);
            filterGrid.Children.Add(dateToDate);
            filterGrid.Children.Add(dateFilterLbl);
            filterGrid.Children.Add(dateFromDate);
            filterGrid.Children.Add(filterBtn);
            filterGrid.Children.Add(mainLabel);
            filterGrid.Children.Add(dateLbl2);

            var db = new DataBase();
            var dt = db.InvoiceList();
            InvoiceList(dt);
        }

        private void KontrahenciListBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedList = 2;
            invoiceGrid.Children.Clear();
            ClientList();
            //var db = new DataBase();
            //var dt = db.InvoiceList();
            //InvoiceList(dt);
        }
    }
}
