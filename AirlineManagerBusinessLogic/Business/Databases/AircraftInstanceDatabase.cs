using System;
using System.Collections.Generic;
using AirlineManager.Data;

namespace AirlineManager.Business.Databases {
	public class AircraftInstanceDatabase {
		#region Attributes
		static AircraftInstanceDatabase m_instance = null;
		List<AircraftInstance> m_db = new List<AircraftInstance>();
		#endregion

		#region Properties
		public static AircraftInstanceDatabase Instance {
			get {
				if (m_instance == null) {
					m_instance = new AircraftInstanceDatabase();
				}

				return m_instance;
			}
		}

		public AircraftInstance Random {
			get {
				return m_db[new Random().Next(0, m_db.Count - 1)];
			}
		}

		public List<AircraftInstance> DB {
			get {
				return m_db;
			}
		}
		#endregion

		private AircraftInstanceDatabase() {
			AircraftDatabase Aircrafts = AircraftDatabase.Instance;
			AirportDatabase Airports = AirportDatabase.Instance;

			InteriorLayout lA322_1 = new InteriorLayout(100, 20, 10, 5);
			InteriorLayout lA322_2 = new InteriorLayout(120, 15, 5, 15);
			InteriorLayout lB738 = new InteriorLayout(150, 10, 10, 17);

            Engine eA322 = new Engine(Data.Enumerations.EngineManufacturer.CFM, "56", 111);
            Engine eB738 = new Engine(Data.Enumerations.EngineManufacturer.CFM, "56-7B", 117);

            AircraftInstance iA322_1 = new AircraftInstance(Aircrafts.DB[0], "D-FAZT", new DateTime(2014,1,20).Ticks, Airports.DB[0], lA322_1, eA322);
            AircraftInstance iA322_2 = new AircraftInstance(Aircrafts.DB[0], "D-ATBG", new DateTime(2016, 3, 5).Ticks, Airports.DB[1], lA322_2, eA322);
            AircraftInstance iB738 = new AircraftInstance(Aircrafts.DB[1], "D-BQIT", new DateTime(2015, 10, 18).Ticks, Airports.DB[2], lB738, eB738);

			m_db.Add(iA322_1);
			m_db.Add(iA322_2);
			m_db.Add(iB738);
		}
	}
}
