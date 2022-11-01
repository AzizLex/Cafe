using System.ComponentModel.DataAnnotations;

namespace Cafe.Models
{
    public class Gallery
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]

        public DateTime TimeStamp { get; set; }
        public string Description { get; set; }
        public virtual IList<GalleryImage> Images { get; set; }
        public Gallery()
        {

        }
    }
}
