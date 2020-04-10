using System;
using System.Collections.Generic;
using System.Linq;

using AirlineManager.Business.Databases;
using AirlineManager.Data;

namespace AirlineManager.Business.Generators {
	public class AircraftInstanceGenerator {
		#region Attributes
		static AircraftInstanceGenerator m_instance;
		#endregion

		#region Properties
		public static AircraftInstanceGenerator Instance {
			get {
				if (m_instance == null) {
					m_instance = new AircraftInstanceGenerator();
				}

				return m_instance;
			}
		}
		#endregion

		public List<AircraftInstance> CreateAircraftInstances(int amount, DateTime currentTimeStamp) {
			AircraftDatabase Aircrafts = AircraftDatabase.Instance;
			AirportDatabase Airports = AirportDatabase.Instance;
			InteriorLayoutGenerator Layouts = InteriorLayoutGenerator.Instance;

            Random rnd = new Random((int)currentTimeStamp.Ticks);
			List<AircraftInstance> instances = new List<AircraftInstance>();

			for (int i = 0; i < amount; ++i) {
				Aircraft ac = Aircrafts.DB[rnd.Next(Aircrafts.DB.Count)];
				string[] regs = GetRandomRegistration(rnd);

                AircraftInstance aci = new AircraftInstance(ac,
															rnd.Next(GlobalConstants.USED_AIRCRAFT_MARKET_MAXIMUM_DISTANCE_FLOWN),
                                                            regs[rnd.Next(regs.Length)],
															GenerateRandomCommissioningDate(rnd, currentTimeStamp),
															0,
															GetRandomInstalledExtras(rnd, rnd.Next(4)),
															Airports.DB[rnd.Next(Airports.DB.Count)],
															Layouts.CreateInteriorLayout(ac),
															ac.AvailableEngines[rnd.Next(ac.AvailableEngines.Count)]);
                aci.UpdateCurrentValue();
				instances.Add(aci);
			}
			
			return instances;
		}

		AircraftInstanceGenerator() {
			
		}

		DateTime GenerateRandomCommissioningDate(Random rnd, DateTime currentTimeStamp) {
            int year = rnd.Next(GlobalConstants.USED_AIRCRAFT_MARKET_START_YEAR_FOR_INITIAL_OPERATION, currentTimeStamp.Year);
			int month = rnd.Next(1, 12);
			int day = rnd.Next(1, 28);

			return new DateTime(year, month, day);
		}

		string[] GetRandomRegistration(Random rnd, int amount = 1) {
			var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			var regs = new List<string>();

			for (int i = 0; i < amount; ++i) {
				var regChars = new char[4];

				for (int j = 0; j < regChars.Length; ++j) {
					regChars[j] = chars[rnd.Next(chars.Length)];
				}

				regs.Add("D-" + new string(regChars));
			}

			return regs.ToArray();
		}

		Dictionary<AircraftExtras, AircraftExtra> GetRandomInstalledExtras(Random rnd, int amount) {
			Dictionary<AircraftExtras, AircraftExtra> aes = new Dictionary<AircraftExtras, AircraftExtra>();
			AircraftExtras[] values = (AircraftExtras[])Enum.GetValues(typeof(AircraftExtras));

			for (int i = 0; i < amount; ++i) {
				AircraftExtras ae = (AircraftExtras)values.GetValue(rnd.Next(values.Length));
				values = values.Where(val => val != ae).ToArray();
				aes.Add(ae, new AircraftExtra(ae, 0));
			}

			return aes;
        }
	}
}
