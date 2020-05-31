using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace Invoice
{
    class Setup
    {
        private string connectionString ;
        private string path ;
        private string dataBaseName;
        private string mailReceiver;
        private string mailFrom;
        private string smtpServer;
        private string smtpLogin;
        private string smtpPass;
        
        
        public void SetBackupProperties(string _filePath)
        {
            try
            {
                List<string> list = new List<string>();
                string[] Name = { " " };

                try
                {
                   Name = File.ReadAllLines(_filePath, Encoding.Default);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                    File.WriteAllText(Directory.GetCurrentDirectory() + "\\faillog" + DateTime.Now.ToString() + ".txt", exc.ToString());
                    string logPath = Directory.GetCurrentDirectory() + "\\faillog" + DateTime.Now.ToString("yyMMddhhmm") + ".txt";
                    try
                    {
                        Email email = new Email();
                        email.SendEmail(logPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        
                    }
                    
                }
                for (int i = 0; i < Name.Length; i++)
                {
                    list.Add(Name[i]);
                }
                this.connectionString = list[0];
                this.path = list[1];
                this.dataBaseName = list[2];
                this.mailReceiver = list[3];
                this.mailFrom = list[4];
                this.smtpServer = list[5];
                this.smtpLogin = list[6];
                this.smtpPass = list[7];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                File.WriteAllText(Directory.GetCurrentDirectory() + "\\faillog" + DateTime.Now.ToString() + ".txt", ex.ToString());
                string logPath = Directory.GetCurrentDirectory() + "\\faillog" + DateTime.Now.ToString("yyMMddhhmm") + ".txt";
                try
                {
                    Email email = new Email();
                    email.SendEmail(logPath);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());

                }
                
            }
        }

        public string GetConnectionString()
        {
            return connectionString;
        }
        public string GetPath()
        {
            return path;
        }
        public string GetDataBaseName()
        {
            return dataBaseName;
        }
        public string GetMailReceiver()
        {
            return mailReceiver;
        }
        public string GetMailFrom()
        {
            return mailFrom;
        }
        public string GetSmtpServer()
        {
            return smtpServer;
        }
        public string GetSmtpLogin()
        {
            return smtpLogin;
        }
        public string GetSmtpPass()
        {
            return smtpPass;
        }
        public string GetInstallationPath()
        {
            return System.IO.Directory.GetCurrentDirectory();
        }
       
    }
}
