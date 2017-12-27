using System.Collections.Generic;

namespace AirlineManager.Data {
    public class AircraftInstance {
        #region Attributes
        float m_distanceFlown;
        string m_registration;
        long m_commissioning;
        long m_currentValue;
        Aircraft m_type;
        Dictionary<AircraftExtras, AircraftExtra> m_installedExtras = new Dictionary<AircraftExtras, AircraftExtra>();
		Airport m_currentLocation;
		InteriorLayout m_interior;
		List<PlannedService> m_services = new List<PlannedService>();
        Engine m_installedEngine;
        #endregion

        #region Properties
        public float DistanceFlown {
            get {
                return m_distanceFlown;
            }
        }

        public string Registration {
            get {
                return m_registration;
            }

            set {
                if (value.Length > 0) {
                    m_registration = value;
                }
            }
        }

        public long Commissioning {
            get {
                return m_commissioning;
            }
        }

        public long CurrentValue {
            get {
                return m_currentValue;
            }
        }

        public Aircraft Type {
            get {
                return m_type;
            }
        }

		public Dictionary<AircraftExtras, AircraftExtra> InstalledExtras {
			get {
				return m_installedExtras;
			}
		}

		public Airport CurrentLocation {
			get {
				return m_currentLocation;
			}
		}

		public InteriorLayout Interior {
			get {
				return m_interior;
			}
		}

		public List<PlannedService> Services {
			get {
				return m_services;
            }
		}

		public bool IsUsed {
			get {
				return m_distanceFlown > 0;
			}
		}

        public Engine InstalledEngine {
            get {
                return m_installedEngine;
            }
        }
        #endregion

		/// <summary>
		/// New aircraft.
		/// </summary>
		/// <param name="type"></param>
		/// <param name="registration"></param>
		/// <param name="commissioning"></param>
		/// <param name="currentLocation"></param>
		/// <param name="layout"></param>
		public AircraftInstance(Aircraft type, string registration, 
								long commissioning, Airport currentLocation, 
                                InteriorLayout layout, Engine installendEngine) {
			m_distanceFlown = 0;
			m_registration = registration;
			m_commissioning = commissioning;
			m_currentValue = m_commissioning;
			m_type = type;
			m_currentLocation = currentLocation;
			m_interior = layout;
            m_installedEngine = installendEngine;
		}

		/// <summary>
		/// Used aircraft.
		/// </summary>
		/// <param name="type"></param>
		/// <param name="distanceFlown"></param>
		/// <param name="registration"></param>
		/// <param name="commissioning"></param>
		/// <param name="currentValue"></param>
		/// <param name="installedExtras"></param>
		/// <param name="currentLocation"></param>
		/// <param name="layout"></param>
        public AircraftInstance(Aircraft type, float distanceFlown, 
                                string registration, long commissioning,
                                long currentValue, 
								Dictionary<AircraftExtras,AircraftExtra> installedExtras, 
								Airport currentLocation, InteriorLayout layout,
                                Engine installendEngine) {
            m_distanceFlown = distanceFlown;
            m_registration = registration;
            m_commissioning = commissioning;
            m_currentValue = currentValue;
            m_type = type;
			m_installedExtras = installedExtras;
			m_currentLocation = currentLocation;
			m_interior = layout;
            m_installedEngine = installendEngine;
        }

        public void updateCurrentValue() {
            // TODO: Make up a nice algo to calculate the current value.
        }

        public bool IsExtraInstalled(AircraftExtras extraType) {
            return m_installedExtras[extraType] != null;
        }

		public bool Arrived(Airport destination) {
			if (destination != null) {
				m_currentLocation = destination;
				return true;
			}

			return false;
		}

		public void PlanService(PlannedService service) {
			m_services.Add(service);
		}

		public bool AbortService(PlannedService service) {
			if (m_services.Contains(service) && !service.Running) {
				m_services.Remove(service);
				return true;
			}

			return false;
		}

		override
		public string ToString() {
			return Type.ToString() + " (" + Registration + ")";
		}
	}
}
