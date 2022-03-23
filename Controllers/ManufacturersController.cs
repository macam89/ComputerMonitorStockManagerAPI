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
    public class ManufacturersController : ControllerBase
    {


        [HttpGet]
        public ActionResult<IEnumerable<Manufacturers>> GetAll()
        {
            if (!Startup.manufacurers.Any())
                return NotFound();

            return Ok(Startup.manufacurers);
        }

        [HttpGet("mojaruta/{name}")]
        public ActionResult<Manufacturers> GetName(string name)
        {
            var current = Startup.manufacurers.FirstOrDefault(m => m.Name.ToUpper() == name.ToUpper());
            if (current == null)
                return NotFound("Manufacturer not found.");

            return Ok(current);
        }

        [HttpPost]
        public ActionResult NewManufacturer([FromBody] Manufacturers m)
        {
            

            var badM = Startup.manufacurers.Where(b => b.Name.ToUpper() == m.Name.ToUpper()).FirstOrDefault();

            if (badM != null)
            {
                return BadRequest("Manufacturer already exist.");
            }
            else
            {
                Startup.manufacurers.Add(m);
                return Created("Manufacturer successfully added.", m);
            }
        }

        [HttpPut("{name}")]
        public ActionResult UpdateManufacture(string name, [FromBody] Manufacturers m)
        {
            var currentM = Startup.manufacurers.Where(c => c.Name.ToUpper() == name.ToUpper()).FirstOrDefault();

            if (currentM != null)
            {
                currentM.Name = m.Name;
                currentM.PhoneNumber = m.PhoneNumber;

                return NoContent();
            }
            else
            {
                return NotFound("Manufacturer not found.");
            }
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult> DeleteManufacturer(string name)
        {
            var mDel = Startup.manufacurers.Where(m => m.Name.ToUpper() == name.ToUpper()).FirstOrDefault();

            if (mDel != null)
            {
                await Task.FromResult(new MonitorController().DeleteMonitors(name));
                Startup.manufacurers.Remove(mDel);
                return NoContent();

            }
            else
            {
                return BadRequest("Manufacturer does not exist.");
            }
        }
    }
}
