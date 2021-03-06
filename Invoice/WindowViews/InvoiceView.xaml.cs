﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
using System.Windows.Shapes;
using Button = System.Windows.Controls.Button;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using Label = System.Windows.Controls.Label;
using MessageBox = System.Windows.MessageBox;

namespace Invoice
{
    /// <summary>
    /// Logika interakcji dla klasy InvoiceView.xaml
    /// </summary>
    public partial class InvoiceView : Window
    {
        private int _id;
        

        WrapPanel sumPanel = new WrapPanel
        {
            HorizontalAlignment = HorizontalAlignment.Left,
            Height = 28,
            VerticalAlignment = VerticalAlignment.Top,
            Width = 755,
            RenderTransformOrigin = new Point(0.525, 0.506)
        };




        public InvoiceView(int id)
        {
            this._id = id;
            InitializeComponent();

            splitPaymentAccountLbl.Visibility = Visibility.Hidden;
            splitPaymentAccountCBox.Visibility = Visibility.Hidden;
            splitPaymentCheckBox.Checked += SplitPaymentCheckBox_Checked;
            splitPaymentCheckBox.Unchecked += SplitPaymentCheckBox_Unchecked;
            InvoiceClientViewLoad(_id);
            InvoicePositionViewLoad(_id);
            paymentStatusBtn.Background = new SolidColorBrush(Colors.Red);
            var paymentStatus = CheckPayment(id);
            switch (paymentStatus)
            {
                case 0:
                {
                    paymentStatusBtn.Background = new SolidColorBrush(Colors.Red);
                    paymentStatusBtn.Content = "Nie zapłacona";
                    paymentStatusBtn.FontSize = 10;
                    break;
                }
                case 1:
                {
                    paymentStatusBtn.Background = new SolidColorBrush(Colors.Yellow);
                    paymentStatusBtn.Content = "Częściowo zapłacona";
                    break;
                }
                case 2:
                {
                    paymentStatusBtn.Background = new SolidColorBrush(Colors.GreenYellow);
                    paymentStatusBtn.Content = "Zapłacona";
                    paymentStatusBtn.FontSize = 10;
                    break;
                }
                case 3:
                {
                    paymentStatusBtn.Background = new SolidColorBrush(Colors.DeepPink);
                    paymentStatusBtn.Content = "Nadpłacona";
                    paymentStatusBtn.FontSize = 10;
                    break;
                }
            }
            PaymentValueViewLoad(_id);
            paymentTab.PreviewGotKeyboardFocus += PaymentTab_PreviewGotKeyboardFocus;
            


        }

      

        private void PaymentTab_PreviewGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var paymentStatus = CheckPayment(_id);
            switch (paymentStatus)
            {
                case 0:
                {
                    paymentStatusBtn.Background = new SolidColorBrush(Colors.Red);
                    paymentStatusBtn.Content = "Nie zapłacona";
                    paymentStatusBtn.FontSize = 10;
                    break;
                }
                case 1:
                {
                    paymentStatusBtn.Background = new SolidColorBrush(Colors.Yellow);
                    paymentStatusBtn.Content = "Częściowo zapłacona";
                    break;
                }
                case 2:
                {
                    paymentStatusBtn.Background = new SolidColorBrush(Colors.GreenYellow);
                    paymentStatusBtn.Content = "Zapłacona";
                    paymentStatusBtn.FontSize = 10;
                    break;
                }
                case 3:
                {
                    paymentStatusBtn.Background = new SolidColorBrush(Colors.DeepPink);
                    paymentStatusBtn.Content = "Nadpłacona";
                    paymentStatusBtn.FontSize = 10;
                    break;
                }
            }
            PaymentValueViewLoad(_id);
        }

      

