namespace AirlineManager.Business.Utilities {
    public class AircraftValueHelper {
        private static readonly double FLIGHT_HOURS_COST_FACTOR = 35.0;
        private static readonly double AGE_COST_FACTOR = 2500.0;

        public static long GetCurrentAircraftValue(long originalPrize, float flownHours, double age) {
            long hoursCosts = (long)(flownHours * FLIGHT_HOURS_COST_FACTOR);
            long ageCosts = (long)(age * AGE_COST_FACTOR);

            return originalPrize - hoursCosts - ageCosts;
        }
    }
}
