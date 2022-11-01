using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Cafe.Models
{
    public class About
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10000)] /*Just nu begränsad  till 10'000*/
        public string Name { get; set; }

        public string Description { get; set; }

        public string Motto { get; set; }

        public string URL { get; set; }

        public About()
        {

        }

    }
}
