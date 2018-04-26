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
                long totalIncome = 0;

                foreach (KeyValuePair<ClassType, long> ticketPrize in OperatingRoute.TicketPrizePerClass) {
                    totalIncome += AssignedAircraft.Interior.ClassLayout[ticketPrize.Key] * ticketPrize.Value;
                }

                return totalIncome;
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
				return DateTime.Now - DepartureTime;
			}
		}

        public DateTime EstimatedArrivalTime {
            get {
                return DepartureTime + TimeSpan.FromHours(TotalFlightTime);
            }
        }
		#endregion

		public Flight(string flightNumber, FlightType flightType, FlightState state) {
            FlightNumber = flightNumber;
			FlightType = flightType;
			State = state;
		}

		public Flight(string flightNumber, FlightType flightType, FlightState state, DateTime departureTime, Demand bookedPassengers = null) : this(flightNumber, flightType, state) {
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
