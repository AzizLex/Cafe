using System.ComponentModel.DataAnnotations;

namespace Cafe.Models
{
    public class Option
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
