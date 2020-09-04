using System;

using AirlineManager.Data;

namespace AirlineManager.Business.Utilities {
    public class FlightTimeHelper {
        public static DateTime EstimatedArrival(double totalFlightTime, DateTime departureTime, FlightState currentState, DateTime currentTimeStamp) {
            return currentTimeStamp + CalculateFlightTimeLeft(totalFlightTime, departureTime, currentState, currentTimeStamp);
        }

        public static TimeSpan CalculateCurrentTimeInFlight(DateTime departureTime, FlightState currentState, DateTime currentTimeStamp) {
            TimeSpan flightTime = currentTimeStamp - departureTime;

            if (flightTime < TimeSpan.FromSeconds(0) ||
                currentState != FlightState.InFlight) {
                flightTime = TimeSpan.FromSeconds(0);
            }

            return flightTime;
        }

        public static TimeSpan CalculateFlightTimeLeft(double totalFlightTime, DateTime departureTime, FlightState currentState, DateTime currentTimeStamp) {
            return TimeSpan.FromHours(totalFlightTime) - CalculateCurrentTimeInFlight(departureTime, currentState, currentTimeStamp);
        }

        /// <summary>
        /// Returns the estimated flight time.
        /// </summary>
        public static TimeSpan EstimatedTotalFlightTime(AircraftInstance assignedAircraft, Route operatingRoute) {
            return TimeSpan.FromHours(assignedAircraft.Type.TravelVelocity / operatingRoute.Distance);
        }

        public static void SetFlightDeparted(Flight flight, DateTime currentTimeStamp) {
            flight.DepartureTime = currentTimeStamp;
        }
    }
}
