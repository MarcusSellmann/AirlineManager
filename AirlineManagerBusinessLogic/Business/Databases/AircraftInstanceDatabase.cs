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

		AircraftInstanceDatabase(DateTime currentTimestamp) {
			CreateNewUsedAirplanes(GlobalConstants.USED_AIRCRAFT_MARKET_INITIAL_INSTANCE_AMOUNT, currentTimestamp);

			m_dbUpdateTimer = new Timer();
			m_dbUpdateTimer.Interval = TimeSpan.FromMinutes(GlobalConstants.USED_AIRCRAFT_MARKET_UPDATE_INTERVAL_MINUTES).Ticks;

            m_dbUpdateTimer.Elapsed += UpdateDatabase;
            m_dbUpdateTimer.Start();
        }

		private void UpdateDatabase(object sender, ElapsedEventArgs e) {
			DateTime cTime = MainGameController.Instance.GameClock.CurrentGameTime;
			CreateNewUsedAirplanes(RemoveExpiredAircraftOffersFromDatabase(cTime), cTime);
		}

		/// <summary>
		/// Removes offers of aircrafts which are expired according to the <code>currentTimestamp</code>.
		/// </summary>
		/// <param name="currentTimestamp">The current timestamp of the game.</param>
		/// <returns>The number of aircraft offers, which has been removed.</returns>
		private int RemoveExpiredAircraftOffersFromDatabase(DateTime currentTimestamp) {
			int airplanesRemoved = 0;

			foreach (UsedAircraftInstanceContainer ac in m_usedAircraftList) {
                if (ac.AvailableTill <= currentTimestamp) {
					m_usedAircraftList.Remove(ac);
					++airplanesRemoved;
				}
			}

			return airplanesRemoved;
		}

		/// <summary>
		/// Creates a certain <code>amount</code> of used aircrafts.
		/// </summary>
		/// <param name="amount">The amount of aircrafts to create.</param>
		/// <param name="currentTimestamp">The current timestamp of the game.</param>
		private void CreateNewUsedAirplanes(int amount, DateTime currentTimestamp) {
			List<AircraftInstance> aircrafts = AircraftInstanceGenerator.Instance.CreateAircraftInstances(amount, currentTimestamp);

			Random rnd;

			foreach (AircraftInstance aci in aircrafts) {
                rnd = new Random((int)DateTime.Now.Ticks);
                bool succ = false;
                DateTime dateDiff = currentTimestamp;

                do {
                    try {
                        dateDiff = new DateTime(rnd.Next(0, 5), rnd.Next(0, 12), rnd.Next(0, 30));
                        succ = true;
                    } catch (Exception) {
                        succ = false;
                    }
                } while (!succ);

                m_usedAircraftList.Add(new UsedAircraftInstanceContainer(aci, currentTimestamp.AddTicks(dateDiff.Ticks)));
			}
		}
	}
}
