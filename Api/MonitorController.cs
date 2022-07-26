using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DomainLayer.Models;
using ServiceLayer.Interfaces;


namespace Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorController : ControllerBase
    {

        private readonly IMonitorService _monitors;

        public MonitorController(IMonitorService monitors)
        {
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
            var resultDictionary = _monitors.AddNewMonitor(monitor);

            if (resultDictionary.ContainsKey("ManufacturerNotExist"))
            {
                return BadRequest("Manufacturer does not exist.");
            }
            else if (resultDictionary.ContainsKey("ModelAlreadyExist"))
            {
                return BadRequest("Model already exist.");
            }
            else
            {
                Monitors newMonitor = resultDictionary.GetValueOrDefault("Created");
                return CreatedAtAction("GetMonitorById", new { id = newMonitor.MonitorID }, newMonitor);
            }
        }


        [HttpPut("{id}")]
        public ActionResult<Monitors> UpdateMonitorWithSpecifiedId(int id, Monitors monitor)
        {
            var resultDictionary = _monitors.UpdateMonitor(id, monitor);

            if (resultDictionary.ContainsKey("NotFound"))
            {
                return NotFound("Monitor not found.");
            }
            else if (resultDictionary.ContainsKey("ModelAlreadyExist"))
            {
                return BadRequest("That model aleady exist.");
            }
            else if (resultDictionary.ContainsKey("ManufacturerNotExist"))
            {
                return BadRequest("Manufacturer does not exist.");
            }
            else
            {
                return NoContent();
            }
        }


        [HttpDelete("DeleteMonitorWithSpecifiedId/{id}")]
        public ActionResult DeleteMonitorWithSpecifiedId(int id)
        {
            bool deleted = _monitors.DeleteMonitor(id);

            if (deleted)
            {
                return Ok();
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

            if (deleted)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Manufacturer does not exist.");
            }
        }


    }
}
