using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Interfaces;
using DataAccessLayer.StockDBContext;
using DomainLayer.Models;


namespace DataAccessLayer.DBRepositories
{
    public class ManufacturersDBRepository : IManufacturersRepository
    {

        public IEnumerable<Manufacturers> GetAllManufacturers()
        {
            using (var db = new StockContext())
            {
                return db.Manufacturers.ToList();
            }
        }


        public Manufacturers GetManufacturer(int id)
        {
            using (var db = new StockContext())
            {
                var manufacturer = db.Manufacturers.Find(id);

                return manufacturer;
            }
        }


        public Manufacturers GetManufacturer(string name)
        {
            using (var db = new StockContext())
            {
                var manufacturer = db.Manufacturers.FirstOrDefault(m => m.Name.ToUpper() == name.ToUpper());

                return manufacturer;
            }
        }


        public Manufacturers AddNewManufacturer(Manufacturers manufacturer)
        {
            using (var db = new StockContext())
            {
                var existingManufacturer = db.Manufacturers.Where(b => b.Name.ToUpper() == manufacturer.Name.ToUpper()).FirstOrDefault();

                if (existingManufacturer != null)
                {
                    return null;
                }

                db.Manufacturers.Add(manufacturer);
                db.SaveChanges();

                return manufacturer;
            }
        }


        public Manufacturers UpdateManufacturer(int id, Manufacturers manufacturer)
        {
            using (var db = new StockContext())
            {
                var existingManufacturer = db.Manufacturers.Find(id);

                if (existingManufacturer != null)
                {
                    existingManufacturer.Name = manufacturer.Name;
                    existingManufacturer.PhoneNumber = manufacturer.PhoneNumber;

                    db.Manufacturers.Update(existingManufacturer);
                    db.SaveChanges();

                    return existingManufacturer;
                }
                else
                {
                    return null;
                }
            }
        }


        public bool DeleteManufacturer(int id)
        {
            using (var db = new StockContext())
            {
                var manufacturer = db.Manufacturers.Find(id);

                if (manufacturer != null)
                {
                    db.Manufacturers.Remove(manufacturer);
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
        }


    }
}
