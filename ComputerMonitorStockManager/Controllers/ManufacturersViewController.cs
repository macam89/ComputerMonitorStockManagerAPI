using System.Collections.Generic;
using System.Linq;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace ComputerMonitorStockManager.Controllers
{
    
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ManufacturersViewController : Controller
    {
        private readonly IManufacturerService _manufacturers;

        public ManufacturersViewController(IManufacturerService manufacturers)
        {
            _manufacturers = manufacturers;
        }


        [Route("~/Manufacturers")]
        public ActionResult Manufacturers()
        {
            var manufacturers = _manufacturers.GetAllManufacturers();
            return View(manufacturers.ToList());
        }


        [Route("~/Manufacturers/{id}")]
        public ActionResult Details(int id)
        {
            var manufacturer = _manufacturers.GetManufacturer(id);
            return View(manufacturer);
        }


        [Route("~/Manufacturers/Create")]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [Route("~/Manufacturers/Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Manufacturers manufacturer)
        {
            var resultDictionary = _manufacturers.AddNewManufacturer(manufacturer);

            if (resultDictionary.ContainsKey("BadRequest"))
            {
                ModelState.AddModelError(string.Empty, "Manufacturer already exist.");
                return View();
            }
            
            Manufacturers newManufacturer = resultDictionary.GetValueOrDefault("Created");
            return RedirectToAction("Details", "ManufacturersView", new { id = newManufacturer.ManufacturerID });
        }


        [Route("~/Manufacturers/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            return View();
        }


        [HttpPost]
        [Route("~/Manufacturers/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Manufacturers manufacturer)
        {
            var resultDictionary = _manufacturers.UpdateManufacturer(id, manufacturer);
            
            if (resultDictionary.ContainsKey("BadRequest"))
            {
                 ModelState.AddModelError(string.Empty, "Manufacturer with that name already exist.");
                return View();
            }
            else if (resultDictionary.ContainsKey("NoContent"))
            {
                return RedirectToAction("Details", "ManufacturersView", new { id });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Manufacturer not found.");
                return View();
            }

        }


        [Route("~/Manufacturers/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            bool deleted = _manufacturers.DeleteManufacturer(id);
            if (deleted)
            {
                 return RedirectToAction("Manufacturers");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Manufacturer does not exist.");
                return View();
            }
        }


    }
}
