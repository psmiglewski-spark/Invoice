using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Invoice
{
    class DataBase
    {
        Setup properties = new Setup();

        public DataBase()
        {
            properties.SetBackupProperties(System.IO.Directory.GetCurrentDirectory() + @"\Config\config.ini");
        }
        

       public bool CheckDbConnection()
        {
            
            var connectionString = properties.GetConnectionString();
            var _check = false;



            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                sqlConnection.Close();
                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }



            return _check;
        }

        // Insert queries

        //Adds new client
        /*
         * string NIP
           ,string Name
           ,string Short_Name
           ,string Address_Street
           ,string Address_Pos_Number
           ,string Address_Loc_Number
           ,string Address_Postal_Code
           ,string Address_City
           ,string Address_Country
           ,string Client_Type
           ,int Discount
           ,string Payment_Method
           ,string Phone_Number
           ,string Account_Number
           ,string Mobile_Phone
           ,string SWIFT
           ,string Account_Bank
           ,string Email
           ,int SplitPayment
           ,string WWW
         */
        public void InsertClient(Client client)
        {

            string connectionString = properties.GetConnectionString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {

                string addQuery = @"INSERT INTO [dbo].[Client]
           ([NIP]
           ,[Name]
           ,[Short_Name]
           ,[Address_Street]
           ,[Address_Pos_Number]
           ,[Address_Loc_Number]
           ,[Address_Postal_Code]
           ,[Address_City]
           ,[Address_Country]
           ,[Client_Type]
           ,[Discount]
           ,[Payment_Method]
           ,[Phone_Number]
           ,[Account_Number]
           ,[Mobile_Phone]
           ,[SWIFT]
           ,[Account_Bank]
           ,[Email]
           ,[SplitPayment]
           ,[WWW])
     VALUES
           (@NIP
           ,@Name
           ,@Short_Name
           ,@Address_Street
           ,@Address_Pos_Number
           ,@Address_Loc_Number
           ,@Address_Postal_Code
           ,@Address_City
           ,@Address_Country
           ,@Client_Type
           ,@Discount
           ,@Payment_Method
           ,@Phone_Number
           ,@Account_Number
           ,@Mobile_Phone
           ,@SWIFT
           ,@Account_Bank
           ,@Email
           ,@SplitPayment
           ,@WWW)";

                SqlCommand sqlCommand = new SqlCommand(addQuery, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@NIP", client.GetNIP());
                sqlCommand.Parameters.AddWithValue("@Name", client.GetName());
                sqlCommand.Parameters.AddWithValue("@Short_Name", client.GetShort_Name());
                sqlCommand.Parameters.AddWithValue("@Address_Street", client.GetAddress_Street());
                sqlCommand.Parameters.AddWithValue("@Address_Pos_Number", client.GetAddress_Pos_Number());
                sqlCommand.Parameters.AddWithValue("@Address_Loc_Number", client.GetAddress_Loc_Number());
                sqlCommand.Parameters.AddWithValue("@Address_Postal_Code", client.GetAddress_Postal_Code());
                sqlCommand.Parameters.AddWithValue("@Address_City", client.GetAddress_City());
                sqlCommand.Parameters.AddWithValue("@Address_Country", client.GetAddress_Country());
                sqlCommand.Parameters.AddWithValue("@Client_Type", client.GetClient_Type());
                sqlCommand.Parameters.AddWithValue("@Discount", client.GetDiscount());
                sqlCommand.Parameters.AddWithValue("@Payment_Method", client.GetPayment_Method());
                sqlCommand.Parameters.AddWithValue("@Phone_Number", client.GetPhone_Number());
                sqlCommand.Parameters.AddWithValue("@Account_Number", client.GetAccount_Number());
                sqlCommand.Parameters.AddWithValue("@Mobile_Phone", client.GetMobile_Phone());
                sqlCommand.Parameters.AddWithValue("@SWIFT", client.GetSWIFT());
                sqlCommand.Parameters.AddWithValue("@Account_Bank", client.GetAccount_Bank());
                sqlCommand.Parameters.AddWithValue("@Email", client.GetEmail());
                sqlCommand.Parameters.AddWithValue("@SplitPayment", client.GetSplitPayment());
                sqlCommand.Parameters.AddWithValue("@WWW", client.GetWWW());
                sqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                 // File.WriteAllText(@"c:\temp\bugs\bug" + DateTime.Now.ToString() + ".txt", e.ToString());

            }
            finally
            {
                sqlConnection.Close();
            }
        }
        /* Adds invoice */
        public void InsertInvoice(InvoiceClass invoice)
        {
            string connectionString = properties.GetConnectionString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {

                string addQuery = @"INSERT INTO [dbo].[Invoice]
           ([Invoice_Number]
           ,[ID_Client]
           ,[Client_Name]
           ,[Client_NIP]
           ,[Client_Address_Street]
           ,[Client_Address_Pos_Number]
           ,[Client_Address_Loc_Number]
           ,[Client_Address_Postal_Code]
           ,[Client_Address_City]
           ,[Client_Address_Country]
           ,[Issue_Date]
           ,[Sale_Date]
           ,[Payment_Date]
           ,[Payment_Method]
           ,[Payment_Account]
           ,[SplitPayment]
           ,[Note]
           ,[Net_Value]
           ,[Gross_Value]
           ,[VAT_Value]
           ,[VAT]
           ,[Issuing_User])
     VALUES
           (@Invoice_Number
           ,@ID_Client
           ,@Client_Name
           ,@Client_NIP
           ,@Client_Address_Street
           ,@Client_Address_Pos_Number
           ,@Client_Address_Loc_Number
           ,@Client_Address_Postal_Code
           ,@Client_Address_City
           ,@Client_Address_Country
           ,@Issue_Date
           ,@Sale_Date
           ,@Payment_Date
           ,@Payment_Method
           ,@Payment_Account
           ,@SplitPayment
           ,@Note
           ,@Net_Value
           ,@Gross_Value
           ,@VAT_Value
           ,@VAT
           ,@Issuing_User)";

                SqlCommand sqlCommand = new SqlCommand(addQuery, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Invoice_Number", invoice.Invoice_Number);
                sqlCommand.Parameters.AddWithValue("@ID_Client", invoice.ID_Client);
                sqlCommand.Parameters.AddWithValue("@Client_Name", invoice.Client_Name);
                sqlCommand.Parameters.AddWithValue("@Client_NIP", invoice.Client_NIP);
                sqlCommand.Parameters.AddWithValue("@Client_Address_Street", invoice.Client_Address_Street);
                sqlCommand.Parameters.AddWithValue("@Client_Address_Pos_Number", invoice.Client_Address_Pos_Number);
                sqlCommand.Parameters.AddWithValue("@Client_Address_Loc_Number", invoice.Client_Address_Loc_Number);
                sqlCommand.Parameters.AddWithValue("@Client_Address_Postal_Code", invoice.Client_Address_Postal_Code);
                sqlCommand.Parameters.AddWithValue("@Client_Address_City", invoice.Client_Address_City);
                sqlCommand.Parameters.AddWithValue("@Client_Address_Country", invoice.Client_Address_Country);
                sqlCommand.Parameters.AddWithValue("@Issue_Date", invoice.Issue_Date);
                sqlCommand.Parameters.AddWithValue("@Sale_Date", invoice.Sale_Date);
                sqlCommand.Parameters.AddWithValue("@SplitPayment", invoice.SplitPayment);
                sqlCommand.Parameters.AddWithValue("@Payment_Date", invoice.Payment_Date);
                sqlCommand.Parameters.AddWithValue("@Payment_Method", invoice.Payment_Method);
                sqlCommand.Parameters.AddWithValue("@Payment_Account", invoice.Payment_Account);
                sqlCommand.Parameters.AddWithValue("@Note", invoice.Note);
                sqlCommand.Parameters.AddWithValue("@Net_Value", invoice.Net_Value);
                sqlCommand.Parameters.AddWithValue("@Gross_Value", invoice.Gross_Value);
                sqlCommand.Parameters.AddWithValue("@Vat_Value", invoice.VAT_Value);
                sqlCommand.Parameters.AddWithValue("@VAT", invoice.VAT);
                sqlCommand.Parameters.AddWithValue("@Issuing_User", invoice.Issuing_User);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                // File.WriteAllText(@"c:\temp\bugs\bug" + DateTime.Now.ToString() + ".txt", e.ToString());

            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void InsertInvoicePos(InvoicePosClass invoicePos)
        {
            string connectionString = properties.GetConnectionString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {

                string addQuery = @"INSERT INTO [dbo].[Invoice_Pos]
           ([Product_Name],
            [Product_Code],
            [Quantity],
            [Unit_Of_Measure],
            [Net_Value],
            [Vat_Value],
            [Gross_Value],
            [VAT],
            [ID_Invoice])
     VALUES
           (@Product_name,
            @Product_code,
            @Quantity,
            @Unit_of_measure,
            @Net_value,
            @Vat_value,
            @Gross_value,
            @Vat,
            @ID_invoice)";

                SqlCommand sqlCommand = new SqlCommand(addQuery, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Product_name", invoicePos.Product_Name);
                sqlCommand.Parameters.AddWithValue("@Product_code", invoicePos.Product_Code);
                sqlCommand.Parameters.AddWithValue("@Quantity", invoicePos.Quantity);
                sqlCommand.Parameters.AddWithValue("@Unit_of_measure", invoicePos.Unit_Of_Measure);
                sqlCommand.Parameters.AddWithValue("@Net_value", invoicePos.Net_Value);
                sqlCommand.Parameters.AddWithValue("@Vat_Value", invoicePos.Vat_Value);
                sqlCommand.Parameters.AddWithValue("@Gross_value", invoicePos.Gross_Value);
                sqlCommand.Parameters.AddWithValue("@Vat", invoicePos.Vat);
                sqlCommand.Parameters.AddWithValue("@ID_invoice", invoicePos.Id_Invoice);
                
                sqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                // File.WriteAllText(@"c:\temp\bugs\bug" + DateTime.Now.ToString() + ".txt", e.ToString());

            }
            finally
            {
                sqlConnection.Close();
            }
        }

        //Update queries

        //Delete queries

        //Select queries
        public DataTable SelectClient(int clientId)
        {
            var ds = new DataTable();
            string connectionString = properties.GetConnectionString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            var sqlCommand = "Select Top 1 * from Client where ClientID = " + clientId;
            try
            {
                
                var da = new SqlDataAdapter(sqlCommand,sqlConnection);
                da.Fill(ds);
                

                // string addQuery = @"Select Top 1 * from Client";

                //SqlCommand sqlCommand = new SqlCommand(addQuery, sqlConnection);
                //sqlConnection.Open();

                //  sqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                // File.WriteAllText(@"c:\temp\bugs\bug" + DateTime.Now.ToString() + ".txt", e.ToString());

            }
            finally
            {
                sqlConnection.Close();
            }

            return ds;
        }

        public DataTable SelectInvoicePos(int invoiceId)
        {
            var ds = new DataTable();
            string connectionString = properties.GetConnectionString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            var sqlCommand = "Select * from Invoice_Pos where ID_Invoice = " + invoiceId;

            try
            {

                var da = new SqlDataAdapter(sqlCommand, sqlConnection);
                da.Fill(ds);


                // string addQuery = @"Select Top 1 * from Client";

                //SqlCommand sqlCommand = new SqlCommand(addQuery, sqlConnection);
                //sqlConnection.Open();

                //  sqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                // File.WriteAllText(@"c:\temp\bugs\bug" + DateTime.Now.ToString() + ".txt", e.ToString());

            }
            finally
            {
                sqlConnection.Close();
            }

            return ds;
        }

        public DataTable SelectInvoice(int invoiceId)
        {
            var ds = new DataTable();
            string connectionString = properties.GetConnectionString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            var salCommand = "Select * from Invoice where invoiceID =  " + invoiceId ;

            try
            {

                var da = new SqlDataAdapter(salCommand, sqlConnection);
                da.Fill(ds);


                // string addQuery = @"Select Top 1 * from Client";

                //SqlCommand sqlCommand = new SqlCommand(addQuery, sqlConnection);
                //sqlConnection.Open();

                //  sqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                // File.WriteAllText(@"c:\temp\bugs\bug" + DateTime.Now.ToString() + ".txt", e.ToString());

            }
            finally
            {
                sqlConnection.Close();
            }

            return ds;
        }
    }
}
