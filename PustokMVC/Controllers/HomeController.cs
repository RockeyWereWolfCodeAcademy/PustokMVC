using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokMVC.Contexts;
using PustokMVC.ViewModels.SliderVM;
using System.Diagnostics;

namespace PustokMVC.Controllers
{
    public class HomeController : Controller
    {
        PustokDbContext _context { get; }

        public HomeController(PustokDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var sliders = await _context.Sliders.Select(slider => new SliderListVM
            {
                Id = slider.Id,
                Title = slider.Title,
                Description = slider.Description,
                Price = slider.Price,
                ImgUrl = slider.ImgUrl,
                IsRight = slider.IsRight
            }).ToListAsync();
            return View(sliders);
        }
    }
}