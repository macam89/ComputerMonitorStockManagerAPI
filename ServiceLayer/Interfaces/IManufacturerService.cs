using System.Collections.Generic;
using DomainLayer.Models;

namespace ServiceLayer.Interfaces
{
    public interface IManufacturerService
    {
        IEnumerable<Manufacturers> GetAllManufacturers();
        Manufacturers GetManufacturer(int id);
        Manufacturers GetManufacturer(string name);
        Dictionary<string, Manufacturers> AddNewManufacturer(Manufacturers m);
        Dictionary<string, Manufacturers> UpdateManufacturer(int id, Manufacturers m);
        bool DeleteManufacturer(int id);

    }
}
