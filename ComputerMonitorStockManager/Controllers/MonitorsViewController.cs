using System.Collections.Generic;
using System.Linq;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace ComputerMonitorStockManager.Controllers
{
    
    [ApiExplorerSettings(IgnoreApi = true)]
    public class MonitorsViewController : Controller
    {
        private readonly IMonitorService _monitors;

        public MonitorsViewController(IMonitorService monitors)
        {
            _monitors = monitors;
        }


        [Route("~/Monitors")]
        public ActionResult Monitors()
        {
            var monitors = _monitors.GetAllMonitors();
            return View(monitors.ToList());
        }


        [Route("~/Monitors/{id}")]
        public ActionResult Details(int id)
        {
            var monitor = _monitors.GetMonitor(id);
            return View(monitor);
        }


        [Route("~/Monitors/Create")]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [Route("~/Monitors/Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Monitors monitor)
        {
            var resultDictionary = _monitors.AddNewMonitor(monitor);

            if (resultDictionary.ContainsKey("ManufacturerNotExist"))
            {
                ModelState.AddModelError(string.Empty, "Manufacturer does not exist.");
                return View();
            }
            else if (resultDictionary.ContainsKey("ModelAlreadyExist"))
            {
                ModelState.AddModelError(string.Empty, "Model already exist.");
                return View();
            }
            else
            {
                Monitors newMonitor = resultDictionary.GetValueOrDefault("Created");
                return RedirectToAction("Details", "MonitorsView", new { id = newMonitor.MonitorID });
            }
        }


        [Route("~/Monitors/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            return View();
        }


        [HttpPost]
        [Route("~/Monitors/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Monitors monitor)
        {
            var resultDictionary = _monitors.UpdateMonitor(id, monitor);

            if (resultDictionary.ContainsKey("NotFound"))
            {
                ModelState.AddModelError(string.Empty, "Monitor not found.");
                return View();
            }
            else if (resultDictionary.ContainsKey("ModelAlreadyExist"))
            {
                ModelState.AddModelError(string.Empty, "That model aleady exist.");
                return View();
            }
            else if (resultDictionary.ContainsKey("ManufacturerNotExist"))
            {
                ModelState.AddModelError(string.Empty, "Manufacturer does not exist.");
                return View();
            }
            else
            {
                return RedirectToAction("Details", "MonitorsView", new { id });
            }
        }


        [Route("~/Monitors/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            bool deleted = _monitors.DeleteMonitor(id);

            if (deleted)
            {
                return RedirectToAction("Monitors");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Monitor does not exist.");
                return View();
            }
        }


    }
}
