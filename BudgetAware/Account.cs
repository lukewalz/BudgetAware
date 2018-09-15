using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetAware
{
    public class Account
    {
        public long AccountNumber { get; set; }

        public string AccountType { get; set; }

        public string Balance { get; set; }

        public int UserId { get; set; }
    }
}