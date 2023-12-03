using System.ComponentModel.DataAnnotations;

namespace PustokMVC.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(128)]
        public string Title { get; set; }
        [Required, MinLength(3), MaxLength(128)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required, MinLength(3), MaxLength(128)]
        public string ImgUrl { get; set; }
        public bool IsRight { get; set; }
    }
}
