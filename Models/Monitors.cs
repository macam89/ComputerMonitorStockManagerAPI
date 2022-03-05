using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerMonitorStockManager.Models;

namespace ComputerMonitorStockManager.Models
{
    public class Monitors
    {
        public string Model { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Price { get; set; }
        public string ManufactureName { get; set; }
        public string Resolution { get; set; }
        public bool IsFullHD { get; set; }
    }
}
