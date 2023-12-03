using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokMVC.Contexts;
using PustokMVC.Models;
using PustokMVC.ViewModels.SliderVM;

namespace PustokMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : Controller
    { 
        PustokDbContext _context { get; }

        public AdminHomeController(PustokDbContext context)
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

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateVM sliderVM)
        {
            TempData["Response"] = "temp";
            if (!ModelState.IsValid)
            {
                return View(sliderVM);
            }
            Slider slider = new Slider
            {
                Title = sliderVM.Title,
                Description = sliderVM.Description,
                ImgUrl = sliderVM.ImgUrl,
                Price = sliderVM.Price,
                IsRight = sliderVM.Position
            };
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            TempData["Response"] = "created";
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            TempData["Response"] = "temp";
            if (id == null) return BadRequest();
            var data = await _context.Sliders.FindAsync(id);
            if (data == null) return NotFound();
            _context.Sliders.Remove(data);
            await _context.SaveChangesAsync();
            TempData["Response"] = "deleted";
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id <= 0) return BadRequest();
            var data = await _context.Sliders.FindAsync(id);
            if (data == null) return NotFound();
            return View(new SliderUpdateVM
            {
                Title = data.Title,
                Description = data.Description,
                ImgUrl = data.ImgUrl,
                Price = data.Price,
                Position = data.IsRight
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, SliderUpdateVM sliderVM)
        {
            TempData["Response"] = "temp";
            if (!ModelState.IsValid)
            {
                return View(sliderVM);
            }
            var data = await _context.Sliders.FindAsync(id);
            if (data == null) return NotFound();
            data.Title = sliderVM.Title;
            data.Description = sliderVM.Description;
            data.ImgUrl = sliderVM.ImgUrl;
            data.Price = sliderVM.Price;
            data.IsRight = sliderVM.Position;
            await _context.SaveChangesAsync();
            TempData["Response"] = "updated";
            return RedirectToAction(nameof(Index));
        }
    }
}
