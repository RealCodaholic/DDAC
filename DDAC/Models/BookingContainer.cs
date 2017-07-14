using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DDAC.Models
{
    public class BookingContainer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingContainerID { get; set; }

        [Required]
        [ForeignKey("Booking")]
        public int BookingID { get; set; }
        public virtual Booking Booking { get; set; }

        [Required]

        [ForeignKey("Container")]
        public int ContainerID { get; set; }
        public virtual Container Container { get; set; }
    }
}