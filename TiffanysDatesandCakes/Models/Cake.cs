namespace TiffanysDatesandCakes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cake
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cake()
        {
            CakeDates = new HashSet<CakeDate>();
        }

        [Key]
        public string CakeId { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Cake")]
        public string Name { get; set; }

        [Display(Name = "Create Date")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Edit Date")]
        public DateTime EditDate { get; set; }

        [Display(Name = "Cake")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CakeDate> CakeDates { get; set; } = new HashSet<CakeDate>();

    }
}
