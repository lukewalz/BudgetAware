using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BudgetAware
{
    public partial class Register : System.Web.UI.Page
    {
        public User user { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            bool _isValueNull = CheckForNulls();
            if (!_isValueNull)
            {
                bool _isUsernameUnique = CheckUsernameIsUnique();
                if (_isUsernameUnique)
                {
                    bool _userAdded = AddUserToTable();
                    if (_userAdded)
                    {
                        bool _accountAdded = AddAccountToTable();
                        Application["LoggedIn"] = user;
                        Response.Redirect("~/Index.aspx");
                    }
                }
            }
        }

        private bool AddAccountToTable()
        {
            throw new NotImplementedException();

        }

        private bool AddUserToTable()
        {
            throw new NotImplementedException();
        }

        private bool CheckForNulls()
        {
            throw new NotImplementedException();
        }

        private bool CheckUsernameIsUnique()
        {
            throw new NotImplementedException();
        }
    }
}