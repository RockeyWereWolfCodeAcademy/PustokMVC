using System.ComponentModel.DataAnnotations;

namespace PustokMVC.ViewModels.SliderVM
{
    public class SliderListVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public bool IsRight { get; set; }
    }
}
