using System.ComponentModel.DataAnnotations;


namespace ComputerMonitorStockManager.Models
{
    public class Manufacturers 
    {
        [Key]
        public int ManufacturerID { get; protected set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Manufacturers() 
        {
        }

        public Manufacturers(int manufacturerID, string name, string phoneNumber) 
        {
            ManufacturerID = manufacturerID;
            Name = name;
            PhoneNumber = phoneNumber;
        }

    }
}
