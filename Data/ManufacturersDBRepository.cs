using System.Collections.Generic;
using System.Linq;
using ComputerMonitorStockManager.Interfaces;
using ComputerMonitorStockManager.Models;

namespace ComputerMonitorStockManager.Data
{
    public class ManufacturersDBRepository : IManufacturersRepository
    {
        private readonly StockContext _stockContext;

        public ManufacturersDBRepository(StockContext stockContext)
        {
            _stockContext = stockContext;
        }

        public IEnumerable<Manufacturers> GetAllManufacturers()
        {
            return _stockContext.Manufacturers.ToList();
        }


        public Manufacturers GetManufacturer(int id)
        {
            var manufacturer = _stockContext.Manufacturers.Find(id);

            return manufacturer;
        }


        public Manufacturers GetManufacturer(string name)
        {
            var manufacturer = _stockContext.Manufacturers.FirstOrDefault(m => m.Name.ToUpper() == name.ToUpper());

            return manufacturer;
        }


        public Manufacturers AddNewManufacturer(Manufacturers manufacturer)
        {
            var existingManufacturer = _stockContext.Manufacturers.Where(b => b.Name.ToUpper() == manufacturer.Name.ToUpper()).FirstOrDefault();

            if (existingManufacturer != null)
            {
                return null;
            }
            
            _stockContext.Manufacturers.Add(manufacturer);
            _stockContext.SaveChanges();
            return manufacturer;
        }


        public Manufacturers UpdateManufacturer(int id, Manufacturers manufacturer)
        {
            var existingManufacturer = _stockContext.Manufacturers.Find(id);

            if (existingManufacturer != null)
            {
                existingManufacturer.Name = manufacturer.Name;
                existingManufacturer.PhoneNumber = manufacturer.PhoneNumber;
                
                _stockContext.Manufacturers.Update(existingManufacturer);
                _stockContext.SaveChanges();
                return existingManufacturer;
            }
            else
            {
                return null;
            }
        }


        public bool DeleteManufacturer(int id)
        {
            var manufacturer = _stockContext.Manufacturers.Find(id);

            if (manufacturer != null)
            {
                _stockContext.Manufacturers.Remove(manufacturer);
                _stockContext.SaveChanges();
                return true;
            }

            return false;
        }


    }
}
