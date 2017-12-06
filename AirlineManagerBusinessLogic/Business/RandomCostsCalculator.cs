using AirlineManager.Data;

namespace AirlineManager.Business {
	public class RandomCostsCalculator {
		#region Attributes
		RandomCostsCalculator m_instance = null;
		long m_currentFuelPrize;
		#endregion

		#region Properties
		public RandomCostsCalculator Instance {
			get {
				if (m_instance == null) {
					m_instance = new RandomCostsCalculator();
				}

				return m_instance;
			}
		}

		public long CurrentFuelPrize {
			get {
				return m_currentFuelPrize;
			}
		}
		#endregion

		private RandomCostsCalculator() {
			m_currentFuelPrize = 0;
        }

		public void UpdateFuelCosts() {

		}

		public long CalculateFerryFlightCosts(Airport origin, Airport destination, AircraftInstance aircraft) {
			int distance = 0;
			long costs = 0;

			// TODO: Make up a nice algo to calculate the ferry flight costs.

			return costs;
		}
	}
}
