using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ComputerMonitorStockManager.Models;
using Microsoft.EntityFrameworkCore;
using ComputerMonitorStockManager.Interfaces;


namespace ComputerMonitorStockManager.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly IManufacturersRepository _manufacturers;
        private readonly IMonitorsRepository _monitors;

        public ManufacturersController(IManufacturersRepository manufacturers, IMonitorsRepository monitors)
        {
            _manufacturers = manufacturers;
            _monitors = monitors;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Manufacturers>> GetAllManufacturers()
        {
            var allManufacturers = _manufacturers.GetAllManufacturers();

            if (allManufacturers == null)
                return NotFound();

            return Ok(allManufacturers);
        }


        [HttpGet("{id}")]
        public ActionResult<Manufacturers> GetManufacturerById(int id)
        {
            var manufacturer = _manufacturers.GetManufacturer(id);

            if (manufacturer == null)
                return NotFound("Manufacturer not found.");

            return Ok(manufacturer);
        }


        [HttpGet("GetManufacturerByName/{name}")]
        public ActionResult<Manufacturers> GetManufacturerByName(string name)
        {
            var manufacturer = _manufacturers.GetManufacturer(name);

            if (manufacturer == null)
            {
                return NotFound("Manufacturer not found.");
            }

            return Ok(manufacturer);
        }


        [HttpPost]
        public ActionResult<Manufacturers> AddNewManufacturer([FromBody] Manufacturers manufacturer)
        {
            var newManufacturer = _manufacturers.AddNewManufacturer(manufacturer);

            if (newManufacturer == null)
            {
                return BadRequest("Manufacturer already exist.");
            }

            return CreatedAtAction("GetManufacturerById", new { id = newManufacturer.ManufacturerID }, newManufacturer);

        }


        [HttpPut("{id}")]
        public ActionResult<Manufacturers> UpdateManufacturerWithSpecifiedId(int id, Manufacturers manufacturer)
        {
            var manufacturersExceptUpdatingManufacturer = _manufacturers.GetAllManufacturers().Where(c => c.ManufacturerID != id);
            var manufacturerWithSameName = _manufacturers.GetManufacturer(manufacturer.Name);
            if (manufacturersExceptUpdatingManufacturer.Contains(manufacturerWithSameName))
            {
                return BadRequest("Manufacturer with that name already exist.");
            }

            var manufacturerForUpdate = _manufacturers.UpdateManufacturer(id, manufacturer);

            if (manufacturerForUpdate != null)
            {
                return NoContent();
            }
            else
            {
                return NotFound("Manufacturer not found.");
            }

        }


        [HttpDelete("{id}")]
        public ActionResult DeleteManufacturerWithSpecifiedId(int id)
        {
            var manufacturer = _manufacturers.GetManufacturer(id);
            bool deleted = _manufacturers.DeleteManufacturer(id);

            if (deleted == true)
            {
                _monitors.DeleteAllMonitorsOfOneManufacturer(manufacturer.Name);

                return NoContent();
            }
            else
            {
                return BadRequest("Manufacturer does not exist.");
            }
        }


    }
}
