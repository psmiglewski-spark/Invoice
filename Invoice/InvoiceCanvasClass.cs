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
        
        private int _id = 0;

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
            var paymentStatus = CheckPayment(id);
            switch (paymentStatus)
            {
                case 0:
                {
                    Background = new RadialGradientBrush(Colors.White, Colors.Red);
                    break;
                }
                case 1:
                {
                    Background = new RadialGradientBrush(Colors.White, Colors.Yellow);
                    break;
                }
                case 2:
                {
                    Background = new RadialGradientBrush(Colors.White, Colors.GreenYellow);
                    break;
                }
                case 3:
                {
                    Background = new RadialGradientBrush(Colors.White, Colors.DeepPink);
                    break;
                }
            }

            if (_id != 0)
            {
                button.MouseDoubleClick += Button_MouseDoubleClick;
            }
        }

        private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var invoice = new InvoiceView(_id);
             MessageBox.Show(this._id.ToString());
             try
             {
                 invoice.ShowDialog();

            }
            catch (Exception exception)
             {
                 System.Windows.MessageBox.Show(exception.ToString());
                 
             }
             
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
    }
}
