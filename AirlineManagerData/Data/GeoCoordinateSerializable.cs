using System.Runtime.Serialization;
using GeoCoordinatePortable;

namespace AirlineManager.Data {
    [DataContract]
    public class GeoCoordinateSerializable {
        GeoCoordinate m_geoCoordinate = new GeoCoordinate();

        #region Properties
        [DataMember]
        public double Course {
            get {
                return m_geoCoordinate.Course;
            }

            set {
                m_geoCoordinate.Course = value;

                if (m_geoCoordinate == null) {
                    m_geoCoordinate = new GeoCoordinate();
                }
            }
        }

        [DataMember]
        public double Speed {
            get {
                return m_geoCoordinate.Speed;
            }

            set {
                m_geoCoordinate.Speed = value;

                if (m_geoCoordinate == null) {
                    m_geoCoordinate = new GeoCoordinate();
                }
            }
        }

        [DataMember]
        public double VerticalAccuracy {
            get {
                return m_geoCoordinate.VerticalAccuracy;
            }

            set {
                m_geoCoordinate.VerticalAccuracy = value;

                if (m_geoCoordinate == null) {
                    m_geoCoordinate = new GeoCoordinate();
                }
            }
        }

        [DataMember]
        public double HorizontalAccuracy {
            get {
                return m_geoCoordinate.HorizontalAccuracy;
            }

            set {
                m_geoCoordinate.HorizontalAccuracy = value;

                if (m_geoCoordinate == null) {
                    m_geoCoordinate = new GeoCoordinate();
                }
            }
        }

        [DataMember]
        public double Longitude {
            get {
                return m_geoCoordinate.Longitude;
            }

            set {
                m_geoCoordinate.Longitude = value;

                if (m_geoCoordinate == null) {
                    m_geoCoordinate = new GeoCoordinate();
                }
            }
        }

        [DataMember]
        public double Latitude {
            get {
                return m_geoCoordinate.Latitude;
            }

            set {
                if (m_geoCoordinate == null) {
                    m_geoCoordinate = new GeoCoordinate();
                }

                m_geoCoordinate.Latitude = value;
            }
        }

        [DataMember]
        public double Altitude {
            get {
                return m_geoCoordinate.Altitude;
            }

            set {
                if (m_geoCoordinate == null) {
                    m_geoCoordinate = new GeoCoordinate();
                }

                m_geoCoordinate.Altitude = value;
            }
        }
        #endregion

        public GeoCoordinateSerializable() {
            m_geoCoordinate = new GeoCoordinate();
        }

        public GeoCoordinateSerializable(GeoCoordinate gC) {
            m_geoCoordinate = gC;
        }

        public GeoCoordinate GetGeoCoordinate() {
            return m_geoCoordinate;
        }
    }
}
