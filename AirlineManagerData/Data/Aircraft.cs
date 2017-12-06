namespace AirlineManager.Data {
    public class Aircraft {
        #region Attributes
        string m_name;
        float m_length;
        float m_width;
        float m_height;
        float m_fuelUsagePerMinute;
        string m_image;
        long m_originalPrize;
        int m_travelVelocity;
        int m_range;
        long m_turnoverTime;
		int m_minimalNeededRunwayLength;
		Staff m_neededStaff;
        #endregion

        #region Properties
        public string Name {
            get {
                return m_name;
            }
        }

        public float Length {
            get {
                return m_length;
            }
        }

        public float Width {
            get {
                return m_width;
            }
        }

        public float Height {
            get {
                return m_height;
            }
        }

        public float FuelUsagePerMinute {
            get {
                return m_fuelUsagePerMinute;
            }
        }

        public string Image {
            get {
                return m_image;
            }
        }

        public long OriginalPrize {
            get {
                return m_originalPrize;
            }
        }

        public int TravelVelocity {
            get {
                return m_travelVelocity;
            }
        }

        public int Range {
            get {
                return m_range;
            }
        }

        public long TurnoverTime {
            get {
                return m_turnoverTime;
            }
        }

		public int MinimalNeededRunwayLength {
			get {
				return m_minimalNeededRunwayLength;
			}
		}

		public Staff NeededStaff {
			get {
				return m_neededStaff;
			}
		}
        #endregion

        public Aircraft(string name, float length, float width, float height, 
                        float fuelUsagePerMinute, string image, 
                        long originalPrize, int travelVelocity, int range, 
                        long turnoverTime, int minimalNeededRunwayLength, Staff neededStaff) {
            m_name = name;
            m_length = length;
            m_width = width;
            m_height = height;
            m_fuelUsagePerMinute = fuelUsagePerMinute;
            m_image = image;
            m_originalPrize = originalPrize;
            m_travelVelocity = travelVelocity;
            m_range = range;
            m_turnoverTime = turnoverTime;
			m_minimalNeededRunwayLength = minimalNeededRunwayLength;
			m_neededStaff = neededStaff;
        }
    }
}