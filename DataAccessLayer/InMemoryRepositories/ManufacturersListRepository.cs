using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Interfaces;
using DomainLayer.Models;


namespace DataAccessLayer.InMemoryRepositories
{
    public class ManufacturersListRepository : IManufacturersRepository
    {
        public static List<Manufacturers> ManufacturersList = new List<Manufacturers>()
        {
            new Manufacturers() {Name = "HP", PhoneNumber = "1234"},
            new Manufacturers() {Name = "Dell", PhoneNumber = "+5678"},
            new Manufacturers() {Name = "Asus", PhoneNumber = "876/54321"},
        };


        public static List<Manufacturers> ListOfManufacturers = new List<Manufacturers>(ListInit(ManufacturersList));


        private static List<Manufacturers> ListInit(List<Manufacturers> manufacturers)
        {
            List<Manufacturers> ManufacturersWithId = new List<Manufacturers>();
            foreach (var m in manufacturers)
            {
                int id = manufacturers.IndexOf(m) + 1;
                ManufacturersWithId.Add(new Manufacturers(id, m.Name, m.PhoneNumber));
            }
            return ManufacturersWithId;
        }


        private static Manufacturers AddManufacturer(Manufacturers manufacturer)
        {
            var last = ListOfManufacturers[ListOfManufacturers.Count - 1];
            int id = last.ManufacturerID + 1;
            ListOfManufacturers.Add(new Manufacturers(id, manufacturer.Name, manufacturer.PhoneNumber));
            var newManufacturer = ListOfManufacturers.FirstOrDefault(m => m.ManufacturerID == id);

            return newManufacturer;
        }


        public IEnumerable<Manufacturers> GetAllManufacturers()
        {
            return ListOfManufacturers;
        }


        public Manufacturers GetManufacturer(int id)
        {
            var manufacturer = ListOfManufacturers.FirstOrDefault(m => m.ManufacturerID == id);

            return manufacturer;
        }


        public Manufacturers GetManufacturer(string name)
        {
            var manufacturer = ListOfManufacturers.FirstOrDefault(m => m.Name.ToUpper() == name.ToUpper());

            return manufacturer;
        }


        public Manufacturers AddNewManufacturer(Manufacturers manufacturer)
        {
            var existingManufacturer = ListOfManufacturers.Where(b => b.Name.ToUpper() == manufacturer.Name.ToUpper()).FirstOrDefault();

            if (existingManufacturer != null)
            {
                return null;
            }

            var newManufacturer = AddManufacturer(manufacturer);
            return newManufacturer;
        }


        public Manufacturers UpdateManufacturer(int id, Manufacturers manufacturer)
        {
            var existingManufacturer = ListOfManufacturers.Where(c => c.ManufacturerID == id).FirstOrDefault();

            if (existingManufacturer != null)
            {
                existingManufacturer.Name = manufacturer.Name;
                existingManufacturer.PhoneNumber = manufacturer.PhoneNumber;

                return existingManufacturer;
            }
            else
            {
                return null;
            }
        }


        public bool DeleteManufacturer(int id)
        {
            var manufacturer = ListOfManufacturers.Where(m => m.ManufacturerID == id).FirstOrDefault();

            if (manufacturer != null)
            {
                ListOfManufacturers.Remove(manufacturer);

                return true;
            }
            return false;
        }

    }
}
