using AirlineManager.Data;

namespace AirlineManager.Business {
	public class FlightDemandCalculator {
		#region Attributes
		FlightDemandCalculator m_instance = null;
		#endregion

		#region Properties
		public FlightDemandCalculator Instance {
			get {
				if (m_instance == null) {
					m_instance = new FlightDemandCalculator();
				}

				return m_instance;
			}
		}
		#endregion

		private FlightDemandCalculator() {

		}

		public Demand CalculateRouteDemand(Route route) {
			// TODO: Identify influences for the demand on a route.
			return null;
		}

		public Demand CalculateDemand(IAircraftInteriorLayout layout, Route route) {
			// TODO: Make up a nice algo to calculate the demand for a route.
			return null;
		}
	}
}
