using System.Collections.Generic;
using System.Threading.Tasks;
using ComputerMonitorStockManager.Models;


namespace ComputerMonitorStockManager.Interfaces
{
    public interface IManufacturersRepository
    {
        IEnumerable<Manufacturers> GetAllManufacturers();
        Manufacturers GetManufacturer(int id);
        Manufacturers GetManufacturer(string name);
        Manufacturers AddNewManufacturer(Manufacturers m);
        Manufacturers UpdateManufacturer(int id, Manufacturers m);
        bool DeleteManufacturer(int id);

    }
}
