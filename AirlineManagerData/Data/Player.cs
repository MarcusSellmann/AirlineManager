namespace AirlineManager.Data {
    public class Player {
        #region Attributes
        string m_name;
        uint m_carriedPax;
        uint m_carriedCargo;
        uint m_operatedFlights;
        uint m_totalDistanceFlown;
        #endregion

        #region Properties
        public string Name {
            get {
                return m_name;
            }

            private set {
                m_name = value;
            }
        }

        public uint CarriedPax {
            get {
                return m_carriedPax;
            }

            private set {
                if (value >= 0) {
                    m_carriedPax += value;
                }
            }
        }

        public uint CarriedCargo {
            get {
                return m_carriedCargo;
            }

            private set {
                if (value >= 0) {
                    m_carriedCargo += value;
                }
            }
        }

        public uint OperatedFlights {
            get {
                return m_operatedFlights;
            }

            private set {
                if (value >= 0) {
                    m_operatedFlights += value;
                }
            }
        }

        public uint TotalDistanceFlown {
            get {
                return m_totalDistanceFlown;
            }

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
    }
}