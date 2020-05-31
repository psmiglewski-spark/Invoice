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
        private int _id_Payment;
        private int _isNew = 0;
        private int _idInvoice;
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

        public PaymentValue(int isNew,int idInvoice, int id_payment, int index, float paymentAmountValue, DateTime paymentDate,
            string paymentCurrency)
        {
            this._id_Payment = id_payment;
            this._idInvoice = idInvoice;
            this._isNew = isNew;
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
            if (_textBoxChanged == false)
            {




                saveBtn.Visibility = Visibility.Visible;

                _textBoxChanged = true;
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            DataBase db = new DataBase();
            db.DeletePaymentPos(_id_Payment);
            this.Visibility = Visibility.Collapsed;

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

            DataBase db = new DataBase();

            DateTime.TryParse(paymentDateDatePicker.SelectedDate.ToString(), out var paymentDateResult);
            float.TryParse(paymentAmountTxtBox.Text, out var paymentAmountResult);

            
            if (_isNew == 0)
            {
                db.UpdatePaymentPos(_id_Payment, paymentAmountResult, paymentCurrencyTxtBox.Text, paymentDateResult );
            }
            else
            {
                db.InsertPaymentPos(_idInvoice,paymentAmountResult, paymentCurrencyTxtBox.Text, paymentDateResult);
            }

            saveBtn.Visibility = Visibility.Hidden;

            _textBoxChanged = false;
        }
     
    }
}