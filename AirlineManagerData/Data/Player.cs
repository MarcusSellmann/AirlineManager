using System.Runtime.Serialization;

namespace AirlineManager.Data {
	[DataContract]
	public class Player {
        #region Attributes
        [DataMember]
        uint m_carriedPax;

        [DataMember]
        uint m_carriedCargo;

        [DataMember]
        uint m_operatedFlights;

        [DataMember]
        uint m_totalDistanceFlown;
        #endregion

        #region Properties
        [DataMember]
        public string Name { get; private set; }

        public uint CarriedPax {
            get => m_carriedPax;

            private set {
                if (value >= 0) {
                    m_carriedPax += value;
                }
            }
        }

        public uint CarriedCargo {
            get => m_carriedCargo;

            private set {
                if (value >= 0) {
                    m_carriedCargo += value;
                }
            }
        }

        public uint OperatedFlights {
            get => m_operatedFlights;

            private set {
                if (value >= 0) {
                    m_operatedFlights += value;
                }
            }
        }

        public uint TotalDistanceFlown {
            get => m_totalDistanceFlown;

            private set {
                if (value >= 0) {
                    m_totalDistanceFlown += value;
                }
            }
        }
        #endregion

        public Player(string name) {
            Name = name;
            CarriedPax = 0;
            CarriedCargo = 0;
            OperatedFlights = 0;
            TotalDistanceFlown = 0;
        }

		override
		public string ToString() => Name;
    }
}