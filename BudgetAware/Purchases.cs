namespace BudgetAware
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Purchases
    {
        public int Id { get; set; }

        public int Fk_CategoryId { get; set; }

        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        [Required]
        [StringLength(50)]
        public string Company { get; set; }

        [Column(TypeName = "date")]
        public DateTime PurchaseDate { get; set; }

        public long Fk_AccountNumber { get; set; }

        public virtual Accounts Accounts { get; set; }

        public virtual Categories Categories { get; set; }
    }
}
