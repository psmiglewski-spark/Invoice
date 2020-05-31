using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice
{
    class InvoicePosClass
    {
        public string Product_Name;
        public string Product_Code;
        public int Quantity;
        public string Unit_Of_Measure;
        public float Net_Value;
        public float Vat_Value;
        public float Gross_Value;
        public int Vat;
        public int Id_Invoice;

        public InvoicePosClass(string productName, string productCode, int quantity, string unitOfMeasure,
            float netValue, float Vatvalue, float grossValue, int vat, int idInvoice)
        {
            this.Product_Name = productName;
            this.Product_Code = productCode;
            this.Quantity = quantity;
            this.Unit_Of_Measure = unitOfMeasure;
            this.Net_Value = netValue;
            this.Vat_Value = Vatvalue;
            this.Gross_Value = grossValue;
            this.Vat = vat;
            this.Id_Invoice = idInvoice;
        }

        public InvoicePosClass()
        {
            
        }
    }
}
