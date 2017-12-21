using System.Device.Location;

namespace AirlineManager.Data {
	public class Airport {
		#region Attributes
		ICAOCode m_codeICAO;
		string m_codeIATA;
		string m_name;
		string m_city;
		int m_maximalRunwayLength;
		GeoCoordinate m_coord;
		#endregion

		#region Properties
		public ICAOCode CodeICAO {
			get {
				return m_codeICAO;
			}
		}

		public string CodeIATA {
			get {
				return m_codeIATA;
			}
		}

		public string Name {
			get {
				return m_name;
			}
		}

		public string City {
			get {
				return m_city;
			}
		}

		public int MaximalRunwayLength {
			get {
				return m_maximalRunwayLength;
			}
		}

		public GeoCoordinate Coordinate {
			get {
				return m_coord;
			}
		}

		public string Country {
			get {
				return m_codeICAO.Country;
			}
		}
		#endregion

		public Airport(ICAOCode codeICAO, string codeIATA, string name, string city,
					   int maximalRunwayLength, GeoCoordinate coord) {
			m_codeICAO = codeICAO;
			m_codeIATA = codeIATA;
			m_name = name;
			m_city = city;
			m_maximalRunwayLength = maximalRunwayLength;
			m_coord = coord;
		}

		override
		public string ToString() {
			return Name;
		}
	}
}
