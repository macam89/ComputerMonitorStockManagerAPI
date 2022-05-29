using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Interfaces;
using DataAccessLayer.StockDBContext;
using DomainLayer.Models;


namespace DataAccessLayer.DBRepositories
{
    public class MonitorsDBRepository : IMonitorsRepository
    {

        public IEnumerable<Monitors> GetAllMonitors()
        {
            using (var db = new StockContext())
            {
                return db.Monitors.ToList();
            }
        }


        public Monitors GetMonitor(int id)
        {
            using (var db = new StockContext())
            {
                var monitor = db.Monitors.Find(id);

                return monitor;
            }
        }


        public Monitors GetMonitor(string model)
        {
            using (var db = new StockContext())
            {
                var monitor = db.Monitors.FirstOrDefault(m => m.Model.ToUpper() == model.ToUpper());

                return monitor;
            }
        }


        public Monitors AddNewMonitor(Monitors monitor)
        {
            using (var db = new StockContext())
            {
                var existingMonitor = db.Monitors.Where(b => b.Model.ToUpper() == monitor.Model.ToUpper()).FirstOrDefault();

                if (existingMonitor != null)
                {
                    return null;
                }

                db.Monitors.Add(monitor);
                db.SaveChanges();

                return monitor;
            }
        }


        public Monitors UpdateMonitor(int id, Monitors monitor)
        {
            using (var db = new StockContext())
            {
                var existingMonitor = db.Monitors.Find(id);

                if (existingMonitor != null)
                {
                    existingMonitor.Model = monitor.Model;
                    existingMonitor.Size = monitor.Size;
                    existingMonitor.Color = monitor.Color;
                    existingMonitor.Price = monitor.Price;
                    existingMonitor.ManufacturerName = monitor.ManufacturerName;
                    existingMonitor.Resolution = monitor.Resolution;
                    existingMonitor.IsFullHD = monitor.IsFullHD;

                    db.Monitors.Update(existingMonitor);
                    db.SaveChanges();

                    return existingMonitor;
                }
                else
                {
                    return null;
                }
            }
        }


        public bool DeleteMonitor(int id)
        {
            using (var db = new StockContext())
            {
                var monitor = db.Monitors.Find(id);

                if (monitor != null)
                {
                    db.Monitors.Remove(monitor);
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
        }


        public bool DeleteAllMonitorsOfOneManufacturer(string manufacturerName)
        {
            using (var db = new StockContext())
            {
                var allMonitorsOfManufacturer = GetAllMonitors().Where(m => m.ManufacturerName.ToUpper() == manufacturerName.ToUpper());

                if (allMonitorsOfManufacturer.Any())
                {
                    foreach (var m in allMonitorsOfManufacturer)
                    {
                        db.Monitors.Remove(m);
                    }
                    db.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


    }
}
