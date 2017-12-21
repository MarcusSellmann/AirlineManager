using System.Collections.Generic;

namespace AirlineManager.Data {
	public class Route {
		#region Attributes
		string m_routeNumber;
		RouteType m_routeType;
		Airport m_origin;
		Airport m_destination;
		AircraftInstance m_assignedAircraft;
		Dictionary<ClassType, long> m_ticketPrizePerClass = new Dictionary<ClassType, long>();
		List<Flight> m_operatedFlights = new List<Flight>();
		#endregion

		#region Properties
		public string RouteNumber {
			get {
				return m_routeNumber;
			}

			set {
				if (value.Length > 0) {
					m_routeNumber = value;
				}
			}
		}

		public RouteType RouteType {
			get {
				return m_routeType;
			}
		}

		public Airport Origin {
			get {
				return m_origin;
			}
		}

		public Airport Destination {
			get {
				return m_destination;
			}
		}

		public AircraftInstance AssignedAircraft {
			get {
				return m_assignedAircraft;
			}

			set {
				m_assignedAircraft = value;
			}
		}

		public Dictionary<ClassType, long> TicketPrizePerClass {
			get {
				return m_ticketPrizePerClass;
			}

			set {
				m_ticketPrizePerClass = value;
			}
		}

		public List<Flight> OperatedFlights {
			get {
				return m_operatedFlights;
			}
		}

		public double Distance {
			get {
				return Origin.Coordinate.GetDistanceTo(Destination.Coordinate);
			}
		}

		public bool AtOrigin {
			get {
                if (IsAircraftAssigned &&
					m_operatedFlights.Count > 0 &&
					m_operatedFlights[m_operatedFlights.Count - 1].State != FlightState.InFlight) {
					return m_origin == m_assignedAircraft.CurrentLocation;
				}

				return false;
			}
		}

		public bool AtDestination {
			get {
				if (IsAircraftAssigned &&
					m_operatedFlights.Count > 0 &&
					m_operatedFlights[m_operatedFlights.Count - 1].State != FlightState.InFlight) {
					return m_destination == m_assignedAircraft.CurrentLocation;
				}

				return false;
			}
		}

		public long FuelCosts {
			get {
				/*
				Related to the distance. See problem there.
				*/
				return 0;
			}
		}

		public long MaxPossibleIncome {
			get {
				long totalIncome = 0;

				foreach (KeyValuePair<ClassType, long> ticketPrize in m_ticketPrizePerClass) {
					totalIncome += m_assignedAircraft.Interior.ClassLayout[ticketPrize.Key] * ticketPrize.Value;
				}

				return totalIncome;
			}
		}

		public bool IsAircraftAssigned {
			get {
				return m_assignedAircraft != null;
			}
		}

		public int NumberOperatedFlights {
			get {
				return m_operatedFlights.Count;
			}
		}
		#endregion

		public Route(RouteType routeType, string routeNumber, Airport origin, Airport destination, 
					 AircraftInstance assignedAircraft, Dictionary<ClassType, long> ticketPrizePerClass) {
			m_routeType = routeType;
			m_routeNumber = routeNumber;
			m_origin = origin;
			m_destination = destination;
			m_assignedAircraft = assignedAircraft;
			m_ticketPrizePerClass = ticketPrizePerClass;
		}

		override
		public string ToString() {
			return RouteNumber;
		}
	}
}