        private void SplitPaymentCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            splitPaymentAccountLbl.Visibility = Visibility.Hidden;
            splitPaymentAccountCBox.Visibility = Visibility.Hidden;
        }

        private void SplitPaymentCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            splitPaymentAccountLbl.Visibility = Visibility.Visible;
            splitPaymentAccountCBox.Visibility = Visibility.Visible;
        }

        private void InvoiceClientViewLoad(int id)
        {
            var db = new DataBase();
            var di = db.SelectInvoiceAndClient(id);
            var dcurrency = db.SelectCurrencyCodeTable();
            var dc = db.SelectOwnCompany();
            var dp = db.SelectPaymentMethod();
            var paymentMethodsList = new List<string>();
            var accountNumberList = new List<string>();
            var vatAccountNumberList = new List<string>();
            var currencyCodeList = new List<string>();
            try
            {
                foreach (DataRow dr in dp.Rows)
                {
                    paymentMethodsList.Add(dr["Payment_Method_Name"].ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }
            try
            {
                foreach (DataRow dr in dcurrency.Rows)
                {
                    currencyCodeList.Add(dr["Currency_Code"].ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }

            try
            {
                foreach (DataRow dr in dc.Rows)
                {
                    accountNumberList.Add(dr["Account_Number"].ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }

            try
            {
                foreach (DataRow dr in dc.Rows)
                {
                    vatAccountNumberList.Add(dr["Vat_Account"].ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            try
            {
                var issueDate = new DateTime();
                var saleDate = new DateTime();
                var paymentDate = new DateTime();
                DateTime.TryParse(di.Rows[0]["Issue_Date"].ToString(), out issueDate);
                DateTime.TryParse(di.Rows[0]["Sale_Date"].ToString(), out saleDate);
                DateTime.TryParse(di.Rows[0]["Payment_Date"].ToString(), out paymentDate);
                clientNameTxtBox.Text = di.Rows[0]["Client_Name"].ToString();
                clientNameTxtBox.DropDownOpened += ClientNameTxtBox_DropDownOpened;
                clientAddressTxtBox.Text = di.Rows[0]["Client_Address_Street"].ToString();
                clientAddressPosNumberTxtBox.Text = di.Rows[0]["Client_Address_Pos_Number"].ToString();
                clientAddressLocNumberTxtBox.Text = di.Rows[0]["Client_Address_Loc_Number"].ToString();
                ClientPostalCodeTxtBox.Text = di.Rows[0]["Client_Address_Postal_Code"].ToString();
                ClientCityTxtBox.Text = di.Rows[0]["Client_Address_City"].ToString();
                ClientCountryTxtBox.Text = di.Rows[0]["Client_Address_Country"].ToString();
                NipTxtBox.Text = di.Rows[0]["NIP"].ToString();
                TelephoneTxtBox.Text = di.Rows[0]["Phone_Number"].ToString();
                EMailTxtBox.Text = di.Rows[0]["Email"].ToString();
                invoiceNumberTxtBox.Text = di.Rows[0]["Invoice_Number"].ToString();
                clientIdTxtBox.Text = di.Rows[0]["ID_Client"].ToString();
                clientIdTxtBox.TextChanged += ClientIdTxtBox_TextChanged;
                noteTxtBox.Text = di.Rows[0]["Note"].ToString();
                issuingUserNameLbl.Content = di.Rows[0]["Issuing_User"].ToString();
                issuingDateDatePick.SelectedDate = issueDate;
                sellDateDatePick.SelectedDate = saleDate;
                paymentDateDatePick.SelectedDate = paymentDate;
                paymentMethodCBox.ItemsSource = paymentMethodsList;
                paymentMethodCBox.SelectedItem = di.Rows[0]["Payment_Method"].ToString();
                accountNumberCBox.ItemsSource = accountNumberList;
                splitPaymentAccountCBox.ItemsSource = vatAccountNumberList;
                accountNumberCBox.SelectedItem = di.Rows[0]["Payment_Account"].ToString();
                splitPaymentAccountCBox.SelectedItem = di.Rows[0]["Vat_Account"].ToString();
                currencyCBox.ItemsSource = currencyCodeList;
                currencyCBox.SelectedItem = di.Rows[0]["Currency"].ToString();
                if (di.Rows[0]["Currency"].ToString() == " ")
                {
                    currencyCBox.SelectedItem = "PLN";
                }
                if ((int) di.Rows[0]["SplitPayment"] == 1)
                {
                    splitPaymentCheckBox.IsChecked = true;

                }

                                
                clientNameTxtBox.SelectionChanged += ClientNameTxtBox_SelectionChanged;
                
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void ClientIdTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var db = new DataBase();
            int _clientId = -1;
            string _client;
            int.TryParse(clientIdTxtBox.Text, out var _resultid);

            if (_resultid == -1)
            {
                _clientId = -1;
            }
            else
            {

                _clientId = _resultid;
            }

            var dt = db.ClientById(_clientId);
            try
            {
              _client = clientNameTxtBox.Text = dt.Rows[0]["Name"].ToString();
            }
            catch (Exception exception)
            {
              //  MessageBox.Show(exception.ToString());
                _clientId = -1;
            }
            




            
            if (_clientId == -1)
            {
                clientNameTxtBox.Text = "";
                clientAddressTxtBox.Text = "";
                clientAddressPosNumberTxtBox.Text = "";
                clientAddressLocNumberTxtBox.Text = "";
                ClientPostalCodeTxtBox.Text = "";
                ClientCityTxtBox.Text = "";
                ClientCountryTxtBox.Text = "";
                NipTxtBox.Text = "";
                TelephoneTxtBox.Text = "";
                EMailTxtBox.Text = "";
                //clientIdTxtBox.Text = "";
            }
            //int.TryParse(dt.Rows[0]["ClientId"].ToString(), out var res);
            else
            {
                try
                {
                    // System.Windows.Forms.MessageBox.Show(dt.Rows[0]["ClientId"].ToString())
                    clientNameTxtBox.Text = dt.Rows[0]["Name"].ToString();
                    clientAddressTxtBox.Text = dt.Rows[0]["Address_Street"].ToString();
                    clientAddressPosNumberTxtBox.Text = dt.Rows[0]["Address_Pos_Number"].ToString();
                    clientAddressLocNumberTxtBox.Text = dt.Rows[0]["Address_Loc_Number"].ToString();
                    ClientPostalCodeTxtBox.Text = dt.Rows[0]["Address_Postal_Code"].ToString();
                    ClientCityTxtBox.Text = dt.Rows[0]["Address_City"].ToString();
                    ClientCountryTxtBox.Text = dt.Rows[0]["Address_Country"].ToString();
                    NipTxtBox.Text = dt.Rows[0]["NIP"].ToString();
                    TelephoneTxtBox.Text = dt.Rows[0]["Phone_Number"].ToString();
                    EMailTxtBox.Text = dt.Rows[0]["Email"].ToString();
                   // clientIdTxtBox.Text = dt.Rows[0]["ClientId"].ToString();
                }
                catch (Exception exception)
                {
                    //  //  Console.WriteLine(exception);
                    System.Windows.Forms.MessageBox.Show(exception.ToString());
                }
            }
        }

        private void ClientNameTxtBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var db = new DataBase();
            string _client = " ";
            
            if (clientNameTxtBox.SelectedValue == null)
            {
                _client = " ";
            }
            else
            {
                _client = clientNameTxtBox.SelectedValue.ToString();
            }
           

          
            
            var dt = db.ClientByName(_client);
            if (_client == " ")
            {
                clientAddressTxtBox.Text = "";
                clientAddressPosNumberTxtBox.Text = "";
                clientAddressLocNumberTxtBox.Text = "";
                ClientPostalCodeTxtBox.Text = "";
                ClientCityTxtBox.Text = "";
                ClientCountryTxtBox.Text = "";
                NipTxtBox.Text = "";
                TelephoneTxtBox.Text = "";
                EMailTxtBox.Text = "";
                clientIdTxtBox.Text = "";
            }
            //int.TryParse(dt.Rows[0]["ClientId"].ToString(), out var res);
            else
            {
                try
                {
                   // System.Windows.Forms.MessageBox.Show(dt.Rows[0]["ClientId"].ToString())
                    clientAddressTxtBox.Text = dt.Rows[0]["Address_Street"].ToString();
                    clientAddressPosNumberTxtBox.Text = dt.Rows[0]["Address_Pos_Number"].ToString();
                    clientAddressLocNumberTxtBox.Text = dt.Rows[0]["Address_Loc_Number"].ToString();
                    ClientPostalCodeTxtBox.Text = dt.Rows[0]["Address_Postal_Code"].ToString();
                    ClientCityTxtBox.Text = dt.Rows[0]["Address_City"].ToString();
                    ClientCountryTxtBox.Text = dt.Rows[0]["Address_Country"].ToString();
                    NipTxtBox.Text = dt.Rows[0]["NIP"].ToString();
                    TelephoneTxtBox.Text = dt.Rows[0]["Phone_Number"].ToString();
                    EMailTxtBox.Text = dt.Rows[0]["Email"].ToString();
                    clientIdTxtBox.Text = dt.Rows[0]["ClientId"].ToString();
                }
                catch (Exception exception)
                {
                    //  //  Console.WriteLine(exception);
                    System.Windows.Forms.MessageBox.Show(exception.ToString());
                }
            }

        }

        private void ClientNameTxtBox_DropDownOpened(object sender, EventArgs e)
        {
            var db = new DataBase();
            var dt = db.ClientListFilteredName(clientNameTxtBox.Text);
            var clientList = new List<string>(); 
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    clientList.Add(dr["Name"].ToString());
                }
            }
            catch (Exception cliente)
            {
                MessageBox.Show(cliente.ToString());
            }

            clientNameTxtBox.ItemsSource = clientList;
        }

        private void InvoicePositionViewLoad(int id)
        {
            var db = new DataBase();
            var dt = db.SelectInvoicePos(id);
            int index = 1;
            float sumNetValue = 0;
            float sumVatValue = 0;
            float sumGrossValue = 0;

            positionsStack.Children.Clear();
            WrapPanel _sumpanel = new WrapPanel();
            WrapPanel panel = new WrapPanel
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                Height = 28,
                VerticalAlignment = VerticalAlignment.Top,
                Width = 755,
                RenderTransformOrigin = new Point(0.525, 0.506)
            };
            Label lpLabel = new Label
            {
                Content = "Lp.",
                Width = 27,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(1)
            };
            Label productNameLabel = new Label
            {
                Content = "Nazwa produktu/usługi",
                Width = 127,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(1)
            };
            Label productCodeLabel = new Label
            {
                Content = "PKWiU",
                Width = 50,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(1)
            };
            Label quantityLabel = new Label
            {
                Content = "Ilość",
                Width = 40,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(1)
            };
            Label unitMeasureLabel = new Label
            {
                Content = "j.m.",
                Width = 30,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(1)
            };
            Label netValueLabel = new Label
            {
                Content = "Wartość netto",
                Width = 90,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(1)
            };
            Label vatLabel = new Label
            {
                Content = "VAT",
                Width = 35,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(1)
            };
            Label vatValueLabel = new Label
            {
                Content = "Warość VAT",
                Width = 90,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(1)
            };
            Label grossValueLabel = new Label
            {
                Content = "Wartosć brutto",
                Width = 95,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(1)
            };
            Button addButton = new Button
            {
                RenderTransformOrigin = new Point(0.392, 0.167),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 20,
                Height = 20,
                Content = "+"
            };
            panel.Children.Add(lpLabel);
            panel.Children.Add(productNameLabel);
            panel.Children.Add(productCodeLabel);
            panel.Children.Add(quantityLabel);
            panel.Children.Add(unitMeasureLabel);
            panel.Children.Add(netValueLabel);
            panel.Children.Add(vatLabel);
            panel.Children.Add(vatValueLabel);
            panel.Children.Add(grossValueLabel);
            panel.Children.Add(addButton);
            addButton.Click += Button_Click;

            positionsStack.Children.Add(panel);

            if (_id != -1)
            {
                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {

                        int.TryParse(dr["InvoicePosID"].ToString(), out var id_pos);
                        float.TryParse(dr["VAT_Value"].ToString(), out var vatValue);
                        float.TryParse(dr["Gross_Value"].ToString(), out var grossValue);
                        float.TryParse(dr["Net_Value"].ToString(), out var netValue);
                        sumNetValue += netValue;
                        sumVatValue += vatValue;
                        sumGrossValue += grossValue;


                        positionsStack.Children.Add(new InvoicePossitionViewClass(0, _id, id_pos, index++.ToString(),
                            dr["Product_Name"].ToString(), dr["Product_Code"].ToString(),
                            dr["Quantity"].ToString(), dr["Unit_Of_Measure"].ToString(), dr["Net_Value"].ToString(),
                            dr["VAT"].ToString(), vatValue.ToString("F"), grossValue.ToString("F")));

                    }



                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }





            Label sumLpLabel = new Label
            {
                Content = " ",
                Width = 100,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0)
            };
            Label sumProductNameLabel = new Label
            {
                Content = " ",
                Width = 127,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0)
            };
            Button sumButton = new Button
            {
                Content = "Podlicz/Odśwież",
                Width = 100,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0)
            };
            Label sumQuantityLabel = new Label
            {
                Content = " ",
                Width = 40,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0)
            };
            Label sumUnitMeasureLabel = new Label
            {
                Content = "Razem:",
                Width = 70,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0)
            };
            Label sumNetValueLabel = new Label
            {
                Content = sumNetValue.ToString("F"),
                Width = 90,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0)
            };
            Label sumVatLabel = new Label
            {
                Content = " ",
                Width = 35,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0)
            };
            Label sumVatValueLabel = new Label
            {
                Content = sumVatValue.ToString("F"),
                Width = 90,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0)
            };
            Label sumGrossValueLabel = new Label
            {
                Content = sumGrossValue.ToString("F"),
                Width = 95,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0)
            };

            _sumpanel.Children.Add(sumLpLabel);
            _sumpanel.Children.Add(sumButton);
            _sumpanel.Children.Add(sumUnitMeasureLabel);
            _sumpanel.Children.Add(sumNetValueLabel);
            _sumpanel.Children.Add(sumVatLabel);
            _sumpanel.Children.Add(sumVatValueLabel);
            _sumpanel.Children.Add(sumGrossValueLabel);

            positionsStack.Children.Add(_sumpanel);
            sumPanel = _sumpanel;
            sumButton.Click += SumButton_Click;

        }

        private void SumButton_Click(object sender, RoutedEventArgs e)
        {
            InvoicePositionViewLoad(_id);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var db = new DataBase();
            var dt = db.SelectInvoicePos(_id);
            int index = 1;
            float sumNetValue = 0;
            float sumVatValue = 0;
            float sumGrossValue = 0;
            int vat = 0;
            try
            {
                if (_id != -1)
                {
                    int id_pos = 0;
                    positionsStack.Children.Remove(sumPanel);
                    positionsStack.Children.Add(new InvoicePossitionViewClass(1, _id, id_pos, "", "", "",
                        "", "", "", "", "", ""));
                    positionsStack.Children.Add(sumPanel);
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {


                        float.TryParse(dr["VAT_Value"].ToString(), out var vatValue);
                        float.TryParse(dr["Gross_Value"].ToString(), out var grossValue);
                        float.TryParse(dr["Net_Value"].ToString(), out var netValue);
                        int.TryParse(dr["VAT"].ToString(), out var vatResult);
                        sumNetValue += netValue;
                        sumVatValue += vatValue;
                        sumGrossValue += grossValue;
                        vat = vatResult;

                    }

                    sumNetValue = (float) Math.Round(sumNetValue, 2);
                    sumVatValue = (float) Math.Round(sumVatValue, 2);
                    sumGrossValue = (float) Math.Round(sumGrossValue, 2);
                    int zlote = (int) Math.Round(sumGrossValue, 2);
                    int grosze = (int) (100 * Math.Round(sumGrossValue, 2)) % 100;
                    string kwotaSlownie = KwotaSlownie.LiczbaSlownie(zlote) + " " +
                                          KwotaSlownie.WalutaSlownie(zlote, "PLN") + " " +
                                          KwotaSlownie.LiczbaSlownie(grosze) + " " +
                                          KwotaSlownie.WalutaSlownie(grosze, ".PLN");

                    int splitPayment;
                    int.TryParse(clientIdTxtBox.Text, out var clientIdResult);
                    DateTime.TryParse(issuingDateDatePick.SelectedDate.ToString(), out var issuedateResult);
                    DateTime.TryParse(sellDateDatePick.SelectedDate.ToString(), out var saledateResult);
                    DateTime.TryParse(paymentDateDatePick.SelectedDate.ToString(), out var paymentdateResult);
                    bool splitPaymentCheck = Convert.ToBoolean(splitPaymentCheckBox.IsChecked);
                    splitPayment = splitPaymentCheck ? 1 : 0;
                    db.InsertInvoice(invoiceNumberTxtBox.Text, clientIdResult, clientNameTxtBox.Text, NipTxtBox.Text,
                        clientAddressTxtBox.Text, clientAddressPosNumberTxtBox.Text, clientAddressLocNumberTxtBox.Text,
                        ClientPostalCodeTxtBox.Text, ClientCityTxtBox.Text, ClientCountryTxtBox.Text, issuedateResult,
                        saledateResult, paymentdateResult, paymentMethodCBox.Text, accountNumberCBox.Text, splitPayment,
                        noteTxtBox.Text, sumNetValue, sumVatValue, vat, sumGrossValue,
                        issuingUserNameLbl.Content.ToString(), currencyCBox.Text, 1f, splitPaymentAccountCBox.Text,
                        kwotaSlownie);
                    var did = db.SelectInvoiceId(invoiceNumberTxtBox.Text);
                    int.TryParse(did.Rows[0]["InvoiceID"].ToString(), out var invoiceIdResult);
                    _id = invoiceIdResult;
                    int id_pos = 0;
                    positionsStack.Children.Remove(sumPanel);
                    positionsStack.Children.Add(new InvoicePossitionViewClass(1, _id, id_pos, "", "", "",
                        "", "", "", "", "", ""));
                    positionsStack.Children.Add(sumPanel);

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Błąd");
            }

        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            var db = new DataBase();
            var dt = db.SelectInvoicePos(_id);
            int index = 1;
            float sumNetValue = 0;
            float sumVatValue = 0;
            float sumGrossValue = 0;
            int vat = 0;

            try
            {
                foreach (DataRow dr in dt.Rows)
                {


                    float.TryParse(dr["VAT_Value"].ToString(), out var vatValue);
                    float.TryParse(dr["Gross_Value"].ToString(), out var grossValue);
                    float.TryParse(dr["Net_Value"].ToString(), out var netValue);
                    int.TryParse(dr["VAT"].ToString(), out var vatResult);
                    sumNetValue += netValue;
                    sumVatValue += vatValue;
                    sumGrossValue += grossValue;
                    vat = vatResult;

                }

                sumNetValue = (float) Math.Round(sumNetValue, 2);
                sumVatValue = (float) Math.Round(sumVatValue, 2);
                sumGrossValue = (float) Math.Round(sumGrossValue, 2);
                int zlote = (int) Math.Round(sumGrossValue, 2);
                int grosze = (int) (100 * Math.Round(sumGrossValue, 2)) % 100;
                string kwotaSlownie = KwotaSlownie.LiczbaSlownie(zlote) + " " +
                                      KwotaSlownie.WalutaSlownie(zlote, "PLN") + " " +
                                      KwotaSlownie.LiczbaSlownie(grosze) + " " +
                                      KwotaSlownie.WalutaSlownie(grosze, ".PLN");
                if (_id != -1)
                {
                    db.UpdatePaymentValues((float) Math.Round(sumNetValue, 2), (float) Math.Round(sumVatValue, 2), vat,
                        sumGrossValue = (float) Math.Round(sumGrossValue, 2), _id, kwotaSlownie);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            int result = 0;
            var di = new DataTable();
            di = null;
            try
            {
              di = db.SelectInvoiceId("new");
            }
            catch (Exception exception)
            {
                System.Windows.MessageBox.Show(exception.ToString());
               
            }

            try
            {
                int.TryParse(di.Rows[0]["InvoiceID"].ToString(), out result);
            }
            catch (Exception exception)
            {
              //  System.Windows.MessageBox.Show(exception.ToString());
                
            }
               
            

            db.DeleteAllInvoicePos(result);
            db.DeleteAllPaymentPos(result);
            db.DeleteInvoiceNumber("new");


            this.Close();
        }

        private void printBtn_Click(object sender, RoutedEventArgs e)
        {

            ReportsWindow reports = new ReportsWindow(4, _id);
            reports.ShowDialog();
        }

        private void saveInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            var db = new DataBase();
            var dt = db.SelectInvoicePos(_id);
            int index = 1;
            float sumNetValue = 0;
            float sumVatValue = 0;
            float sumGrossValue = 0;
            int vat = 0;

            try
            {
                foreach (DataRow dr in dt.Rows)
                {


                    float.TryParse(dr["VAT_Value"].ToString(), out var vatValue);
                    float.TryParse(dr["Gross_Value"].ToString(), out var grossValue);
                    float.TryParse(dr["Net_Value"].ToString(), out var netValue);
                    int.TryParse(dr["VAT"].ToString(), out var vatResult);
                    sumNetValue += netValue;
                    sumVatValue += vatValue;
                    sumGrossValue += grossValue;
                    vat = vatResult;

                }

                sumNetValue = (float) Math.Round(sumNetValue, 2);
                sumVatValue = (float) Math.Round(sumVatValue, 2);
                sumGrossValue = (float) Math.Round(sumGrossValue, 2);
                int zlote = (int) Math.Round(sumGrossValue, 2);
                int grosze = (int) (100 * Math.Round(sumGrossValue, 2)) % 100;
                string kwotaSlownie = KwotaSlownie.LiczbaSlownie(zlote) + " " +
                                      KwotaSlownie.WalutaSlownie(zlote, "PLN") + " " +
                                      KwotaSlownie.LiczbaSlownie(grosze) + " " +
                                      KwotaSlownie.WalutaSlownie(grosze, ".PLN");

                int splitPayment;
                int.TryParse(clientIdTxtBox.Text, out var clientIdResult);
                DateTime.TryParse(issuingDateDatePick.SelectedDate.ToString(), out var issuedateResult);
                DateTime.TryParse(sellDateDatePick.SelectedDate.ToString(), out var saledateResult);
                DateTime.TryParse(paymentDateDatePick.SelectedDate.ToString(), out var paymentdateResult);
                bool splitPaymentCheck = Convert.ToBoolean(splitPaymentCheckBox.IsChecked);
                splitPayment = splitPaymentCheck ? 1 : 0;
                db.UpdateInvoice(invoiceNumberTxtBox.Text, clientIdResult, clientNameTxtBox.Text, NipTxtBox.Text,
                    clientAddressTxtBox.Text, clientAddressPosNumberTxtBox.Text, clientAddressLocNumberTxtBox.Text,
                    ClientPostalCodeTxtBox.Text, ClientCityTxtBox.Text, ClientCountryTxtBox.Text, issuedateResult,
                    saledateResult, paymentdateResult, paymentMethodCBox.Text, accountNumberCBox.Text, splitPayment,
                    noteTxtBox.Text, sumNetValue, sumVatValue, vat, sumGrossValue,
                    issuingUserNameLbl.Content.ToString(), currencyCBox.Text, 1f, splitPaymentAccountCBox.Text, _id,
                    kwotaSlownie);





                MessageBox.Show("Faktura zapisana");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }


        }

        private void deleteInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            var db = new DataBase();
            db.DeleteInvoice(_id);
            db.DeleteInvoiceNumber("new");
            db.DeleteAllInvoicePos(_id);
            this.Close();
        }

        private int CheckPayment(int id)
        {
            var db = new DataBase();
            float paymentAmount = db.GetPaymentAmount(id);
            var di = db.SelectInvoice(id);
            float.TryParse(di.Rows[0]["Gross_Value"].ToString(), out var invoiceGrossValue);


            if (paymentAmount == 0)
            {
                return 0;
            }
            else if (paymentAmount < invoiceGrossValue)
            {
                return 1;
            }
            else if (paymentAmount == invoiceGrossValue)
            {
                return 2;
            }
            else
            {
                return 3;
            }

        }

        private void PaymentValueViewLoad(int id)
        {
            var db = new DataBase();
            var dp = db.SelectPayments(id);
            int index = 1;
            paymentValueStack.Children.Clear();
            Label lpLabel = new Label
            {
                Content = "Lp.",
                Width = 27,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(1)
            };
            Label paymentAmountLabel = new Label
            {
                Content = "Kwota wpłaty",
                Width = 125,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(1)
            };
            Label paymentDateLabel = new Label
            {
                Content = "Data wpłaty",
                Width = 121,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(1)
            };
            Label paymentCurrencyLabel = new Label
            {
                Content = "Waluta",
                Width = 50,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(1)
            };
            Button addButton = new Button
            {
                RenderTransformOrigin = new Point(0.392, 0.167),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 20,
                Height = 20,
                Content = "+"
            };
            WrapPanel panel = new WrapPanel();
            panel.Children.Add(lpLabel);
            panel.Children.Add(paymentAmountLabel);
            panel.Children.Add(paymentDateLabel);
            panel.Children.Add(paymentCurrencyLabel);
            panel.Children.Add(addButton);
            paymentValueStack.Children.Add(panel);
            addButton.Click += AddButton_Click;

            if (_id != -1)
            {
                try
                {
                    foreach (DataRow dr in dp.Rows)
                    {

                        int.TryParse(dr["PaymentId"].ToString(), out var paymentId);
                        float.TryParse(dr["Payment_Amount"].ToString(), out var paymentAmount);
                        
                        DateTime.TryParse(dr["Payment_Date"].ToString(), out var paymentDate);




                        paymentValueStack.Children.Add(new PaymentValue(0,_id, paymentId, index++, paymentAmount,
                            paymentDate, dr["Payment_Currency"].ToString()));

                    }



                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            //paymentValueStack.Children.Add(new PaymentValue(1));    
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var db = new DataBase();
            var dt = db.SelectPayments(_id);
            int index = db.SelectCountPayments(_id) + 1;
           
            try
            {
                if (_id != -1)
                {
                    int paymentId = 0;
                   
                    paymentValueStack.Children.Add(new PaymentValue(1,_id, paymentId,index,0f, DateTime.Today, " ") );
                  
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(e.ToString());
            }

            
        }
    }
}