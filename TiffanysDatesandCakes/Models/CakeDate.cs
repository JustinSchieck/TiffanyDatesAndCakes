namespace TiffanysDatesandCakes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CakeDate
    {
        public string CakeDateId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime EditDate { get; set; }

        [Required]
        [StringLength(128)]
        public string CakeId { get; set; }

        [Required]
        [StringLength(128)]
        public string GenreId { get; set; }

        [Required]
        [StringLength(128)]
        public string DateId { get; set; }

        public virtual Cake Cake { get; set; }

        public virtual Date Date { get; set; }
    }
}
