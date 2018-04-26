using System.Runtime.Serialization;

namespace AirlineManager.Data {
    [DataContract]
    public class AircraftExtra {
        #region Attributes
        #endregion

        #region Properties
        [DataMember]
        public long InstallationDuration { get; private set; }

        [DataMember]
        public AircraftExtras ExtraType { get; private set; }

        public long ExtraPrize {
            get {
                switch (ExtraType) {
                    case AircraftExtras.WiFi:
                        return 750000;

                    case AircraftExtras.Entertainment:
                        return 500000;

                    case AircraftExtras.PremiumInterior:
                        return 1000000;

                    case AircraftExtras.CenterFuelTank:
                        return 500000;

                    default:
                        return 0;
                }
            }
        }
        #endregion
        public AircraftExtra(AircraftExtras extraType, long installationDuration) {
            ExtraType = extraType;
            InstallationDuration = installationDuration;
        }

		override
		public string ToString() {
			return ExtraType.ToString();
		}
	}
}
