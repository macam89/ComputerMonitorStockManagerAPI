using System.ComponentModel.DataAnnotations;


namespace ComputerMonitorStockManager.Models
{
    public class Monitors 
    {
        [Key]
        public int MonitorID { get; protected set; }
        public string Model { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Price { get; set; }
        public string ManufacturerName { get; set; }
        public string Resolution { get; set; }
        public bool IsFullHD { get; set; }

        public Monitors()
        {
        }

        public Monitors(int monitorID, string model, string size, string color, string price, string manufacturerName, string resolution, bool isFullHD)
        {
            MonitorID = monitorID;
            Model = model;
            Size = size;
            Color = color;
            Price = price;
            ManufacturerName = manufacturerName;
            Resolution = resolution;
            IsFullHD = isFullHD;
        }

    }
}
