using System.Collections.Generic;
using DomainLayer.Models;

namespace ServiceLayer.Interfaces
{
    public interface IMonitorService
    {
        IEnumerable<Monitors> GetAllMonitors();
        Monitors GetMonitor(int id);
        Monitors GetMonitor(string model);
        Dictionary<string, Monitors> AddNewMonitor(Monitors monitor);
        Dictionary<string, Monitors> UpdateMonitor(int id, Monitors monitor);
        bool DeleteMonitor(int id);
        bool DeleteAllMonitorsOfOneManufacturer(string manufacturerName);

    }
}
