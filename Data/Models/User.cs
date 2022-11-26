using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Email{ get; set; }=string.Empty;

        [Required]
        public string Password { get; set; }= string.Empty;

        public bool IsAdmin { get; set; }=false;


        public List<Subscription> Subscription { get; set; }


    }
}
