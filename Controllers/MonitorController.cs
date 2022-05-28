using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DomainLayer.Models;
using ServiceLayer.Interfaces;


namespace ComputerMonitorStockManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorController : ControllerBase
    {

        private readonly IManufacturerService _manufacturers;
        private readonly IMonitorService _monitors;

        public MonitorController(IManufacturerService manufacturers, IMonitorService monitors)
        {
            _manufacturers = manufacturers;
            _monitors = monitors;
        }


        [Route("errorRoute")]
        [HttpGet]
        public Task<string> ErrorExample()
        {
            return null;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Monitors>> GetAllMonitors()
        {
            var allMonitors = _monitors.GetAllMonitors();

            if (allMonitors == null)
                return NotFound();

            return Ok(allMonitors);
        }


        [HttpGet("{id}")]
        public ActionResult<Monitors> GetMonitorById(int id)
        {
            var monitor = _monitors.GetMonitor(id);
            if (monitor == null)
                return NotFound("Monitor not found.");

            return Ok(monitor);
        }


        [HttpGet("GetMonitorByModel/{model}")]
        public ActionResult<Monitors> GetMonitorByModel(string model)
        {
            var monitor = _monitors.GetMonitor(model);
            if (monitor == null)
                return NotFound("Monitor not found.");

            return Ok(monitor);
        }


        [HttpPost]
        public ActionResult<Monitors> AddNewMonitor([FromBody] Monitors monitor)
        {
            var existingManufacturer = _manufacturers.GetAllManufacturers().Where(g => g.Name.ToUpper() == monitor.ManufacturerName.ToUpper()).FirstOrDefault();

            if (existingManufacturer == null)
            {
                return BadRequest("Manufacturer does not exist.");
            }
            else
            {
                var newMonitor = _monitors.AddNewMonitor(monitor);

                if (newMonitor == null)
                {
                    return BadRequest("Model already exist.");
                }

                return CreatedAtAction("GetMonitorById", new { id = newMonitor.MonitorID}, newMonitor);
            }

        }


        [HttpPut("{id}")]
        public ActionResult<Monitors> UpdateMonitorWithSpecifiedId(int id, Monitors monitor)
        {
            var existingMonitor = _monitors.GetMonitor(id);
            if (existingMonitor == null) 
            {
                return NotFound("Monitor not found.");
            }

            var monitorsExceptUpdatingMonitor = _monitors.GetAllMonitors().Where(c => c.MonitorID != id);
            var monitorWithSameModel = _monitors.GetMonitor(monitor.Model);
            if (monitorsExceptUpdatingMonitor.Contains(monitorWithSameModel))
            {
                return BadRequest("That model aleady exist.");
            }

            var manufacturer = _manufacturers.GetAllManufacturers().Where(g => g.Name.ToUpper() == monitor.ManufacturerName.ToUpper()).FirstOrDefault();
            if (manufacturer == null)
            {
                return BadRequest("Manufacturer does not exist.");
            }

            existingMonitor = _monitors.UpdateMonitor(id, monitor);

            if (existingMonitor != null)
            {
                return NoContent();
            }
            else
            {
                return NotFound("Monitor not found.");
            }
        }


        [HttpDelete("DeleteMonitorWithSpecifiedId/{id}")]
        public ActionResult DeleteMonitorWithSpecifiedId(int id)
        {
            bool deleted = _monitors.DeleteMonitor(id);

            if (deleted == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Monitor does not exist.");
            }
        }


        [HttpDelete("Manufacturer/{manufacturerName}")]
        protected internal ActionResult DeleteAllMonitorsOfOneManufacturer(string manufacturerName)
        {
            bool deleted = _monitors.DeleteAllMonitorsOfOneManufacturer(manufacturerName);

            if (deleted == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Manufacturer does not exist.");
            }
        }


    }
}
