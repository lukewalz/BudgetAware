using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using BudgetAware.Dal;

namespace BudgetAware
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string _emailAddress = email.Value;
            string _password = pwd.Value;

            bool isEmailValid = ValidateEmail(_emailAddress);

            if (isEmailValid)
            {
                VerifyAccount(_emailAddress, _password);
            }
            else
            {
                //invalid
            }
        }

        private bool ValidateEmail(string emailAddress)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (!string.IsNullOrEmpty(emailAddress))
            {
                if (regex.IsMatch(emailAddress))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        private void VerifyAccount(string emailAddress, string password)
        {
            UsersDb usersDb = new UsersDb();
            Users user = usersDb.GetUserByEmail(emailAddress);
            if (user.Id != 0)
            {
                if (user.Password == password)
                {
                    Application["LoggedIn"] = user.Id;
                    Response.Redirect("~/Index.aspx");
                }
            }

        }
    }
}