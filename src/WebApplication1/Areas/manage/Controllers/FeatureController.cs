using Hook.Business.Services.Interfaces;
using Hook.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hook.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
           _featureService = featureService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _featureService.GetAllAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Feature feature)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                await _featureService.CreateAsync(feature);
            }
            catch (NullReferenceException ex)
            {
                return View("error");
               
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",ex.Message);
                return View("error");

            }

            return RedirectToAction("Index");

        }
    }
}
