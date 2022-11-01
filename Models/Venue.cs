using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe.Models
{
    public class Venue
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [StringLength(250)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public string Area { get; set; }
        public string Guests { get; set; }
        public string Table { get; set; }
        public string Equipment { get; set; }
        public string Other { get; set; }

        [Display(Name = "Price")]
        public double? Price { get; set; }

        public virtual IList<VenueImage> Images { get; set; }
        public virtual IList<BookingForm> Bookings { get; set; }
        public Venue()
        {

        }

    }
}

