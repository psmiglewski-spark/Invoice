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
    class PaymentValue : WrapPanel
    {
        private bool _textBoxChanged = false;
        TextBox lpTxtBox = new TextBox()
        {
            Width = 27,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };
        TextBox paymentAmountTxtBox = new TextBox()
        {
            
            Width = 125,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };
        DatePicker paymentDateDatePicker = new DatePicker()
        {
           
            Width = 121,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };
        TextBox paymentCurrencyTxtBox = new TextBox()
        {
            
            Width = 50,
            BorderBrush = new SolidColorBrush(Colors.Black),
            BorderThickness = new Thickness(0.5)
        };
        Button saveBtn = new Button
        {
            Content = "V",
            Width = 15,
            Height = 18,
            Background = new SolidColorBrush(Colors.Green),
            Visibility = Visibility.Hidden

        };
        Button deleteBtn = new Button
        {
            Content = "X",
            Width = 15,
            Height = 18,
            Background = new SolidColorBrush(Colors.Red)
        };

        public PaymentValue(int id, int id_payment, int index, float paymentAmountValue, DateTime paymentDate,
            string paymentCurrency)
        {
            paymentAmountTxtBox.Text = paymentAmountValue.ToString();
            paymentDateDatePicker.SelectedDate = paymentDate;
            paymentCurrencyTxtBox.Text = paymentCurrency;
            lpTxtBox.Text = index.ToString();
            Children.Add(lpTxtBox);
            Children.Add(paymentAmountTxtBox);
            Children.Add(paymentDateDatePicker);
            Children.Add(paymentCurrencyTxtBox);
            Children.Add(deleteBtn);
            Children.Add(saveBtn);

            deleteBtn.Click += DeleteBtn_Click;
            lpTxtBox.TextChanged += TxtBox_TextChanged;
            paymentAmountTxtBox.TextChanged += TxtBox_TextChanged;
            paymentDateDatePicker.SelectedDateChanged += PaymentDateDatePicker_SelectedDateChanged;
            paymentCurrencyTxtBox.TextChanged += TxtBox_TextChanged;
            saveBtn.Click += SaveBtn_Click;

        }

        private void TxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_textBoxChanged == false)
            {




                saveBtn.Visibility = Visibility.Visible;

                _textBoxChanged = true;
            }

        }

        private void PaymentDateDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            DataBase db = new DataBase();
            // db.DeleteInvoicePos(idPos);
            this.Visibility = Visibility.Collapsed;

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

            DataBase db = new DataBase();

            //int.TryParse(quantityTxtBox.Text, out var quantResult);
            //float.TryParse(netValueTxtBox.Text, out var netResult);

            //float.TryParse(vatTxtBox.Text, out var vatResult);
            //if (_isNew == 0)
            //{
            //    db.UpdateInvoicePos(idPos, productNameTxtBox.Text, productCodeTxtBox.Text, quantResult,
            //        unitOfMeasureTxtBox.Text, netResult, (netResult * (vatResult / 100)),
            //        (netResult * (1 + vatResult / 100)), vatTxtBox.Text);
            //}
            //else
            //{
            //    db.InsertInvoicePos(productNameTxtBox.Text, productCodeTxtBox.Text, quantResult,
            //        unitOfMeasureTxtBox.Text, netResult, (netResult * (vatResult / 100)),
            //        (netResult * (1 + vatResult / 100)), vatTxtBox.Text, _invoiceId);
            //}

            saveBtn.Visibility = Visibility.Hidden;
        }
     
    }
}