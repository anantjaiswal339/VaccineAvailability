using System;
using System.Collections.Generic;

namespace VaccineAvailability.Models.Data
{
    public partial class AvailableCenter
    {
        public int AvailableCenterId { get; set; }
        public int? Id { get; set; }
        public string Name { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public int? MinimumAge { get; set; }
        public int? AvailableVaccines { get; set; }
        public DateTime? Date { get; set; }
        public int? Pincode { get; set; }
        public string Address { get; set; }
        public DateTime? CurrentDateTime { get; set; }
    }
}
