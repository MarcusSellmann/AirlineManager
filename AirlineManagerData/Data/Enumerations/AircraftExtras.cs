using System;

namespace AirlineManager.Data {
	[Serializable()]
	public enum AircraftExtras {
        WiFi,
        Entertainment,
        CenterFuelTank,
        PremiumInterior
    }

    public static class AircraftExtrasExtension {
        public static string ToFriendlyString(this AircraftExtras ae) {
            switch (ae) {
                case AircraftExtras.CenterFuelTank:
                    return "Center fuel tank";
                case AircraftExtras.PremiumInterior:
                    return "Premium interior";
                default:
                    return ae.ToString();
            }
        }
    }
}