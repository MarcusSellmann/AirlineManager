using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AirlineManager.Data {
	[DataContract]
	public class Route {
        #region Attributes
        [DataMember]
        string m_routeNumber;
        #endregion

        #region Properties
        [DataMember]
        public RouteType RouteType { get; private set; }

        [DataMember]
        public Airport Origin { get; private set; }

        [DataMember]
        public Airport Destination { get; private set; }

        [DataMember]
        public TicketPrizes TicketPrizes { get; set; }

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

        public double Distance {
			get {
				return Origin.Coordinate.GetDistanceTo(Destination.Coordinate);
			}
		}
		#endregion

		public Route(RouteType routeType, string routeNumber, Airport origin, Airport destination, 
					 TicketPrizes ticketPrizes) {
			RouteType = routeType;
			m_routeNumber = routeNumber;
			Origin = origin;
			Destination = destination;
            TicketPrizes = ticketPrizes;
        }

		override
		public string ToString() {
			return RouteNumber;
		}
	}
}
