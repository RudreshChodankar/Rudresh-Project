using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlightSearch.Models;
using System.Data.Entity.Core.Objects;

namespace FlightSearch.DataAccess
{
    public class FlightSearchLNQ : FlightSearch.Controllers.FlightSearchController
    {
        public List<FlightSearchResponse> GetFlight(string strAirlineCode, string strOrigin, string strDestination, string dtDeparture)
        {
            List<FlightSearchResponse> lstFlight = new List<FlightSearchResponse>();
            DateTime dtDep = new DateTime();
            if (dtDeparture != null && dtDeparture != "")
                dtDep = Convert.ToDateTime(dtDeparture);
            using (var db = new FlightEntities())
            {
                lstFlight = (from obj in db.JOURNEY_DETAILS
                             join objAD in db.AIRLINE_DETAILS on obj.AIRLINEID equals objAD.AIRLINEID
                             join objFSO in db.FLIGHT_SERVICE on obj.FLIGHTORIGINID equals objFSO.FLIGHTSERVICEID
                             join objFSD in db.FLIGHT_SERVICE on obj.FLIGHTDESTINATIONID equals objFSD.FLIGHTSERVICEID
                             where (strAirlineCode == null || objAD.AIRLINECODE.Contains(strAirlineCode))
                             && (strOrigin == null || objFSO.FLIGHTSERVICENAME.Contains(strOrigin))
                             && (strDestination == null || objFSD.FLIGHTSERVICENAME.Contains(strDestination))
                             && (dtDeparture == null || (obj.DEPARTURE > dtDep && obj.DEPARTURE < EntityFunctions.AddDays(dtDep, 1)))
                             select new FlightSearchResponse
                             {
                                 AirLine = objAD.AIRLINE,
                                 AirLineCode = objAD.AIRLINECODE,
                                 Arrival = obj.ARRIVAL,
                                 AvailableSeats = obj.AVAILABLESEAT,
                                 Departure = obj.DEPARTURE,
                                 Destinations = objFSD.FLIGHTSERVICENAME,
                                 Duration = obj.DURATION,
                                 FlightNumber = obj.FLIGHTNUMBER,
                                 OperationalDays = (from a in obj.OPERATIONAL_DAY
                                                    select new OperationalDay
                                                    {
                                                        OperationalDayId = a.OPERATIONALDAY
                                                    }).ToList(),
                                 Origin = objFSO.FLIGHTSERVICENAME,
                                 Price = obj.PRICE


                             }
                                    ).ToList();
            }
            return lstFlight;
        }
    }
}