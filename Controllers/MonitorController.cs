using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ComputerMonitorStockManager.Models;

namespace ComputerMonitorStockManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorController : ControllerBase
    {
        

        [HttpGet]
        public ActionResult<IEnumerable<Monitors>> GetMonitors()
        {
            if (!Startup.monitors.Any())
                return NotFound();

            return Ok(Startup.monitors);
        }

        [HttpGet("{model}")]
        public ActionResult<Monitors> GetMonitor(string model) 
        {
            var monitor = Startup.monitors.FirstOrDefault(m => m.Model.ToUpper() == model.ToUpper());
            if (monitor == null)
                return NotFound();

            return Ok(monitor);
        }

        [HttpPost]
        public ActionResult NewMonitor([FromBody] Monitors monitor)
        {
            var goodManufacturer = Startup.manufacurers.Where(g => g.Name.ToUpper() == monitor.ManufactureName.ToUpper()).FirstOrDefault();
            var badModel = Startup.monitors.Where(b => b.Model.ToUpper() == monitor.Model.ToUpper()).FirstOrDefault();

            if (badModel != null)
            {
                return BadRequest("Model already exist.");
            }
            else if (goodManufacturer == null)
            {
                return BadRequest("Manufacturer does not exist.");
            }
            else
            {
                Startup.monitors.Add(monitor);
                return Created("Monitor successfully added.", monitor);
            }
        }

        [HttpPut("{model}")]
        public ActionResult UpdateMonitor(string model, [FromBody] Monitors monitor)
        {
            var currentM = Startup.monitors.Where(c => c.Model.ToUpper() == model.ToUpper()).FirstOrDefault();
            var goodManufacturer = Startup.manufacurers.Where(g => g.Name.ToUpper() == monitor.ManufactureName.ToUpper()).FirstOrDefault();

            if (currentM != null)
            {
                currentM.Model = monitor.Model;
                currentM.Size = monitor.Size;
                currentM.Color = monitor.Color;
                currentM.Price = monitor.Price;
                currentM.ManufactureName = monitor.ManufactureName;
                currentM.Resolution = monitor.Resolution;
                currentM.IsFullHD = monitor.IsFullHD;

                if (goodManufacturer == null)
                {
                    return BadRequest("Manufacturer does not exist.");
                }

                return NoContent();
            }
            else
            {
                return NotFound("Monitor not found.");
            }
        }

        [HttpDelete("DeleteOneMonitor/{model}")]
        public ActionResult DeleteOneMonitor(string model)
        {
            var monitorDel = Startup.monitors.Where(m => m.Model.ToUpper() == model.ToUpper()).FirstOrDefault();

            if (monitorDel != null)
            {
                Startup.monitors.Remove(monitorDel);
                return NoContent();
            }
            else
            {
                return BadRequest("Model does not exist.");
            }
        }

        [HttpDelete("DeleteMonitors/{manufactureName}")]
        protected internal ActionResult DeleteMonitors(string manufactureName) 
        {
            var monitorsDel = Startup.monitors.Where(md => md.ManufactureName.ToUpper() == manufactureName.ToUpper());

            if (monitorsDel.Any())
            {

                Startup.monitors.RemoveAll(monitorsDel => monitorsDel.ManufactureName.ToUpper() == manufactureName.ToUpper());
                return NoContent();
            }
            else
            {
                return BadRequest("Manufacturer does not exist.");
            }
        }

    }
}
