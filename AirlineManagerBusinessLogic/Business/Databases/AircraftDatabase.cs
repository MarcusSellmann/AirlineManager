using System;
using System.Collections.Generic;
using AirlineManager.Data;

namespace AirlineManager.Business.Databases {
	public class AircraftDatabase {
		#region Attributes
		static AircraftDatabase m_instance = null;
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
				return DB[new Random().Next(0, DB.Count - 1)];
			}
		}

		public List<Aircraft> DB { get; private set; }
		#endregion

		AircraftDatabase() {
            DB = new List<Aircraft>();

			Staff sA320 = new Staff(2, 4, 3, 2, 4, 2);
			Staff sB738 = new Staff(2, 4, 3, 2, 4, 2);

            Engine eA318CFM = new Engine(Data.Enumerations.EngineManufacturer.CFM, "56-5B", 106);
            Engine eA318PW = new Engine(Data.Enumerations.EngineManufacturer.PrattWhitney, "PW6122A", 98);
            List<Engine> aeA318 = new List<Engine>();
            aeA318.Add(eA318CFM);
            aeA318.Add(eA318PW);

            Engine eA319CFM = new Engine(Data.Enumerations.EngineManufacturer.CFM, "56-5B", 105);
            Engine eA319IAE = new Engine(Data.Enumerations.EngineManufacturer.IAE, "V2527-A5", 105);
            List<Engine> aeA319 = new List<Engine>();
            aeA319.Add(eA319CFM);
            aeA319.Add(eA319IAE);

            Engine eA320 = new Engine(Data.Enumerations.EngineManufacturer.CFM, "56-5A", 118);
            List<Engine> aeA320 = new List<Engine>();
            aeA320.Add(eA320);

            Engine eB738 = new Engine(Data.Enumerations.EngineManufacturer.CFM, "56-7B", 117);
            List<Engine> aeB738 = new List<Engine>();
            aeB738.Add(eB738);

            Aircraft aA318 = new Aircraft(AircraftManufacturer.Airbus, "A318-100", 31.45f, 34.1f, 12.56f, 40f, "", 77400000, 828, 6000, 300000, 1355, sA320, aeA318, 2, 132);
            Aircraft aA319 = new Aircraft(AircraftManufacturer.Airbus, "A319-100", 33.84f, 35.8f, 11.76f, 43.33f, "", 92300000, 828, 6850, 300000, 1950, sA320, aeA319, 2, 156);
            Aircraft aA320 = new Aircraft(AircraftManufacturer.Airbus, "A320-200", 37.57f, 35.8f, 11.76f, 45f, "", 101000000, 828, 6150, 300000, 2090, sA320, aeA320, 2, 180);
            Aircraft aB738 = new Aircraft(AircraftManufacturer.Boeing, "B737-800", 39.47f, 34.32f, 12.57f, 48f, "", 99000000, 880, 6650, 300000, 2100, sB738, aeB738, 2, 186);

            DB.Add(aA318);
            DB.Add(aA319);
            DB.Add(aA320);
			DB.Add(aB738);
		}
	}
}
