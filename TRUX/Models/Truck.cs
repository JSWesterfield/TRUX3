using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRUX.Models
{
    public class Truck
    {
        public int Id { get; set; }
        public string Rfid { get; set; }
        public string Location { get; set; } 
        public string Destination { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}