using System;
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
        public DateTime DepartureTime { get; set; }

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

        public long MaxPossibleIncome {
            get {
                return AssignedAircraft.Interior.ClassLayout[ClassType.Economy] * OperatingRoute.TicketPrizes.Economy +
                       AssignedAircraft.Interior.ClassLayout[ClassType.Business] * OperatingRoute.TicketPrizes.Business +
                       AssignedAircraft.Interior.ClassLayout[ClassType.First] * OperatingRoute.TicketPrizes.First +
                       AssignedAircraft.Interior.ClassLayout[ClassType.Cargo] * OperatingRoute.TicketPrizes.Cargo;
            }
        }

        public bool IsAircraftAssigned {
            get => AssignedAircraft != null;
        }

        public Demand BookedPassengers {
			get => m_bookedPassengers;

			set {
				if (value != null) {
					m_bookedPassengers = value;
                }
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

        public void AssignAircraft(AircraftInstance aircraftInstance) {
            AssignedAircraft = aircraftInstance;
            AssignedAircraft.AssignedFlight = this;
        }
    }
}
