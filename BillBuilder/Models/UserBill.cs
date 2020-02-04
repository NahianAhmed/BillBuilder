using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CURD.Models
{
    public class UserBill
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string bill { get; set; }
        [Required]
        public string userID { get; set; }
    }
}
