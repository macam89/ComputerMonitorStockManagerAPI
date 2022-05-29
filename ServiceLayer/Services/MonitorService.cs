using System.Collections.Generic;
using DataAccessLayer.Interfaces;
using DomainLayer.Models;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class MonitorService : IMonitorService
    {
        private IMonitorsRepository _repository;

        public MonitorService(IMonitorsRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Monitors> GetAllMonitors()
        {
            return _repository.GetAllMonitors();
        }

        public Monitors GetMonitor(int id)
        {
            return _repository.GetMonitor(id);
        }

        public Monitors GetMonitor(string model)
        {
            return _repository.GetMonitor(model);
        }

        public Monitors AddNewMonitor(Monitors monitor)
        {
            return _repository.AddNewMonitor(monitor);
        }

        public Monitors UpdateMonitor(int id, Monitors monitor)
        {
            return _repository.UpdateMonitor(id, monitor);
        }

        public bool DeleteMonitor(int id)
        {
            return _repository.DeleteMonitor(id);
        }

        public bool DeleteAllMonitorsOfOneManufacturer(string manufacturerName)
        {
            return _repository.DeleteAllMonitorsOfOneManufacturer(manufacturerName);
        }


    }
}
