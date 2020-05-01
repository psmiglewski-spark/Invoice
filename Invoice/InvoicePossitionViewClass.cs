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
        //<WrapPanel HorizontalAlignment = "Left" Height="28" VerticalAlignment="Top" Width="755" RenderTransformOrigin="0.525,0.506">
        //<Label x:Name="lpLbl" Content="Lp." Width="27" BorderBrush="Black" BorderThickness="1"/>
        //<Label x:Name="productNameLbl" Width="127" Content="Nazwa towaru/usługi" BorderBrush="Black" BorderThickness="1"/>
        //<Label x:Name="productCodeLbl" Content="PKWiU" Width="50" BorderBrush="Black" BorderThickness="1"/>
        //<Label x:Name="quantityLbl" Content="Ilość" Width="40" BorderBrush="Black" BorderThickness="1"/>
        //<Label x:Name="unitOfMeasureLbl" Content="j.m." Width="30" BorderBrush="Black" BorderThickness="1"/>
        //<Label x:Name="netValueLbl" Content="Wartość netto" Width="90" BorderBrush="Black" BorderThickness="1"/>
        //<Label x:Name="vatLbl" Content="VAT" Width="35" BorderBrush="Black" BorderThickness="1"/>
        //<Label x:Name="vatValueLbl" Content="Wartość VAT" Width="90" BorderBrush="Black" BorderThickness="1"/>
        //<Label x:Name="grossValueLbl" Content="Wartość brutto" Width="95" BorderBrush="Black" BorderThickness="1"/>
        //</WrapPanel>
        //<WrapPanel HorizontalAlignment = "Left" Height="28" VerticalAlignment="Top" Width="755" RenderTransformOrigin="0.525,0.506">
        //<Label x:Name="lpLbl" Content="Lp." Width="27" BorderBrush="Black" BorderThickness="1"/>
        //<Label x:Name="productNameLbl" Width="127" Content="Nazwa towaru/usługi" BorderBrush="Black" BorderThickness="1"/>
        //<Label x:Name="productCodeLbl" Content="PKWiU" Width="50" BorderBrush="Black" BorderThickness="1"/>
        //<Label x:Name="quantityLbl" Content="Ilość" Width="40" BorderBrush="Black" BorderThickness="1"/>
        //<Label x:Name="unitOfMeasureLbl" Content="j.m." Width="30" BorderBrush="Black" BorderThickness="1"/>
        //<Label x:Name="netValueLbl" Content="Wartość netto" Width="90" BorderBrush="Black" BorderThickness="1"/>
        //<Label x:Name="vatLbl" Content="VAT" Width="35" BorderBrush="Black" BorderThickness="1"/>
        //<Label x:Name="vatValueLbl" Content="Wartość VAT" Width="90" BorderBrush="Black" BorderThickness="1"/>
        //<Label x:Name="grossValueLbl" Content="Wartość brutto" Width="95" BorderBrush="Black" BorderThickness="1"/>
                        
        //</WrapPanel>

        public InvoicePossitionViewClass(string lp, string productName,string productCode, string quantity, string unitOfMeasure, string netValue, string vat, string vatValue, string grossValue)
        {
            HorizontalAlignment = HorizontalAlignment.Left;
            Height = 28;
            VerticalAlignment = VerticalAlignment.Top;
            Width = 755;
            RenderTransformOrigin = new Point(0.525, 0.506);
            var lpLbl = new Label
            {
                Content = lp,
                Width = 27,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0.5)
            };
            var productNameLbl = new Label
            {
                Content = productName,
                Width = 127,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0.5)
            };
            var productCodeLbl = new Label
            {
                Content = productCode,
                Width = 50,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0.5)
            };
            var quantityLbl = new Label
            {
                Content = quantity,
                Width = 40,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0.5)
            };
            var unitOfMeasureLbl = new Label
            {
                Content = unitOfMeasure,
                Width = 30,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0.5)
            };
            var netValueLbl = new Label
            {
                Content = netValue,
                Width = 90,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0.5)
            };
            var vatLbl = new Label
            {
                Content = vat,
                Width = 35,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0.5)
            };
            var vatValueLbl = new Label
            {
                Content = vatValue,
                Width = 90,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0.5)
            };
            var grossValueLbl = new Label
            {
                Content = grossValue,
                Width = 95,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0.5)
            };
            var deleteBtn = new Button
            {
                Content = "X",
                Width = 15,
                Height = 18,
                Background = new SolidColorBrush(Colors.Red)
            };
            Children.Add(lpLbl);
            Children.Add(productNameLbl);
            Children.Add(productCodeLbl);
            Children.Add(quantityLbl);
            Children.Add(unitOfMeasureLbl);
            Children.Add(netValueLbl);
            Children.Add(vatLbl);
            Children.Add(vatValueLbl);
            Children.Add(grossValueLbl);
            Children.Add(deleteBtn);
            deleteBtn.Click += DeleteBtn_Click;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Click");

        }
    }
}
