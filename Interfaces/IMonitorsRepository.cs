using System.Collections.Generic;
using System.Threading.Tasks;
using ComputerMonitorStockManager.Models;


namespace ComputerMonitorStockManager.Interfaces
{
    public interface IMonitorsRepository
    {
        IEnumerable<Monitors> GetAllMonitors();
        Monitors GetMonitor(int id);
        Monitors GetMonitor(string model);
        Monitors AddNewMonitor(Monitors m);
        Monitors UpdateMonitor(int id, Monitors m);
        bool DeleteMonitor(int id);
        bool DeleteAllMonitorsOfOneManufacturer(string manufacturerName);
    }
}
