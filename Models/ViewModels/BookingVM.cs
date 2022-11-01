using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;


namespace Cafe.Models.ViewModels

{
    public class BookingVM:BookingForm
    {
        [ValidateNever]
        public string Captcha { get; set; }

        [ValidateNever]
        public override IList<ExtraService> Extras { get; set; }

        [Required]
        public int VenueId { get; set; }

        public BookingVM()
        {

        }

        public BookingVM(IList<Venue> venues, IList<ExtraService> extraServices )
        {
            Venues=venues;
            Extras = extraServices;
        }
    }
}