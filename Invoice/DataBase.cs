using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
           ,[Issuing_User]
           ,[Currency]
           ,[Currency_Change_Rate],
           ,[Kwota_Slownie]
           ,[VAT_Account])
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
           ,@Issuing_User
           ,@Currency
           ,@Currency_Change_Rate
           ,@Kwota_Slownie
           ,@VAT_Account)";

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
                sqlCommand.Parameters.AddWithValue("@Currency", invoice.Currency);
                sqlCommand.Parameters.AddWithValue("@Currency_Change_Rate", invoice.Currency_Change_Rate);
                sqlCommand.Parameters.AddWithValue("@Kwota_Slownie", invoice.Kwota_Slownie);
                sqlCommand.Parameters.AddWithValue("@VAT_Account", invoice.VAT_Account);
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
        //Adds invoice position
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
        //Adds User
        public void AddUser(string userName, string userSecondName, string userLogin, string password, string userRole)
        {

            //string passwordEncrypted;
            //passwordEncrypted = Security.Encrypt(password, key);
            string connectionString = properties.GetConnectionString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {

                string addQuery = "insert into dbo.Users values (@userName, @userSecondName, @userLogin, @password,@userRole)";
                SqlCommand sqlCommand = new SqlCommand(addQuery, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@userName", userName);
                sqlCommand.Parameters.AddWithValue("@userSecondName", userSecondName);
                sqlCommand.Parameters.AddWithValue("@userLogin", userLogin);
                sqlCommand.Parameters.AddWithValue("@password", password);
                sqlCommand.Parameters.AddWithValue("@userRole", userRole);
                
                sqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                //  File.WriteAllText(@"c:\temp\bugs\bug" + DateTime.Now.ToString() + ".txt", e.ToString());

            }
            finally
            {
                sqlConnection.Close();
            }
        }

        //Update queries
        public void UpdateUser(string userLogin, string password, int role)
        {
            string connectionString = properties.GetConnectionString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {

                string updateQuery = "update dbo.Users set User_Password = @password, User_Role = @role  where User_Login = @userLogin ";
                SqlCommand sqlCommand = new SqlCommand(updateQuery, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@userLogin", userLogin);
                sqlCommand.Parameters.AddWithValue("@role", role);
                sqlCommand.Parameters.AddWithValue("@password", password);
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
        
        
        //Delete queries
        //Deletes user by userName
        public void DeleteUser(string userLogin)
        {
            string connectionString = properties.GetConnectionString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {

                string deleteQuery = "delete from dbo.Users where User_Login = @userLogin ";
                SqlCommand sqlCommand = new SqlCommand(deleteQuery, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@userLogin", userLogin);
                // sqlCommand.Parameters.AddWithValue("@userRole", userRole);
                // sqlCommand.Parameters.AddWithValue("@password", password);
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
      
        
        
        //Select queries
        //Return Client table for reporting
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
        //Return Invoice_Pos table for reporting
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
        //Return Multiple VAT sums for invoice reporting
        public DataTable ReportVatTableInvoicePos(int invoiceId)
        {
            var ds = new DataTable();
            string connectionString = properties.GetConnectionString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            var sqlCommand = "select Sum(net_value) as Net_Value, sum(Vat_value) as VAT_Value, sum(Gross_value) as Gross_Value, VAT from invoice_pos where ID_Invoice =" + invoiceId + " group by VAT " ;

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
        //Return Invoice table for reporting
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
        //Returns dataset of all invoices
        public DataTable SelectAllInvoices()
        {
            var ds = new DataTable();
            string connectionString = properties.GetConnectionString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            var salCommand = "Select * from Invoice" ;

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
        //Returns user ID from user login
        public int IsLogged(string loginInfo)
        {
            int _loginId = -1;
            string connectionString = properties.GetConnectionString();

            string queryUser = "select top 1 Id from dbo.Users where User_Login = @userLogin";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlDataAdapter userNameAdapter = new SqlDataAdapter(queryUser, sqlConnection);
            List<DataRow> userList = new List<DataRow>();
            using (userNameAdapter)
            {
                DataTable userData = new DataTable();
                userNameAdapter.SelectCommand.Parameters.AddWithValue("@userLogin", loginInfo);
                userNameAdapter.Fill(userData);

                foreach (DataRow dr in userData.Rows)
                {
                    userList.Add(dr);
                }
            }
            if (userList.Count() > 0)
            {

                _loginId = (int)userList[0]["Id"];

            }

            return _loginId;
        }
        //Returns user role from user id
        public int GetUserRoleFromId(char _userId)
        {
            string connectionString = properties.GetConnectionString();
            int _loginId = (int)_userId;
            int _role = -100;


            string queryUser = "select top 1 User_Role from dbo.Users where UserId = @Id";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlDataAdapter userNameAdapter = new SqlDataAdapter(queryUser, sqlConnection);
            List<DataRow> userList = new List<DataRow>();
            using (userNameAdapter)
            {
                DataTable userData = new DataTable();
                userNameAdapter.SelectCommand.Parameters.AddWithValue("@Id", _loginId);
                userNameAdapter.Fill(userData);

                foreach (DataRow dr in userData.Rows)
                {
                    userList.Add(dr);
                }
            }

            if (userList.Count() > 0)
            {

                _role = (int)userList[0]["userRole"];

            }

            return _role;
        }
        //Returns true if login and password correct, false if not
        public bool CheckLogin(string user, string pass)
        {
            string connectionString = properties.GetConnectionString();
            var _user = new Users();
            string _userLogin = _user.getUserLogin();
            string _userPassword = _user.getUserPassword();
            int _userRole = _user.getUserRole();

            string queryUser = "select top 1 User_Login, User_Password from dbo.Users where User_Login = @userLogin";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlDataAdapter userNameAdapter = new SqlDataAdapter(queryUser, sqlConnection);
            List<DataRow> userList = new List<DataRow>();

            // string passwordDecrypted = "";

            using (userNameAdapter)
            {
                DataTable userData = new DataTable();
                userNameAdapter.SelectCommand.Parameters.AddWithValue("@userLogin", user);
                userNameAdapter.Fill(userData);

                foreach (DataRow dr in userData.Rows)
                {
                    userList.Add(dr);
                }
            }
            if (userList.Count() > 0)
            {

                _userLogin = userList[0]["User_Login"].ToString();
                _userPassword = userList[0]["User_Password"].ToString();
               
            }
            if ((user == _userLogin) && (pass == _userPassword))
            {
                

                string userLoginData = user;
                try
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(System.IO.Directory.GetCurrentDirectory() + "\\login.tmp", FileMode.Create))
                    {
                        using (StreamWriter fw = new StreamWriter(fs))
                        {
                            fw.Write(userLoginData, 0, userLoginData.Length);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                return true;

                //addLoginInfo(user, 1, DateTime.Now);
                //  this.Visibility = Visibility.Collapsed;
            }
            else
            {
                return false;
                //  addLoginInfo(user, 0, DateTime.Now);
            }
        }

    }
}
