namespace TiffanysDatesandCakes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Date
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Date()
        {
            CakeDates = new HashSet<CakeDate>();
            Cakes = new HashSet<Cake>();
        }

        [Key]
        public string DateId { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Date")]
        public string Name { get; set; }

        [Display(Name = "Create Date")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Edit Date")]
        public DateTime EditDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Display(Name = "Cakes")]
        public virtual ICollection<CakeDate> CakeDates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cake> Cakes { get; set; }
    }
}
