using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AirlineManager.Data {
    [DataContract]
    public class FlightSchedule {
        #region Properties
        [DataMember]
        public Dictionary<string, Flight> ScheduledFlights { get; private set; }
        #endregion

        public FlightSchedule() {
            ScheduledFlights = new Dictionary<string, Flight>();
        }

        public bool IsFlightAlreadyScheduled(string flightNumber) => ScheduledFlights.ContainsKey(flightNumber);

        public bool AddFlight(Flight flight) {
            if (!IsFlightAlreadyScheduled(flight.FlightNumber)) {
                ScheduledFlights[flight.FlightNumber] = flight;
                return true;
            }

            return false;
        }

        public List<Route> RoutesForScheduledFlights {
            get {
                List<Route> routes = new List<Route>();

                foreach (KeyValuePair<string, Flight> f in ScheduledFlights) {
                    if (!routes.Contains(f.Value.OperatingRoute)) {
                        routes.Add(f.Value.OperatingRoute);
                    }
                }

                return routes;
            }
        }
    }
}
