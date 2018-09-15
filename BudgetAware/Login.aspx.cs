using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace BudgetAware
{
    public partial class Login : System.Web.UI.Page
    {
        public User Session
        {
            get
            {
                return (User)ViewState["LoggedIn"];
            }
            set
            {
                ViewState["LoggedIn"] = value;
            }

        }

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
            string path = "C:\\Users\\lukew\\OneDrive\\Documents\\Visual Studio 2017\\Projects\\BudgetAware\\BudgetAware\\DataObjects\\Users.json";
            RootUserObject rootObject;
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                var e = JsonConvert.DeserializeObject<User>(json);
                rootObject = new JavaScriptSerializer().Deserialize<RootUserObject>(json);
            }

            foreach (User user in rootObject.users)
            {
                if (user.EmailAddress == emailAddress)
                {
                    if (user.Password == password)
                    {
                        Application["LoggedIn"] = user;
                        Response.Redirect("~/Home.aspx");
                    }
                    else
                    {
                        //Wrong Password
                    }
                }
                else
                {
                    //Email not found
                }
            }

        }
    }
}