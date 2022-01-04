using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightSearch.Models
{
    public class FlightSearchResponse
    {
        public int Id { get; set; }
        public string AirLine { get; set; }
        public string AirLineCode { get; set; }
        public int? FlightNumber { get; set; }
        public string Origin { get; set; }
        public int? AvailableSeats { get; set; }
        public string Destinations { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public string Duration { get; set; }
        public List<OperationalDay> OperationalDays { get; set; }
    }
    public class OperationalDay
    {
        public int? OperationalDayId { get; set; }
    }
}