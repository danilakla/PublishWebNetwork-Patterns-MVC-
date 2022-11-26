using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Desctiprion { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public List<User> User { get; set; }

		public List<Publish> Publish { get; set; }


	}
}
