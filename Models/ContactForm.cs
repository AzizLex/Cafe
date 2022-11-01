using System.ComponentModel.DataAnnotations;
using Cafe.Services;

namespace Cafe.Models

{
    public class ContactForm
    {

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Comment")]
        public string Comment { get; set; }

        [Display(Name = "Created")]
        public DateTime TimeStamp { get; set; }

        public bool ReadStatus { get; set; }

        public ContactForm()
        {

        }
    }
}