using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Invoice
{
    class Users
    {

        public string userLogin;
        public string userPassword;
        public int userRole;

//        private DataBase dataBase = new DataBase();




        public Users(string userLogin, string userPassword, int userRole)
        {

            this.userLogin = userLogin;
            this.userPassword = userPassword;
            this.userRole = userRole;
        }

        public Users()
        {
        }


        public string getUserLogin()
        {
            return this.userLogin;
        }

        public int getUserRole()
        {
            return this.userRole;
        }

        public string getUserPassword()
        {

            return this.userPassword;
        }

        

        public void setUserLogin(string _userLogin)
        {
            this.userLogin = _userLogin;
        }

    }

}
