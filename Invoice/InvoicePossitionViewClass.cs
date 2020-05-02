using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Invoice
{
    class InvoicePossitionViewClass : WrapPanel
    {
        private bool _textBoxChanged = false;
        private int idPos;
        Button saveBtn = new Button
        {
            Content = "V",
            Width = 15,
            Height = 18,
            Background = new SolidColorBrush(Colors.Green),
            Visibility = Visibility.Hidden

        };
        TextBox lpTxtBox = new TextBox
        {
           // Text = lp,
            Width = 27,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };
        TextBox productNameTxtBox = new TextBox
        {
           // Text = productName,
            Width = 127,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };
        TextBox productCodeTxtBox = new TextBox
        {
           // Text = productCode,
            Width = 50,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };
        TextBox quantityTxtBox = new TextBox
        {
           // Text = quantity,
            Width = 40,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };
        TextBox unitOfMeasureTxtBox = new TextBox
        {
           // Text = unitOfMeasure,
            Width = 30,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };
        TextBox netValueTxtBox = new TextBox
        {
           // Text = netValue,
            Width = 90,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };
        TextBox vatTxtBox = new TextBox
        {
           // Text = vat,
            Width = 35,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };
        TextBox vatValueTxtBox = new TextBox
        {
           // Text = vatValue,
            Width = 90,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };
        TextBox grossValueTxtBox = new TextBox
        {
            //Text = grossValue,
            Width = 95,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };
        Button deleteBtn = new Button
        {
            Content = "X",
            Width = 15,
            Height = 18,
            Background = new SolidColorBrush(Colors.Red)
        };
        public InvoicePossitionViewClass(int id_pos, string lp, string productName,string productCode, string quantity, string unitOfMeasure, string netValue, string vat, string vatValue, string grossValue)
        {
            this.idPos = id_pos;
            HorizontalAlignment = HorizontalAlignment.Left;
            Height = 28;
            VerticalAlignment = VerticalAlignment.Top;
            Width = 755;
            RenderTransformOrigin = new Point(0.525, 0.506);
            lpTxtBox.Text = lp;
            productNameTxtBox.Text = productName;
            productCodeTxtBox.Text = productCode;
            quantityTxtBox.Text = quantity;
            unitOfMeasureTxtBox.Text = unitOfMeasure;
            netValueTxtBox.Text = netValue;
            vatValueTxtBox.Text = vatValue;
            grossValueTxtBox.Text = grossValue;
            vatTxtBox.Text = vat;
            //var saveBtn = new Button
            //{
            //    Content = "V",
            //    Width = 15,
            //    Height = 18,
            //    Background = new SolidColorBrush(Colors.Green),
                
            //};
            Children.Add(lpTxtBox);
            Children.Add(productNameTxtBox);
            Children.Add(productCodeTxtBox);
            Children.Add(quantityTxtBox);
            Children.Add(unitOfMeasureTxtBox);
            Children.Add(netValueTxtBox);
            Children.Add(vatTxtBox);
            Children.Add(vatValueTxtBox);
            Children.Add(grossValueTxtBox);
            Children.Add(deleteBtn);
            Children.Add(saveBtn);
           // Children.Add(saveBtn);
                //saveBtn.Visibility = Visibility.Hidden;
            //saveBtn.IsEnabled = false;
            deleteBtn.Click += DeleteBtn_Click;
            lpTxtBox.TextChanged += TxtBox_TextChanged;
            productNameTxtBox.TextChanged += TxtBox_TextChanged;
            productCodeTxtBox.TextChanged += TxtBox_TextChanged;
            quantityTxtBox.TextChanged += TxtBox_TextChanged;
            unitOfMeasureTxtBox.TextChanged += TxtBox_TextChanged;
            netValueTxtBox.TextChanged += TxtBox_TextChanged;
            vatTxtBox.TextChanged += TxtBox_TextChanged;
            vatValueTxtBox.IsEnabled = false;
            grossValueTxtBox.IsEnabled = false;

        }

        private void TxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            

            if (_textBoxChanged == false)
            {

                saveBtn.Visibility = Visibility.Visible;
                saveBtn.Click += SaveBtn_Click;
                _textBoxChanged = true;
            }
            

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(idPos.ToString());
            DataBase db = new DataBase(); 
            
            int.TryParse(quantityTxtBox.Text, out var quantResult);
            float.TryParse(netValueTxtBox.Text, out var netResult);
            // float.TryParse(vatValueTxtBox.Text, out var vatResult);
            // float.TryParse(grossValueTxtBox.Text, out var grossResult);
            float.TryParse(vatTxtBox.Text, out var vatResult);
            MessageBox.Show(vatResult.ToString());
            db.UpdateInvoicePos(idPos,productNameTxtBox.Text,productCodeTxtBox.Text, quantResult,unitOfMeasureTxtBox.Text, netResult ,(netResult*(vatResult/100)), (netResult*(1+vatResult/100)),vatTxtBox.Text );
            
            // saveBtn.Visibility = Visibility.Hidden;
            this.Visibility = Visibility.Collapsed;
            e.Handled = true;
            _textBoxChanged = false;

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Click");
            this.Visibility = Visibility.Collapsed;

        }
    }
}
