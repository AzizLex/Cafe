using System.ComponentModel.DataAnnotations;

namespace Cafe.Models
{
    public class ExtraService
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public double? Price { get; set; }
        public bool Checked { get; set; }   
        public virtual IList<BookingForm> Bookings {get; set;}
        public ExtraService()
        {

        }
    }
}
