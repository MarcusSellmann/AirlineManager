namespace AirlineManager.Data {
    public class AircraftExtra {
        #region Attributes
        long m_installationDuration;
        AircraftExtras m_extraType;
        #endregion

        #region Properties
        public long InstallationDuration {
            get {
                return m_installationDuration;
            }
        }

        public long ExtraPrize {
            get {
                switch (m_extraType) {
                    case AircraftExtras.WiFi:
                        return 750000;

                    case AircraftExtras.Entertainment:
                        return 500000;

                    case AircraftExtras.PremiumInterior:
                        return 1000000;

                    case AircraftExtras.AdditionalFuelTank:
                        return 500000;

                    default:
                        return 0;
                }
            }
        }

        public AircraftExtras ExtraType {
            get {
                return m_extraType;
            }
        }
        #endregion
        public AircraftExtra(AircraftExtras extraType, long installationDuration) {
            m_extraType = extraType;
            m_installationDuration = installationDuration;
        }
    }
}
