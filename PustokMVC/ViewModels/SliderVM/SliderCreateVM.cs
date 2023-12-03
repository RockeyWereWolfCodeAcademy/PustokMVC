using System.ComponentModel.DataAnnotations;

namespace PustokMVC.ViewModels.SliderVM
{
    public class SliderCreateVM
    {
        [Required, MinLength(3, ErrorMessage = "must be longer than 3 symbols"), MaxLength(128)]
        public string Title { get; set; }
        [Required, MinLength(3, ErrorMessage = "must be longer than 3 symbols"), MaxLength(128)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required, MinLength(3, ErrorMessage = "must be longer than 3 symbols"), MaxLength(128)]
        public string ImgUrl { get; set; }
        public bool Position { get; set; }
    }
}
