using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AirlineManager.Data {
	[DataContract]
	public class Airline {
        const long MONEY_AT_GAME_START = 50000000L;
        const int REPUTATION_AT_GAME_START = 75;
        public const long PRIZE_AIRPORT_LICENSE = 10000L;

        #region Attributes
        [DataMember]
        long m_money;

        [DataMember]
        int m_reputation;
        #endregion

        #region Properties
        [DataMember]
        public Player Ownership { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public string AirlineCode { get; private set; }

        [DataMember]
        public List<AircraftInstance> OwnedAircrafts { get; private set; }

        [DataMember]
        public List<Airport> LicensedAirports { get; private set; }

        [DataMember]
        public List<EmployeeGroup> Staff { get; private set; }

        [DataMember]
        public List<Route> RouteNetwork { get; private set; }

        [DataMember]
        public FlightSchedule FlightSchedule { get; private set; }

        [DataMember]
        public FlightHistory FlightHistory { get; private set; }

        public long Money {
            get {
                return m_money;
            }

            private set {
                if (value >= 0) {
                    m_money = value;
                }
            }
        }

        public int Reputation {
            get {
                return m_reputation;
            }

            private set {
                if (value >= 0) {
                    m_reputation = value;
                }
            }
        }

        public List<AircraftInstance> UnassignedAircrafts
        {
            get
            {
                List<AircraftInstance> ais = new List<AircraftInstance>();

                foreach (AircraftInstance ai in OwnedAircrafts)
                {
                    if (ai.AssignedFlight == null)
                    {
                        ais.Add(ai);
                    }
                }

                return ais;
            }
        }

        public Dictionary<AircraftInstance, List<PlannedService>> AllPlannedServices {
            get {
                Dictionary<AircraftInstance, List<PlannedService>> plannedServiceDict = new Dictionary<AircraftInstance, List<PlannedService>>();

                foreach (AircraftInstance ai in OwnedAircrafts) {
                    plannedServiceDict[ai] = ai.Services;
                }

                return plannedServiceDict;
            }
        }
        #endregion

        public Airline(Player currPlayer, string name, string airlineCode, List<AircraftInstance> ownedAircrafts, List<EmployeeGroup> staff) :
            this(currPlayer, name, airlineCode, MONEY_AT_GAME_START, REPUTATION_AT_GAME_START, ownedAircrafts, staff, null) {}

		public Airline(Player currPlayer, string name, string airlineCode, long money, int reputation, 
					   List<AircraftInstance> ownedAircrafts, List<EmployeeGroup> staff, List<Route> routeNetwork) {
			Ownership = currPlayer;
			Name = name;
			AirlineCode = airlineCode;
			Money = money;
			Reputation = reputation;

            OwnedAircrafts = new List<AircraftInstance>();

            if (ownedAircrafts != null) {
                OwnedAircrafts.AddRange(ownedAircrafts);
            }

            Staff = new List<EmployeeGroup>();

            if (staff != null) {
                Staff.AddRange(staff);
            }

			RouteNetwork = new List<Route>();

            if (routeNetwork != null) {
                RouteNetwork.AddRange(routeNetwork);
            }

            LicensedAirports = new List<Airport>();
            FlightSchedule = new FlightSchedule();
            FlightHistory = new FlightHistory();
        }

		public void AddRoute(Route route) {
			RouteNetwork.Add(route);
		}

		public bool RemoveRoute(Route route) {
			if (RouteNetwork.Contains(route)) {
				RouteNetwork.Remove(route);
				return true;
			}

			return false;
		}

        public bool BuyAircraft(AircraftInstance aircraftInstance) {
            if (aircraftInstance.CurrentValue > m_money) {
                return false;
            }

            m_money -= aircraftInstance.CurrentValue;
            OwnedAircrafts.Add(aircraftInstance);

            return true;
        }

        public bool BuyAirportLicense(Airport airport) {
            if (m_money >= PRIZE_AIRPORT_LICENSE) {
                LicensedAirports.Add(airport);
                m_money -= PRIZE_AIRPORT_LICENSE;
            }

            return false;
        }
        
        override
		public string ToString() {
			return Name;
		}
	}
}