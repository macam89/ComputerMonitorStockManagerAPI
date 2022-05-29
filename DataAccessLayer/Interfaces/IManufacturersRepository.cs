using System.Collections.Generic;
using DomainLayer.Models;


namespace DataAccessLayer.Interfaces
{
    public interface IManufacturersRepository
    {
        IEnumerable<Manufacturers> GetAllManufacturers();
        Manufacturers GetManufacturer(int id);
        Manufacturers GetManufacturer(string name);
        Manufacturers AddNewManufacturer(Manufacturers manufacturer);
        Manufacturers UpdateManufacturer(int id, Manufacturers manufacturer);
        bool DeleteManufacturer(int id);

    }
}
