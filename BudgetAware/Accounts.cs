namespace BudgetAware
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Accounts()
        {
            Purchases = new HashSet<Purchases>();
        }

        [Key]
        public long AccountNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountType { get; set; }

        [Column(TypeName = "money")]
        public decimal Balance { get; set; }

        public int Fk_UserId { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchases> Purchases { get; set; }
    }
}
