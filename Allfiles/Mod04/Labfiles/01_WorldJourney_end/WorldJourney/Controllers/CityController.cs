using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using WorldJourney.Filters;
using WorldJourney.Models;

namespace WorldJourney.Controllers
{
    public class CityController : Controller
    {
        private readonly IData _data;
        private readonly IWebHostEnvironment _environment;

        public CityController(IData data, IWebHostEnvironment environment)
        {
            _data = data;
            _environment = environment;
            _data.CityInitializeData();
        }

        [ServiceFilter(typeof(LogActionFilterAttribute))]
        [Route("WorldJourney")]
        public IActionResult Index()
        {
            ViewData["Page"] = "Search city";
            return View();
        }

        [Route("CityDetails/{id?}")]
        public IActionResult Details(int? id)
        {
            ViewData["Page"] = "Selected city";
            City city = _data.GetCityById(id);
            if (city == null)
            {
                return NotFound();
            }
            ViewBag.Title = city.CityName;
            return View(city);
        }

        [Route("CityImage/{CityId?}")]
        public IActionResult GetImage(int? cityId)
        {
            ViewData["Message"] = "display Image";
            City requestedCity = _data.GetCityById(cityId);
            if (requestedCity != null)
            {
                var webRootpath = _environment.WebRootPath;
                var folderPath = "\\images\\";
                var fullPath = webRootpath + folderPath + requestedCity.ImageName;
                var fileOnDisk = new FileStream(fullPath, FileMode.Open);
                byte[] fileBytes;
                using (var br = new BinaryReader(fileOnDisk))
                {
                    fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                }
                return File(fileBytes, requestedCity.ImageMimeType);
            }
            else
            {
                return NotFound();
            }
        }
    }
}