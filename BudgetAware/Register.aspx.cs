using BudgetAware.Dal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BudgetAware
{
    public partial class Register : System.Web.UI.Page
    {
        public Users user { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            Users _user = new Users();
            _user.FirstName = fName.Value;
            _user.LastName = lName.Value;
            _user.EmailAddress = email.Value;
            _user.Password = pwd.Value;
            _user.Birthday = DateTime.Parse(dob.Value);

            if (!DoesUserExist(_user.EmailAddress))
            {
                UsersDb _usersDb = new UsersDb();

                if (pwd.Value == cpwd.Value)
                {
                    int userId = _usersDb.AddUser(_user);

                    Random rnd = new Random();
                    decimal _balance = rnd.Next(100, 1000000);
                    Accounts _account = new Accounts();
                    _account.AccountNumber = Convert.ToInt32(accountNum.Value.ToString());
                    _account.AccountType = accounttype.Value;
                    _account.Fk_UserId = userId;
                    _account.Balance = _balance;

                    AccountDb _accountDb = new AccountDb();
                    int account = _accountDb.AddAccount(_account);
                    _user.Id = userId;
                }

            }


            Application["LoggedIn"] = _user.Id.ToString();
            Response.Redirect("/Index.aspx");
        }

        private bool DoesUserExist(string email)
        {

            UsersDb _usersDb = new UsersDb();
            Users user = _usersDb.GetUserByEmail(email);

            if (user.Id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckForNulls()
        {
            throw new NotImplementedException();
        }
    }
}