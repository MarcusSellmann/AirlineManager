using System;
using AirlineManager.Data;

namespace AirlineManager.Business.Generators {
	public class InteriorLayoutGenerator {
		private static float ECONOMY_TO_BUSINESS_CONVERTION_FACTOR = 0.5f;
		private static float BUSINESS_TO_FIRST_CONVERTION_FACTOR = 0.5f;
		private static float ECONOMY_TO_FIRST_CONVERTION_FACTOR = ECONOMY_TO_BUSINESS_CONVERTION_FACTOR * BUSINESS_TO_FIRST_CONVERTION_FACTOR;

		#region Attributes
		static InteriorLayoutGenerator m_instance = null;
		#endregion

		#region Properties
		public static InteriorLayoutGenerator Instance {
			get {
				if (m_instance == null) {
					m_instance = new InteriorLayoutGenerator();
				}

				return m_instance;
			}
		}
		#endregion

		InteriorLayoutGenerator() {

		}

		public InteriorLayout CreateInteriorLayout(Aircraft aircraft) {
			Random rnd = new Random();
			int availableSeats = aircraft.MaxNumberOfEconomySeats;
			int ecoSeats = rnd.Next(availableSeats);

			availableSeats = (int)((availableSeats - ecoSeats) * ECONOMY_TO_BUSINESS_CONVERTION_FACTOR);
            int busSeats = rnd.Next(availableSeats);

			availableSeats = (int)((availableSeats - busSeats) * BUSINESS_TO_FIRST_CONVERTION_FACTOR);
			int firSeats = rnd.Next(availableSeats);
			
			return new InteriorLayout(ecoSeats, busSeats, firSeats, 0);
		}
	}
}
