using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Interfaces;
using DomainLayer.Models;


namespace DataAccessLayer.InMemoryRepositories
{
    public class MonitorsListRepository : IMonitorsRepository
    {

        public static List<Monitors> MonitorsList = new List<Monitors>()
        {
            new Monitors() {Model = "9RV17AA", Size = "23,8 inch", Color = "black", Price = "25500 RSD", ManufacturerName = "HP", Resolution = "1920 x 1080 px", IsFullHD = true},
            new Monitors() {Model = "SE2722H", Size = "27 inch", Color = "black", Price = "26600 RSD", ManufacturerName = "Dell", Resolution = "1920 x 1080 px", IsFullHD = false},
            new Monitors() {Model = "S2422HG", Size = "24 inch", Color = "black", Price = "38800 RSD", ManufacturerName = "Dell", Resolution = "1920 x 1080 px", IsFullHD = true},
            new Monitors() {Model = "VA24EHE", Size = "23,8 inch", Color = "black", Price = "22200 RSD", ManufacturerName = "Asus", Resolution = "1920 x 1080 px", IsFullHD = true},

        };

        public static List<Monitors> ListOfMonitors = new List<Monitors>(ListInit(MonitorsList));


        private static List<Monitors> ListInit(List<Monitors> monitors)
        {
            List<Monitors> MonitorsWithId = new List<Monitors>();
            foreach (var m in monitors)
            {
                int id = monitors.IndexOf(m) + 1;
                MonitorsWithId.Add(new Monitors(id, m.Model, m.Size, m.Color, m.Price, m.ManufacturerName, m.Resolution, m.IsFullHD));
            }
            return MonitorsWithId;
        }


        private static Monitors AddMonitor(Monitors monitor)
        {
            var last = ListOfMonitors[ListOfMonitors.Count - 1];
            int id = last.MonitorID + 1;
            ListOfMonitors.Add(new Monitors(id, monitor.Model, monitor.Size, monitor.Color, monitor.Price, monitor.ManufacturerName, monitor.Resolution, monitor.IsFullHD));
            var newMonitor = ListOfMonitors.FirstOrDefault(m => m.MonitorID == id);

            return newMonitor;
        }



        public IEnumerable<Monitors> GetAllMonitors()
        {
            return ListOfMonitors;
        }


        public Monitors GetMonitor(int id)
        {
            var monitor = ListOfMonitors.FirstOrDefault(m => m.MonitorID == id);

            return monitor;
        }


        public Monitors GetMonitor(string model)
        {
            var monitor = ListOfMonitors.FirstOrDefault(m => m.Model.ToUpper() == model.ToUpper());

            return monitor;
        }


        public Monitors AddNewMonitor(Monitors monitor)
        {
            var existingMonitor = ListOfMonitors.Where(b => b.Model.ToUpper() == monitor.Model.ToUpper()).FirstOrDefault();

            if (existingMonitor != null)
            {
                return null;
            }

            var newMonitor = AddMonitor(monitor);
            return newMonitor;
        }


        public Monitors UpdateMonitor(int id, Monitors monitor)
        {
            var existingMonitor = ListOfMonitors.Where(c => c.MonitorID == id).FirstOrDefault();

            if (existingMonitor != null)
            {
                existingMonitor.Model = monitor.Model;
                existingMonitor.Size = monitor.Size;
                existingMonitor.Color = monitor.Color;
                existingMonitor.Price = monitor.Price;
                existingMonitor.ManufacturerName = monitor.ManufacturerName;
                existingMonitor.Resolution = monitor.Resolution;
                existingMonitor.IsFullHD = monitor.IsFullHD;

                return existingMonitor;
            }
            else
            {
                return null;
            }
        }


        public bool DeleteMonitor(int id)
        {
            var monitor = ListOfMonitors.Where(m => m.MonitorID == id).FirstOrDefault();

            if (monitor != null)
            {
                ListOfMonitors.Remove(monitor);

                return true;
            }
            return false;
        }


        public bool DeleteAllMonitorsOfOneManufacturer(string manufacturerName)
        {
            var allMonitorsOfManufacturer = ListOfMonitors.Where(m => m.ManufacturerName.ToUpper() == manufacturerName.ToUpper());

            if (allMonitorsOfManufacturer.Any())
            {
                ListOfMonitors.RemoveAll(monitor => monitor.ManufacturerName.ToUpper() == manufacturerName.ToUpper());

                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
