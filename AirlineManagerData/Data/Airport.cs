using System.Runtime.Serialization;
using GeoCoordinatePortable;

namespace AirlineManager.Data {
	[DataContract]
	public class Airport {
		#region Attributes
        #endregion

        #region Properties
        [DataMember]
        public ICAOCode CodeICAO { get; private set; }

        [DataMember]
        public string CodeIATA { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public string City { get; private set; }

        [DataMember]
        public int MaximalRunwayLength { get; private set; }

		public GeoCoordinate Coordinate { get; private set; }

        [DataMember]
        GeoCoordinateSerializable CoordinateS {
            get => new GeoCoordinateSerializable(Coordinate);

            set {
                Coordinate = value.GetGeoCoordinate();
            }
        }

        public string Country {
			get => CodeICAO.Country;
		}
		#endregion

		public Airport(ICAOCode codeICAO, string codeIATA, string name, string city,
					   int maximalRunwayLength, GeoCoordinate coord) {
			CodeICAO = codeICAO;
			CodeIATA = codeIATA;
			Name = name;
			City = city;
			MaximalRunwayLength = maximalRunwayLength;
			Coordinate = coord;
            CoordinateS = new GeoCoordinateSerializable(coord);
		}

		override
		public string ToString() {
			return Name;
		}
	}
}
