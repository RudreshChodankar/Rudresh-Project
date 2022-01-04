using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlightSearch.DataAccess;
using FlightSearch.Models;

namespace FlightSearch.Controllers
{
    public class FlightSearchController : ApiController
    {
        private FlightSearchLNQ _FlightSearchLNQ;
        [HttpGet]
        [Authorize]
        [Route("api/FlightTest")]
        public string GetFlightTest()
        {
            return "Your token is authozised";
        }

        [HttpGet]
        [Authorize]
        [Route("api/Flight")]
        public List<FlightSearchResponse> GetFlight(string strAirlineCode, string strOrigin, string strDestination, string dtDeparture)
        {
            _FlightSearchLNQ = new FlightSearchLNQ();
            List<FlightSearchResponse> objFlightSearchResponse = new List<FlightSearchResponse>();
            objFlightSearchResponse = _FlightSearchLNQ.GetFlight(strAirlineCode, strOrigin, strDestination, dtDeparture);
            return objFlightSearchResponse;
        }
    }
}
