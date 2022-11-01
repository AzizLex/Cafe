using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe.Models
{

    public class VenueImage
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        
        public int VenueId { get; set; }

        [HiddenInput]
        public string URL { get; set; }


        public virtual Venue Venue { get; set; }

        public VenueImage()
        {

        }
    }
}
