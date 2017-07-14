using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DDAC.Models
{
    public class ShipDock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShipDockID { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Country { get; set; }
    }
}