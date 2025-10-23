using JadooTravel.Dtos.TestimonialDtos;
using JadooTravel.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IActionResult> TestimonialList()
        {
            var value= await _testimonialService.GetAllTestimonialAsync();
            return View(value);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        { 
            await _testimonialService.CreateTestimonialAsync(createTestimonialDto);
            return RedirectToAction("TestimonialList");
        }
        public async Task<IActionResult> DeleteTestimonial(string id)
        {
            await _testimonialService.DeleteTestimonialAsync(id);
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(string id)
        {
            var value = await _testimonialService.GetTestimonialByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            await _testimonialService.UpdateTestimonialAsync(updateTestimonialDto);
            return RedirectToAction("TestimonialList");
        }

    }
}
