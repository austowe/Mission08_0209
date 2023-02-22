using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission08_0209.Models
{
    public class Task
    {
        [Key]
        [Required]
        public int TaskId { get; set; }
        [Required]
        [MaxLength(25)]
        public string Task_Name { get; set; }
        public string Due_Date { get; set; }
        public bool Completed { get; set; }


        // foriegn key for Quadrant
        [Required]
        public int QuadrantId { get; set; }
        public Quadrant Quadrant { get; set; }

        // foriegn key for Category
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
