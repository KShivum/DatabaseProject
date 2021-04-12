using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Housekeeping.Models
{
    public class Room
    {
        [Key]
        public int RoomNo { get; set; }
        [Required]
        public string Status { get; set; }
        public int AssignedEmployee { get; set; }
    }
}
