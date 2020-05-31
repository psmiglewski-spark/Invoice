using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Invoice.ViewElements
{
    class ClientListClass : StackPanel
    {
        private WrapPanel wrapPanel = new WrapPanel();
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

        public ClientListClass(int _lp, int _clientId, string _symbol, string _name, string _address, string _nip, string _phone)
        {
            lpLbl.Content = _lp.ToString();
            clientIdLbl.Content = _clientId.ToString();
            symbolLbl.Content = _symbol;
            nameLbl.Content = _name;
            addressLbl.Content = _address;
            nipLbl.Content = _nip;
            phoneLbl.Content = _phone;
            wrapPanel.Children.Add(lpLbl);
            wrapPanel.Children.Add(clientIdLbl);
            wrapPanel.Children.Add(symbolLbl);
            wrapPanel.Children.Add(nameLbl);
            wrapPanel.Children.Add(addressLbl);
            wrapPanel.Children.Add(nipLbl);
            wrapPanel.Children.Add(phoneLbl);
            Children.Add(wrapPanel);
        }
    }
}
