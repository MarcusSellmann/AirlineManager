using System;
using System.Runtime.Serialization;

namespace AirlineManager.Data {
    [DataContract]
    public class HistoricFlight : Flight {
        #region Properties
        [DataMember]
        public DateTime ArrivalTime { get; private set; }
        #endregion

        public HistoricFlight(Flight flight, DateTime arrivalTime) : base(flight.FlightNumber, flight.OperatingRoute, flight.FlightType, flight.State, flight.DepartureTime, flight.BookedPassengers) {
            ArrivalTime = arrivalTime;
        }

        public new TimeSpan CurrentFlightTime {
            get {
                return ArrivalTime - DepartureTime;
            }
        }
    }
}
