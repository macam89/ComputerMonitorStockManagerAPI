using System.Collections.Generic;
using DataAccessLayer.Interfaces;
using DomainLayer.Models;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private IManufacturersRepository _repository;

        public ManufacturerService(IManufacturersRepository repository)
        {
            _repository = repository;
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

        public Manufacturers AddNewManufacturer(Manufacturers manufacturer)
        {
            return _repository.AddNewManufacturer(manufacturer);
        }

        public Manufacturers UpdateManufacturer(int id, Manufacturers manufacturer)
        {
            return _repository.UpdateManufacturer(id, manufacturer);
        }

        public bool DeleteManufacturer(int id)
        {
            return _repository.DeleteManufacturer(id);
        }


    }
}
