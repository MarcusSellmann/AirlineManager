using System.Collections.Generic;

namespace AirlineManager.Data {
    public class Airline {
        const long MONEY_AT_GAME_START = 1000000L;
        const int REPUTATION_AT_GAME_START = 75;

        #region Attributes
        Player m_ownership;
        string m_name;
        string m_airlineCode;
        long m_money;
        int m_reputation;
		List<AircraftInstance> m_ownedAircrafts = new List<AircraftInstance>();
		List<EmployeeGroup> m_staff = new List<EmployeeGroup>();
		List<Route> m_routeNetwork = new List<Route>();
        #endregion

        #region Properties
        public Player Ownership {
            get {
                return m_ownership;
            }

            private set {
                m_ownership = value;
            }
        }

        public string Name {
            get {
                return m_name;
            }

            private set {
                m_name = value;
            }
        }

        public string AirlineCode {
            get {
                return m_airlineCode;
            }

            private set {
                m_airlineCode = value;
            }
        }

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

		public List<AircraftInstance> OwnedAircrafts {
			get {
				return m_ownedAircrafts;
			}
		}

		public List<EmployeeGroup> Staff {
			get {
				return m_staff;
			}
		}

		public List<Route> RouteNetwork {
			get {
				return m_routeNetwork;
			}
		}
		#endregion

		public Airline(Player currPlayer, string name, string airlineCode, List<AircraftInstance> ownedAircrafts, List<EmployeeGroup> staff) {
            Ownership = currPlayer;
            Name = name;
            AirlineCode = airlineCode;
            Money = MONEY_AT_GAME_START;
            Reputation = REPUTATION_AT_GAME_START;
			m_ownedAircrafts = ownedAircrafts;
			m_staff = staff;
        }

		public Airline(Player currPlayer, string name, string airlineCode, long money, int reputation, 
					   List<AircraftInstance> ownedAircrafts, List<EmployeeGroup> staff, List<Route> routeNetwork) {
			Ownership = currPlayer;
			Name = name;
			AirlineCode = airlineCode;
			Money = money;
			Reputation = reputation;
			m_ownedAircrafts = ownedAircrafts;
			m_staff = staff;
			m_routeNetwork = routeNetwork;
        }

		public void AddRoute(Route route) {
			m_routeNetwork.Add(route);
		}

		public bool RemoveRoute(Route route) {
			if (m_routeNetwork.Contains(route)) {
				m_routeNetwork.Remove(route);
				return true;
			}

			return false;
		}
    }
}