using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Interfaces;
using DomainLayer.Models;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class MonitorService : IMonitorService
    {
        private IMonitorsRepository _repository;
        private IManufacturersRepository _manufacturersRepository;

        public MonitorService(IMonitorsRepository repository, IManufacturersRepository manufacturersRepository)
        {
            _repository = repository;
            _manufacturersRepository = manufacturersRepository;
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

        public Dictionary<string, Monitors> AddNewMonitor(Monitors monitor)
        {
            var existingManufacturer = _manufacturersRepository.GetAllManufacturers().Where(g => g.Name.ToUpper() == monitor.ManufacturerName.ToUpper()).FirstOrDefault();
            
            string response;
            var resultDictionary = new Dictionary<string, Monitors>();

            if (existingManufacturer == null)
            {
                response = MonitorEnums.ManufacturerNotExist.ToString();
                resultDictionary.Add(response, null);
                return resultDictionary;
            }
            else
            {
                var newMonitor = _repository.AddNewMonitor(monitor);

                if (newMonitor == null)
                {
                    response = MonitorEnums.ModelAlreadyExist.ToString();
                    resultDictionary.Add(response, null);
                    return resultDictionary;
                }

                response = MonitorEnums.Created.ToString();
                resultDictionary.Add(response, newMonitor);
                return resultDictionary;
            }
        }

        public Dictionary<string, Monitors> UpdateMonitor(int id, Monitors monitor)
        {
            var existingMonitor = _repository.GetMonitor(id);
            
            string response;
            var resultDictionary = new Dictionary<string, Monitors>();

            if (existingMonitor == null)
            {
                response = MonitorEnums.NotFound.ToString();
                resultDictionary.Add(response, null);
                return resultDictionary;
            }

            var monitorsExceptUpdatingMonitor = _repository.GetAllMonitors().Where(c => c.MonitorID != id);
            var monitorWithSameModel = monitorsExceptUpdatingMonitor.Where(m => m.Model.ToUpper() == monitor.Model.ToUpper()).FirstOrDefault();

            if (monitorWithSameModel != null)
            {
                response = MonitorEnums.ModelAlreadyExist.ToString();
                resultDictionary.Add(response, null);
                return resultDictionary;
            }

            var manufacturer = _manufacturersRepository.GetAllManufacturers().Where(g => g.Name.ToUpper() == monitor.ManufacturerName.ToUpper()).FirstOrDefault();
            
            if (manufacturer == null)
            {
                response = MonitorEnums.ManufacturerNotExist.ToString();
                resultDictionary.Add(response, null);
                return resultDictionary;
            }

            existingMonitor = _repository.UpdateMonitor(id, monitor);

            if (existingMonitor != null)
            {
                response = MonitorEnums.NoContent.ToString();
                resultDictionary.Add(response, existingMonitor);
                return resultDictionary;
            }
            else
            {
                response = MonitorEnums.NotFound.ToString();
                resultDictionary.Add(response, null);
                return resultDictionary;
            }
        }

        public bool DeleteMonitor(int id)
        {
            return _repository.DeleteMonitor(id);
        }

        public bool DeleteAllMonitorsOfOneManufacturer(string manufacturerName)
        {
            return _repository.DeleteAllMonitorsOfOneManufacturer(manufacturerName);
        }

        public enum MonitorEnums
        {
            ManufacturerNotExist,
            ModelAlreadyExist,
            Created,
            NoContent,
            NotFound
        }

    }
}
