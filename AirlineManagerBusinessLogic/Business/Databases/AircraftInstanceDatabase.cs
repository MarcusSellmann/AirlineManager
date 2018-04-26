using System;
using System.Collections.Generic;
using System.Timers;
using AirlineManager.Business.Generators;
using AirlineManager.Data;

namespace AirlineManager.Business.Databases {
	public class AircraftInstanceDatabase {
		#region Attributes
		static AircraftInstanceDatabase m_instance = null;
		List<UsedAircraftInstanceContainer> m_usedAircraftList = new List<UsedAircraftInstanceContainer>();
		Timer m_dbUpdateTimer = null;
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

		public List<UsedAircraftInstanceContainer> UsedAircrafts {
			get {
				return m_usedAircraftList;
			}

			set {
				if (m_usedAircraftList.Count == 0) {
					m_usedAircraftList = value;
				}
			}
		}

		public int NumberOfUsedAircraftsAvailable {
			get {
				return m_usedAircraftList.Count;
			}
		}
		#endregion

		AircraftInstanceDatabase() {
			CreateNewUsedAirplanes(GlobalConstants.USED_AIRCRAFT_MARKET_INITIAL_INSTANCE_AMOUNT);

			m_dbUpdateTimer = new Timer();
			m_dbUpdateTimer.Interval = TimeSpan.FromMinutes(GlobalConstants.USED_AIRCRAFT_MARKET_UPDATE_INTERVAL_MINUTES).Ticks;

            m_dbUpdateTimer.Elapsed += UpdateDatabase;
            m_dbUpdateTimer.Start();

        }

		private void UpdateDatabase(object sender, ElapsedEventArgs e) {
			CreateNewUsedAirplanes(CleanupDatabaseIfNeeded());
		}

		private int CleanupDatabaseIfNeeded() {
			int airplanesRemoved = 0;

			foreach (UsedAircraftInstanceContainer ac in m_usedAircraftList) {
				if (ac.AvailableTill <= DateTime.Now) {
					m_usedAircraftList.Remove(ac);
					++airplanesRemoved;
				}
			}

			return airplanesRemoved;
		}

		private void CreateNewUsedAirplanes(int amount) {
			List<AircraftInstance> aircrafts = AircraftInstanceGenerator.Instance.CreateAircraftInstances(amount);

			Random rnd;

			foreach (AircraftInstance aci in aircrafts) {
                rnd = new Random((int)DateTime.Now.Ticks);
                bool succ = false;
                DateTime dateDiff = DateTime.Now;

                do {
                    try {
                        dateDiff = new DateTime(rnd.Next(0, 5), rnd.Next(0, 12), rnd.Next(0, 30));
                        succ = true;
                    } catch (Exception) {
                        succ = false;
                    }
                } while (!succ);
                
                m_usedAircraftList.Add(new UsedAircraftInstanceContainer(aci, DateTime.Now.AddTicks(dateDiff.Ticks)));
			}
		}
	}
}
