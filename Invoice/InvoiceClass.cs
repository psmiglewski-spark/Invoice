using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice
{
    class InvoiceClass
    {
        
        public string Invoice_Number { get; set; } 
        public int ID_Client { get; set; } 
        public string Client_Name { get; set; }
        public string Client_NIP { get; set; }
        public string Client_Address_Street { get; set; }
        public string Client_Address_Pos_Number { get; set; }
        public string Client_Address_Loc_Number { get; set; }
        public string Client_Address_Postal_Code { get; set; }
        public string Client_Address_City { get; set; }
        public string Client_Address_Country { get; set; }
        public DateTime Issue_Date { get; set; }
        public DateTime Sale_Date { get; set; }
        public DateTime Payment_Date { get; set; }
        public string Payment_Method { get; set; }
        public string Payment_Account { get; set; }
        public int SplitPayment { get; set; }
        public string Note { get; set; }
        public float Net_Value { get; set; }
        public float Gross_Value { get; set; }
        public float VAT_Value { get; set; }
        public int VAT { get; set; }
        public string Issuing_User { get; set; }
        public string Currency { get; set; }
        public float Currency_Change_Rate { get; set; }
        public string Kwota_Slownie { get; set; }
        public string VAT_Account { get; set; }

        public InvoiceClass(string invoiceNumber, int idClient, string clientName, string clientNip, string clientAddressStreet, string clientAddressPosNumber, string clientAddressLocNumber, string clientAddressPostalCode, string clientAddressCity, string clientAddressCountry, DateTime issueDate, DateTime saleDate, DateTime paymentDate, string paymentMethod, string paymentAccount, int splitPayment, string note, float netValue, float grossValue, float vatValue, int vat, string issuingUser, string currency, float currencyChangeRate, string kwotaSlownie, string vatAccount)
        {
            this.Invoice_Number = invoiceNumber;
            this.ID_Client = idClient;
            this.Client_Name = clientName;
            this.Client_NIP = clientNip;
            this.Client_Address_Street = clientAddressStreet;
            this.Client_Address_Pos_Number = clientAddressPosNumber;
            this.Client_Address_Loc_Number = clientAddressLocNumber;
            this.Client_Address_Postal_Code = clientAddressPostalCode;
            this.Client_Address_City = clientAddressCity;
            this.Client_Address_Country = clientAddressCountry;
            this.Issue_Date = issueDate;
            this.Sale_Date = saleDate;
            this.Payment_Date = paymentDate;
            this.Payment_Method = paymentMethod;
            this.Payment_Account = paymentAccount;
            this.SplitPayment = splitPayment;
            this.Note = note;
            this.Net_Value = netValue;
            this.Gross_Value = grossValue;
            this.VAT_Value = vatValue;
            this.VAT = vat;
            this.Issuing_User = issuingUser;
            this.Currency = currency;
            this.Currency_Change_Rate = currencyChangeRate;
            this.Kwota_Slownie = kwotaSlownie;
            this.VAT_Account = vatAccount;


        }

        public InvoiceClass()
        {
            
        }
    }
}
