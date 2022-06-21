using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DomainLayer.Models;
using ServiceLayer.Interfaces;


namespace ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {

        private readonly IManufacturerService _manufacturers;

        public ManufacturersController(IManufacturerService manufacturers)
        {
            _manufacturers = manufacturers;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Manufacturers>> GetAllManufacturers()
        {
            var allManufacturers = _manufacturers.GetAllManufacturers().ToList();

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
            var resultDictionary = _manufacturers.AddNewManufacturer(manufacturer);

            if (resultDictionary.ContainsKey("BadRequest"))
            {
                return BadRequest("Manufacturer already exist.");
            }

            Manufacturers newManufacturer = resultDictionary.GetValueOrDefault("Created");
            return CreatedAtAction("GetManufacturerById", new { id = newManufacturer.ManufacturerID }, newManufacturer);
        }


        [HttpPut("{id}")]
        public ActionResult<Manufacturers> UpdateManufacturerWithSpecifiedId(int id, Manufacturers manufacturer)
        {
            var resultDictionary = _manufacturers.UpdateManufacturer(id, manufacturer);

            if (resultDictionary.ContainsKey("BadRequest"))
            {
                return BadRequest("Manufacturer with that name already exist.");
            }
            else if (resultDictionary.ContainsKey("NoContent"))
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
            bool deleted = _manufacturers.DeleteManufacturer(id);

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
