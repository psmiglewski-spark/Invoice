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
            var db = new DataBase();
            var dt = db.SelectInvoicePos(id);
            var di = db.SelectInvoiceAndClient(id);





            try
            {
                foreach (DataRow dr in di.Rows)
                {
                    int.TryParse(dr["InvoiceID"].ToString(), out var id_pos);
                    int index = 1;


                   
                    clientNameTxtBox.Text = dr["Client_Name"].ToString();
                    clientAddressTxtBox.Text = dr["Client_Address_Street"].ToString() +
                                               dr["Client_Address_Pos_Number"].ToString() +
                                               dr["Client_Address_Loc_Number"].ToString();
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

            InvoicePositionViewLoad(_id);


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
            int id_pos = 0;
            positionsStack.Children.Remove(sumPanel);
            positionsStack.Children.Add(new InvoicePossitionViewClass(1, _id, id_pos, "", "", "",
                "", "", "", "", "", ""));
            positionsStack.Children.Add(sumPanel);
            


        }
    }
}
