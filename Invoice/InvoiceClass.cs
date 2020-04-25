using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice
{
    class InvoiceClass
    {
        
        public string Invoice_Number { get; } 
        public int ID_Client { get; } 
        public string Client_Name { get; }
        public string Client_NIP { get; }
        public string Client_Address_Street { get; }
        public string Client_Address_Pos_Number { get; }
        public string Client_Address_Loc_Number { get; }
        public string Client_Address_Postal_Code { get; }
        public string Client_Address_City { get; }
        public string Client_Address_Country { get; }
        public DateTime Issue_Date { get; }
        public DateTime Sale_Date { get; }
        public DateTime Payment_Date { get; }
        public string Payment_Method { get; }
        public string Payment_Account { get; }
        public int SplitPayment { get; }
        public string Note { get; }
        public float Net_Value { get; }
        public float Gross_Value { get; }
        public float VAT_Value { get; }
        public int VAT { get; }
        public string Issuing_User { get; }
        public string Currency { get; }
        public float Currency_Change_Rate { get; }

        public InvoiceClass(string invoiceNumber, int idClient, string clientName, string clientNip, string clientAddressStreet, string clientAddressPosNumber, string clientAddressLocNumber, string clientAddressPostalCode, string clientAddressCity, string clientAddressCountry, DateTime issueDate, DateTime saleDate, DateTime paymentDate, string paymentMethod, string paymentAccount, int splitPayment, string note, float netValue, float grossValue, float vatValue, int vat, string issuingUser, string currency, float currencyChangeRate)
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


        }

        public InvoiceClass()
        {
            
        }
    }
}
