namespace AirlineManager.Data {
    public interface IAircraftInteriorLayout {
        int PaxInClass(ClassType classType);
        int SumTotalPax();
        bool HasPax();
        bool HasCargo();
        bool IsCargoOnly();
    }
}