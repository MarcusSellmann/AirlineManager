using System;

namespace AirlineManager.Business.Utilities {
    public class AircraftAgeHelper {
        public static double AircraftAgeInDays(DateTime initialOperationTimestamp, DateTime currentTimestamp) {
            return (currentTimestamp - initialOperationTimestamp).Duration().TotalDays;
        }

        public static double AircraftAgeInYears(DateTime initialOperationTimestamp, DateTime currentTimestamp) {
            return AircraftAgeInDays(initialOperationTimestamp, currentTimestamp) / 365.0;
        }
    }
}
