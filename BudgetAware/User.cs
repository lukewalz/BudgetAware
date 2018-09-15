using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetAware
{
    [Serializable]
    public class User
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public DateTime Birthday { get; set; }
    }
}