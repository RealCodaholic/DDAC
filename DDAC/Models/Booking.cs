using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DDAC.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingID { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double TotalCost { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        [ForeignKey("SourceDock")]
        public int Source { get; set; }
        public virtual ShipDock SourceDock { get; set; }

        [Required]
        [ForeignKey("DestinationDock")]
        public int Destination { get; set; }
        public virtual ShipDock DestinationDock { get; set; }
    }
}