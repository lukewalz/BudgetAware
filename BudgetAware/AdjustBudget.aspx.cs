using BudgetAware.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BudgetAware
{
    public partial class AdjustBudget : System.Web.UI.Page
    {
        private Users currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["LoggedIn"] != null)
            {
                UsersDb usersDb = new UsersDb();
                Users user = usersDb.GetUserById(Convert.ToInt32(Application["LoggedIn"]));
                currentUser = user;
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
        private void AddBudgetToTable()
        {
            Budget budget = new Budget();
            budget.Fk_UserId = currentUser.Id;
            budget.Amount = Convert.ToDecimal(budgetAmount.Value);
            budget.Fk_CategoriesId = Convert.ToInt32(budgetCategory.Value);

            BudgetDb budgetDb = new BudgetDb();
            budgetDb.AddBudget(budget);
        }

        protected void submitBudget_Click(object sender, EventArgs e)
        {
            AddBudgetToTable();
            Response.Redirect("/Index.aspx");
        }
    }
}