using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Invoice.ViewElements
{
    class ClientListView : StackPanel
    {
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

        public string _lpText { get; set; }

        public ClientListView()
        {


           // StackPanel stackPanel = new StackPanel();
            WrapPanel wrapPanel = new WrapPanel();
            WrapPanel wrapPanelFilter = new WrapPanel();







            Margin = new Thickness(476, 295, 0, 0);
            wrapPanel.Children.Add(lpLbl);
            wrapPanel.Children.Add(clientIdLbl);
            wrapPanel.Children.Add(symbolLbl);
            wrapPanel.Children.Add(nameLbl);
            wrapPanel.Children.Add(addressLbl);
            wrapPanel.Children.Add(nipLbl);
            wrapPanel.Children.Add(phoneLbl);
            wrapPanelFilter.Children.Add(lpTxtBox);
            wrapPanelFilter.Children.Add(clientIdTxtBox);
            wrapPanelFilter.Children.Add(symbolTxtBox);
            wrapPanelFilter.Children.Add(nameTxtBox);
            wrapPanelFilter.Children.Add(addressTxtBox);
            wrapPanelFilter.Children.Add(nipTxtBox);
            wrapPanelFilter.Children.Add(phoneTxtBox);
            Children.Add(wrapPanel);
            Children.Add(wrapPanelFilter);

            lpTxtBox.TextChanged += LpTxtBox_TextChanged;


        }

        private void LpTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           MessageBox.Show(lpTxtBox.Text);
           

        }
    }

}