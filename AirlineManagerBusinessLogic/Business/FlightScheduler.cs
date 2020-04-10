using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AirlineManager.Data;

namespace AirlineManager.Business {
    public class FlightScheduler {
        #region Properties
        public Dictionary<string, Flight> ScheduledFlights { get; private set; }

        public bool IsFlightAlreadyScheduled(string flightNumber) => ScheduledFlights.ContainsKey(flightNumber);

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
        #endregion

        public FlightScheduler() {
            ScheduledFlights = new Dictionary<string, Flight>();
        }

        public bool AddFlight(Flight flight) {
            if (!IsFlightAlreadyScheduled(flight.FlightNumber)) {
                ScheduledFlights[flight.FlightNumber] = flight;
                return true;
            }

            return false;
        }
    }
}
