//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlightSearch.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class JOURNEY_DETAILS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JOURNEY_DETAILS()
        {
            this.OPERATIONAL_DAY = new HashSet<OPERATIONAL_DAY>();
        }
    
        public int JOURNEYDETAILSID { get; set; }
        public int FLIGHTORIGINID { get; set; }
        public int FLIGHTDESTINATIONID { get; set; }
        public int AIRLINEID { get; set; }
        public Nullable<decimal> PRICE { get; set; }
        public Nullable<System.DateTime> DEPARTURE { get; set; }
        public Nullable<System.DateTime> ARRIVAL { get; set; }
        public string DURATION { get; set; }
        public Nullable<int> AVAILABLESEAT { get; set; }
        public Nullable<int> FLIGHTNUMBER { get; set; }
    
        public virtual AIRLINE_DETAILS AIRLINE_DETAILS { get; set; }
        public virtual FLIGHT_SERVICE FLIGHT_SERVICE { get; set; }
        public virtual FLIGHT_SERVICE FLIGHT_SERVICE1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OPERATIONAL_DAY> OPERATIONAL_DAY { get; set; }
    }
}
