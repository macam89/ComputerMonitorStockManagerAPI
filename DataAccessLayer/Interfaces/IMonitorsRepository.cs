using System.Collections.Generic;
using DomainLayer.Models;


namespace DataAccessLayer.Interfaces
{
    public interface IMonitorsRepository
    {
        IEnumerable<Monitors> GetAllMonitors();
        Monitors GetMonitor(int id);
        Monitors GetMonitor(string model);
        Monitors AddNewMonitor(Monitors monitor);
        Monitors UpdateMonitor(int id, Monitors monitor);
        bool DeleteMonitor(int id);
        bool DeleteAllMonitorsOfOneManufacturer(string manufacturerName);

    }
}
