using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using Button = System.Windows.Controls.Button;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using Label = System.Windows.Controls.Label;
using MessageBox = System.Windows.MessageBox;

namespace Invoice
{
    class InvoiceCanvasClass : Canvas
    {
        
        private int _id;

        public InvoiceCanvasClass(int id, string issueDate, string client, string grossValue, string invoiceNr, string status)
        {
            this._id = id;
            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Top;
            Height = 106;
            Width = 230;
            Margin = new Thickness(87, 56, 0, 0);
            Background = new RadialGradientBrush(Colors.White, Colors.Red);
            Effect = new DropShadowEffect();
            var button = new Button();
            button.Opacity = 0;
            button.Height = 106;
            button.Width = 230;
            var issueDateLbl = new Label();
            issueDateLbl.Content = issueDate;
            issueDateLbl.RenderTransformOrigin = new Point(0.639, -0.096);
            var clientLbl = new Label();
            clientLbl.Content = client;
            clientLbl.RenderTransformOrigin = new Point(-0.408, 0.846);
            clientLbl.FontSize = 16;
            clientLbl.Margin = new Thickness(13, 29, 0, 0);
            var grossLbl = new Label();
            grossLbl.Content = grossValue;
            grossLbl.RenderTransformOrigin = new Point(-0.408, 0.846);
            grossLbl.Margin = new Thickness(0, 67, 0, 0);
            grossLbl.FontSize = 14;
            var invoiceNrLbl = new Label();
            invoiceNrLbl.Content = invoiceNr;
            invoiceNrLbl.RenderTransformOrigin = new Point(-0.408, 0.846);
            invoiceNrLbl.Margin = new Thickness(120, 67, 0, 0);
            invoiceNrLbl.FontSize = 14;
            var statusLbl = new Label();
            statusLbl.Content = status;
            statusLbl.RenderTransformOrigin = new Point(0.639, -0.096);
            statusLbl.Margin = new Thickness(141, 0, 0, 0);
            Children.Add(issueDateLbl);
            Children.Add(clientLbl);
            Children.Add(grossLbl);
            Children.Add(invoiceNrLbl);
            Children.Add(statusLbl);
            Children.Add(button);
            button.MouseDoubleClick += Button_MouseDoubleClick;

        }

        private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(this._id.ToString());
            var invoice = new InvoiceView(_id);
            invoice.ShowDialog();
        }
    }
}
