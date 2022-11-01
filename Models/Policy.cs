using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Cafe.Models
{
    public class Policy
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Lead { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime EditDate { get; set; }

        public Policy()
        {

        }

    }
}
