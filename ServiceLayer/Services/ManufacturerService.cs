using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Interfaces;
using DomainLayer.Models;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private IManufacturersRepository _repository;
        private readonly IMonitorService _monitorService;

        public ManufacturerService(IManufacturersRepository repository, IMonitorService monitorService)
        {
            _repository = repository;
            _monitorService = monitorService;
        }

        public IEnumerable<Manufacturers> GetAllManufacturers()
        {
            return _repository.GetAllManufacturers();
        }

        public Manufacturers GetManufacturer(int id)
        {
            return _repository.GetManufacturer(id);
        }

        public Manufacturers GetManufacturer(string name)
        {
            return _repository.GetManufacturer(name);
        }

        public Dictionary<string, Manufacturers> AddNewManufacturer(Manufacturers manufacturer)
        {
            var newManufacturer = _repository.AddNewManufacturer(manufacturer);
            
            string response;
            var resultDictionary = new Dictionary<string, Manufacturers>();

            if (newManufacturer == null)
            {
                response = ManufacturerEnums.BadRequest.ToString();
                resultDictionary.Add(response, null);
                return resultDictionary;
            }
            
            response = ManufacturerEnums.Created.ToString();
            resultDictionary.Add(response, newManufacturer);
            return resultDictionary;
        }

        public Dictionary<string, Manufacturers> UpdateManufacturer(int id, Manufacturers manufacturer)
        {
            var manufacturersExceptUpdatingManufacturer = _repository.GetAllManufacturers().Where(c => c.ManufacturerID != id);
            var manufacturerWithSameName = manufacturersExceptUpdatingManufacturer.Where(m => m.Name.ToUpper() == manufacturer.Name.ToUpper()).FirstOrDefault();

            string response;
            var resultDictionary = new Dictionary<string, Manufacturers>();

            if (manufacturerWithSameName != null)
            {
                response = ManufacturerEnums.BadRequest.ToString();
                resultDictionary.Add(response, null);
                return resultDictionary;
            }

            var manufacturerForUpdate = _repository.UpdateManufacturer(id, manufacturer);

            if (manufacturerForUpdate != null)
            {
                response = ManufacturerEnums.NoContent.ToString();
                resultDictionary.Add(response, manufacturer);
                return resultDictionary;
            }
            else
            {
                response = ManufacturerEnums.NotFound.ToString();
                resultDictionary.Add(response, null);
                return resultDictionary;
            }
        }

        public bool DeleteManufacturer(int id)
        {
            var manufacturer = _repository.GetManufacturer(id);
            bool deleted = _repository.DeleteManufacturer(id);

            if (deleted == true)
            {
                _monitorService.DeleteAllMonitorsOfOneManufacturer(manufacturer.Name);

                return true;
            }
            else
            {
                return false;
            }
        }

        public enum ManufacturerEnums 
        {
            Ok,
            BadRequest,
            Created,
            NoContent,
            NotFound
        }

    }
}
