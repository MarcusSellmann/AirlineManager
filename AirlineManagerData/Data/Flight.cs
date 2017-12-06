namespace AirlineManager.Data {
	public class Flight {
		#region Attributes
		FlightType m_flightType;
		FlightState m_state;
		Demand m_bookedPassengers;
		#endregion

		#region Properties
		public FlightType FlightType {
			get {
				return m_flightType;
			}
		}

		public FlightState State {
			get {
				return m_state;
			}
		}

		public Demand BookedPassengers {
			get {
				return m_bookedPassengers;
			}

			set {
				if (value != null) {
					m_bookedPassengers = value;
                }
			}
		}
		#endregion

		public Flight(FlightType flightType, FlightState state) {
			m_flightType = flightType;
			m_state = state;
		}

		public Flight(FlightType flightType, FlightState state, Demand bookedPassengers) : this(flightType, state) {
			m_bookedPassengers = bookedPassengers;
		}
	}
}
