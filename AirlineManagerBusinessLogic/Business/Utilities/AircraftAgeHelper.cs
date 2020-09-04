using AirlineManager.Data;
using System;

namespace AirlineManager.Business.Utilities {
    public class AircraftAgeHelper {
        public static double AircraftAgeInDays(AircraftInstance aircraftInstance, GameClock gameClock) {
            return AircraftAgeInDays(aircraftInstance.InitialOperation, gameClock.CurrentGameTime);
        }

        public static double AircraftAgeInDays(DateTime initialOperationTimestamp, DateTime currentTimestamp) {
            return (currentTimestamp - initialOperationTimestamp).Duration().TotalDays;
        }

        public static double AircraftAgeInYears(AircraftInstance aircraftInstance, GameClock gameClock) {
            return AircraftAgeInYears(aircraftInstance.InitialOperation, gameClock.CurrentGameTime);
        }

        public static double AircraftAgeInYears(DateTime initialOperationTimestamp, DateTime currentTimestamp) {
            return AircraftAgeInDays(initialOperationTimestamp, currentTimestamp) / 365.0;
        }
    }
}
