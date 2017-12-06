using System;
using System.Collections.Generic;
using AirlineManager.Data;

namespace AirlineManager.Business.Databases {
	public class AircraftDatabase {
		#region Attributes
		static AircraftDatabase m_instance = null;
		List<Aircraft> m_db = new List<Aircraft>();
		#endregion

		#region Properties
		public static AircraftDatabase Instance {
			get {
				if (m_instance == null) {
					m_instance = new AircraftDatabase();
				}

				return m_instance;
			}
		}

		public Aircraft Random {
			get {
				return m_db[new Random().Next(0, m_db.Count - 1)];
			}
		}

		public List<Aircraft> DB {
			get {
				return m_db;
			}
		}
		#endregion

		private AircraftDatabase() {
			Staff sA320 = new Staff(2, 4, 3, 2, 4, 2);
			Staff sB738 = new Staff(2, 4, 3, 2, 4, 2);

			Aircraft aA320 = new Aircraft("A320-200", 37.57f, 35.8f, 11.76f, 45f, "", 99000000, 828, 6150, 300000, 2090, sA320);
			Aircraft aB738 = new Aircraft("B737-800", 39.47f, 34.32f, 12.57f, 48f, "", 99000000, 880, 6650, 300000, 2100, sB738);

			m_db.Add(aA320);
			m_db.Add(aB738);
		}
	}
}
