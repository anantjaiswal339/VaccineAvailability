using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineAvailability.Models
{
    public class AvailableCenter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public int AvailableVaccines { get; set; }
        public int MinimumAge { get; set; }
        public string Date { get; set; }
        public int PinCode { get; set; }
        public string Address { get; set; }
        public DateTime CurrentDateTime { get; set; }
    }
}
