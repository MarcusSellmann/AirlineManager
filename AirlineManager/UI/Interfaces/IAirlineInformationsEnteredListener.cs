namespace AirlineManager.UI.Interfaces {
    public interface IAirlineInformationsEnteredListener {
        void AirlineInformationEntered(string name, string code);
        void Aborted();
    }
}
