using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Invoice
{
    class Client
    {
        public string NIP;
        public string Name;
        public string Short_Name;
        public string Address_Street;
        public string Address_Pos_Number;
        public string Address_Loc_Number;
        public string Address_Postal_Code;
        public string Address_City;
        public string Address_Country;
        public string Client_Type;
        public int Discount;
        public string Payment_Method;
        public string Phone_Number;
        public string Account_Number;
        public string Mobile_Phone;
        public string SWIFT;
        public string Account_Bank;
        public string Email;
        public int SplitPayment;
        public string WWW;

        public Client (string _NIP
           , string _Name
           , string _Short_Name
           , string _Address_Street
           , string _Address_Pos_Number
           , string _Address_Loc_Number
           , string _Address_Postal_Code
           , string _Address_City
           , string _Address_Country
           , string _Client_Type
           , int _Discount
           , string _Payment_Method
           , string _Phone_Number
           , string _Account_Number
           , string _Mobile_Phone
           , string _SWIFT
           , string _Account_Bank
           , string _Email
           , int _SplitPayment
           , string _WWW)
        {
            this.NIP = _NIP;
            this.Name = _Name;
            this.Short_Name = _Short_Name;
            this.Address_Street = _Address_Street;
            this.Address_Pos_Number = _Address_Pos_Number;
            this.Address_Loc_Number = _Address_Loc_Number;
            this.Address_Postal_Code = _Address_Postal_Code;
            this.Address_City = _Address_City;
            this.Address_Country = _Address_Country;
            this.Client_Type = _Client_Type;
            this.Discount = _Discount;
            this.Payment_Method = _Payment_Method;
            this.Phone_Number = _Phone_Number;
            this.Account_Number = _Account_Number;
            this.Mobile_Phone = _Mobile_Phone;
            this.SWIFT = _SWIFT;
            this.Account_Bank = _Account_Bank;
            this.Email = _Email;
            this.SplitPayment = _SplitPayment;
            this.WWW = _WWW;

        }

        public Client()
        {
               
        }

        public string GetNIP()
        {
            return this.NIP;
        }
        public string GetName()
        {
            return this.Name;
        }
        public string GetShort_Name()
        {
            return this.Short_Name;
        }
        public string GetAddress_Street()
        {
            return this.Address_Street;
        }
        public string GetAddress_Pos_Number()
        {
            return this.Address_Pos_Number;
        }
        public string GetAddress_Loc_Number()
        {
            return this.Address_Loc_Number;
        }
        public string GetAddress_Postal_Code()
        {
            return this.Address_Postal_Code;
        }
        public string GetAddress_City()
        {
            return this.Address_City;
        }
        public string GetAddress_Country()
        {
            return this.Address_Country;
        }
        public string GetClient_Type()
        {
            return this.Client_Type;
        }
        public int GetDiscount()
        {
            return this.Discount;
        }
        public string GetPayment_Method()
        {
            return this.Payment_Method;
        }
        public string GetPhone_Number()
        {
            return this.Phone_Number;
        }
        public string GetAccount_Number()
        {
            return this.Account_Number;
        }
        public string GetMobile_Phone()
        {
            return this.Mobile_Phone;
        }
        public string GetSWIFT()
        {
            return this.SWIFT;
        }
        public string GetAccount_Bank()
        {
            return this.Account_Bank;
        }
        public string GetEmail()
        {
            return this.Email;
        }
        public int GetSplitPayment()
        {
            return this.SplitPayment;
        }
        public string GetWWW()
        {
            return this.WWW;
        }
        
        //GetUri Task needed to connect to https json response API
        static async Task<string> GetURI(Uri u)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.GetAsync(u);
                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                }
            }
            return response;
        } 
        
        // White list account check 
        public void CheckWl(string nip, string date)
        {
            var t = Task.Run(() => GetURI(new Uri("https://wl-api.mf.gov.pl/api/search/nip/" + nip + "?" + "date=" + date)));
            t.Wait();
            
            MessageBox.Show(t.Result);

           

        }
    }
}
