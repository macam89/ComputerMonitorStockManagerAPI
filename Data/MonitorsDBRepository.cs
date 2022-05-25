using System.Collections.Generic;
using System.Linq;
using ComputerMonitorStockManager.Interfaces;
using ComputerMonitorStockManager.Models;

namespace ComputerMonitorStockManager.Data
{
    public class MonitorsDBRepository : IMonitorsRepository
    {
        private readonly StockContext _stockContext;

        public MonitorsDBRepository(StockContext stockContext)
        {
            _stockContext = stockContext;
        }


        public IEnumerable<Monitors> GetAllMonitors()
        {
            return _stockContext.Monitors.ToList();
        }


        public Monitors GetMonitor(int id) 
        {
            var monitor = _stockContext.Monitors.Find(id);
            return monitor;
        }


        public Monitors GetMonitor(string model) 
        {
            var monitor = _stockContext.Monitors.FirstOrDefault(m => m.Model.ToUpper() == model.ToUpper());
            return monitor;
        }


        public Monitors AddNewMonitor(Monitors monitor) 
        {
            var existingMonitor = _stockContext.Monitors.Where(b => b.Model.ToUpper() == monitor.Model.ToUpper()).FirstOrDefault();

            if (existingMonitor != null)
            {
                return null;
            }

            _stockContext.Monitors.Add(monitor);
            _stockContext.SaveChanges();
            return monitor;
        }


        public Monitors UpdateMonitor(int id, Monitors monitor)
        {
            var existingMonitor = _stockContext.Monitors.Find(id);

            if (existingMonitor != null)
            {
                existingMonitor.Model = monitor.Model;
                existingMonitor.Size = monitor.Size;
                existingMonitor.Color = monitor.Color;
                existingMonitor.Price = monitor.Price;
                existingMonitor.ManufacturerName = monitor.ManufacturerName;
                existingMonitor.Resolution = monitor.Resolution;
                existingMonitor.IsFullHD = monitor.IsFullHD;

                _stockContext.Monitors.Update(existingMonitor);
                _stockContext.SaveChanges();

                return existingMonitor;
            }
            else
            {
                return null;
            }
        }


        public bool DeleteMonitor(int id)
        {
            var monitor = _stockContext.Monitors.Find(id);

            if (monitor != null)
            {
                _stockContext.Monitors.Remove(monitor);
                _stockContext.SaveChanges();
                return true;
            }
            return false;
        }


        public bool DeleteAllMonitorsOfOneManufacturer(string manufacturerName)
        {
            var allMonitorsOfManufacturer = GetAllMonitors().Where(m => m.ManufacturerName.ToUpper() == manufacturerName.ToUpper());

            if (allMonitorsOfManufacturer.Any())
            {
                foreach (var m in allMonitorsOfManufacturer) 
                {
                    _stockContext.Monitors.Remove(m);
                }
                _stockContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
