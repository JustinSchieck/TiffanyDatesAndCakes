namespace TiffanysDatesandCakes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CakeDate
    {

        [Key]
        public string CakeDateId { get; set; }

        [Display(Name = "Create Date")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Edit Date")]
        public DateTime EditDate { get; set; }

        [Required]
        [StringLength(128)]
        public string CakeId { get; set; }

        [Required]
        [StringLength(128)]
        public string DateId { get; set; }

        [ForeignKey("CakeId")]
        public virtual Cake Cake { get; set; }

        [ForeignKey("DateId")]
        public virtual Date Date { get; set; }

        public override string ToString()
        {
            return String.Format("{0} - {1}", Cake.ToString(), Date.ToString());
        }

    }
}
