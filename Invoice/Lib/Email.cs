using Limilabs.Client.SMTP;
using Limilabs.Mail;
using Limilabs.Mail.Fluent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice
{
    class Email
    {
        

        public void SendEmail(string _attachment)
        {
            var setup = new Setup();
            setup.SetBackupProperties(System.IO.Directory.GetCurrentDirectory() + "\\config.ini");
            IMail email = Mail   
              .Html(@"Html ")
              .AddAttachment(_attachment).SetFileName("bugreport.txt")
              .To(setup.GetMailReceiver())
              .From(setup.GetMailFrom())
              .Subject("Database backup bugreport")
              .Create();
            using (Smtp smtp = new Smtp())
            {
                smtp.Connect(setup.GetSmtpServer());  // or ConnectSSL for SSL
                smtp.UseBestLogin(setup.GetSmtpLogin(), setup.GetSmtpPass());
                smtp.SendMessage(email);
                smtp.Close();
            }
        }

    }
}
