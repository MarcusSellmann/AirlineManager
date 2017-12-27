namespace AirlineManager.Data {
    public enum AircraftManufacturer {
        Aerospatiale,
        Airbus,
        Antonov,
        Boeing,
        BombardierAerospace,
        Cessna,
        Comac,
        Embraer,
        McDonnellDouglas,
        Sukhoi
    }

    public static class AircraftManufacturerExtension {
        public static string ToFriendlyString(this AircraftManufacturer am) {
            switch (am) {
                case AircraftManufacturer.BombardierAerospace:
                    return "Bombardier Aerospace";
                case AircraftManufacturer.McDonnellDouglas:
                    return "McDonnell Douglas";
                default:
                    return am.ToString();
            }
        }
    }
}