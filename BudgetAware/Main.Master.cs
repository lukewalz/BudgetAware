using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BudgetAware
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {
                accountLinks.Visible = false;
                signOutPanel.Visible = true;
            }
            else
            {
                accountLinks.Visible = true;
                signOutPanel.Visible = false;
            }
        }

        protected void signOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/Login.aspx");
        }

        protected void signOut_Click1(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/Login.aspx");
        }
    }
}