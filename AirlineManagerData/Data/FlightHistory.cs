using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AirlineManager.Data {
    [DataContract]
    public class FlightHistory {
        #region Properties
        [DataMember]
        public Dictionary<string, HistoricFlight> HistoricFlights { get; private set; }
        #endregion

        public FlightHistory() {
            HistoricFlights = new Dictionary<string, HistoricFlight>();
        }

        public void AddHistoricFlight(HistoricFlight historicFlight) {
            if (historicFlight != null) {
                HistoricFlights.Add(historicFlight.FlightNumber, historicFlight);
            }
        }

        public void AddHistoricFlight(Flight flight, DateTime arrivalTime = new DateTime()) {
            if (flight != null) {
                HistoricFlights.Add(flight.FlightNumber, new HistoricFlight(flight, arrivalTime));
            }
        }
    }
}
