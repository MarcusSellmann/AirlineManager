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
        public Dictionary<ClassType, long> TicketPrizePerClass { get; set; }

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
					 Dictionary<ClassType, long> ticketPrizePerClass) {
			RouteType = routeType;
			m_routeNumber = routeNumber;
			Origin = origin;
			Destination = destination;
			
            TicketPrizePerClass = new Dictionary<ClassType, long>();

            if (ticketPrizePerClass != null) {
                foreach (KeyValuePair<ClassType, long> tp in ticketPrizePerClass) {
                    TicketPrizePerClass[tp.Key] = tp.Value;
                }
            }
        }

		override
		public string ToString() {
			return RouteNumber;
		}
	}
}
