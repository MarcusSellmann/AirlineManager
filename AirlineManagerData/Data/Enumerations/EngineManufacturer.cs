namespace AirlineManager.Data.Enumerations {
    public enum EngineManufacturer {
        RollsRoyce,
        PrattWhitney,
        CFM,
        IAE
    }

    public static class EngineManufacturerExtension {
        public static string ToFriendlyString(this EngineManufacturer em) {
            switch (em) {
                case EngineManufacturer.RollsRoyce:
                    return "Rolls-Royce";
                case EngineManufacturer.PrattWhitney:
                    return "Pratt & Whitney";
                default:
                    return em.ToString();
            }
        }
    }
}
