using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetAware
{
    public class Purchase
    {
        public long PurchaseId { get; set; }
        public string Category { get; set; }
        public float Cost { get; set; }
        public string Company { get; set; }
        public DateTime PurchaseDate { get; set; }
        public long AccountNumber { get; set; }
    }
}