using System.ComponentModel.DataAnnotations;
using Cafe.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Cafe.Models

{
    public class BookingForm
    {

        public int Id { get; set; }

        public DateTime TimeStamp { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Namn")]
        public string Name { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Lokal")]
        public virtual IList<Venue> Venues { get; set; }

        [StringLength(150)]
        [Display(Name = "Antal gäster, totalt")]
        public string Guests { get; set; }

         [StringLength(150)]
        [Display(Name = "Matval")]
        public string Cuisine { get; set; }
        
        [StringLength(150)]
        [Display(Name = "Antal ätande gäster")]
        public string Plates { get; set; }

        [Display(Name = "Extra tjänster")]
        public virtual IList<ExtraService> Extras { get; set; }

        [Display(Name = "Ev. kommentar eller frågor")]
        public string Comment { get; set; }


        public bool ReadStatus { get; set; }

        public BookingForm()
        {

        }

    }
}