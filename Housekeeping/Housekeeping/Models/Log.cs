using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Housekeeping.Models
{
    public class Log
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int RoomNo { get; set; }
        [Required]
        public int Assignee { get; set; }
        public int AssignedEmployee { get; set; }
        [Required]
        public string StatusChangedFrom { get; set; }
        [Required]
        public string StatusChangedTo { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
