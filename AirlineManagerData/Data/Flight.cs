using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AirlineManager.Data {
	[DataContract]
	public class Flight {
        #region Attributes
        [DataMember]
        Demand m_bookedPassengers;
        #endregion

        #region Properties
        [DataMember]
        public string FlightNumber { get; private set; }

        [DataMember]
        public FlightType FlightType { get; private set; }

        [DataMember]
        public FlightState State { get; private set; }

        [DataMember]
        public Route OperatingRoute { get; private set; }

        [DataMember]
        public AircraftInstance AssignedAircraft { get; private set; }

        [DataMember]
        public DateTime DepartureTime { get; private set; }

        public bool AtOrigin {
            get {
                if (IsAircraftAssigned &&
                    State != FlightState.InFlight) {
                    return OperatingRoute.Origin == AssignedAircraft.CurrentLocation;
                }

                return false;
            }
        }

        public bool AtDestination {
            get {
                if (IsAircraftAssigned &&
                    State != FlightState.InFlight) {
                    return OperatingRoute.Destination == AssignedAircraft.CurrentLocation;
                }

                return false;
            }
        }

        public long FuelCosts {
            get {
                //TODO: Create an algo for the fuel costs.
                return 0;
            }
        }

        public long MaxPossibleIncome {
            get {
                return AssignedAircraft.Interior.ClassLayout[ClassType.Economy] * OperatingRoute.TicketPrizes.Economy +
                       AssignedAircraft.Interior.ClassLayout[ClassType.Business] * OperatingRoute.TicketPrizes.Business +
                       AssignedAircraft.Interior.ClassLayout[ClassType.First] * OperatingRoute.TicketPrizes.First +
                       AssignedAircraft.Interior.ClassLayout[ClassType.Cargo] * OperatingRoute.TicketPrizes.Cargo;
            }
        }

        public bool IsAircraftAssigned {
            get {
                return AssignedAircraft != null;
            }
        }

        /// <summary>
        /// Returns the flight time in hours.
        /// </summary>
        public double TotalFlightTime {
            get {
                return AssignedAircraft.Type.TravelVelocity / OperatingRoute.Distance;
            }
        }

        public Demand BookedPassengers {
			get {
				return m_bookedPassengers;
			}

			set {
				if (value != null) {
					m_bookedPassengers = value;
                }
			}
		}

		public TimeSpan CurrentFlightTime {
			get {
                TimeSpan flightTime = DateTime.Now - DepartureTime;

                if (flightTime < TimeSpan.FromSeconds(0) ||
                    State != FlightState.InFlight) {
                    return TimeSpan.FromSeconds(0);
                } else {
                    return DateTime.Now - DepartureTime;
                }
			}
		}

        public DateTime EstimatedArrivalTime {
            get {
                return DepartureTime + TimeSpan.FromHours(TotalFlightTime);
            }
        }
		#endregion

		public Flight(string flightNumber, Route operatingRoute, FlightType flightType, FlightState state) {
            FlightNumber = flightNumber;
            OperatingRoute = operatingRoute;
			FlightType = flightType;
			State = state;
		}

		public Flight(string flightNumber, Route operatingRoute, FlightType flightType, FlightState state, DateTime departureTime, Demand bookedPassengers = null) : this(flightNumber, operatingRoute, flightType, state) {
			m_bookedPassengers = bookedPassengers;
            DepartureTime = departureTime;
        }

		public void Depart() {
			DepartureTime = DateTime.Now;
		}

		public DateTime CalcEstimatedArrival(double totalFlightTime) {
			return DateTime.Now + CalcFlightTimeLeft(totalFlightTime);
		}

		public TimeSpan CalcFlightTimeLeft(double totalFlightTime) {
			return TimeSpan.FromHours(totalFlightTime) - CurrentFlightTime;
        }

        public void AssignAircraft(AircraftInstance aircraftInstance) {
            AssignedAircraft = aircraftInstance;
            AssignedAircraft.AssignedFlight = this;
        }
    }
}
