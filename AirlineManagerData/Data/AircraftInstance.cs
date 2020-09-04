using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AirlineManager.Data {
	[DataContract]
	public class AircraftInstance {
        #region Attributes
        [DataMember]
        string m_registration;
        #endregion

        #region Properties
        [DataMember]
        public float HoursFlown { get; private set; }

        [DataMember]
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

        [DataMember]
        public DateTime InitialOperation { get; private set; }

        [DataMember]
        public Aircraft Type { get; private set; }

        [DataMember]
        public Dictionary<AircraftExtras, AircraftExtra> InstalledExtras { get; private set; }

        [DataMember]
        public Airport CurrentLocation { get; private set; }

        [DataMember]
        public Flight AssignedFlight { get; set; }

        [DataMember]
        public InteriorLayout Interior { get; private set; }

        [DataMember]
        public List<PlannedService> Services { get; private set; }

        [DataMember]
        public Engine InstalledEngine { get; private set; }

        public bool IsUsed {
            get => HoursFlown > 0;
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
								DateTime commissioning, Airport currentLocation, 
                                InteriorLayout layout, Engine installendEngine) : 
            this(type, 0, registration, commissioning, null, 
                 currentLocation, layout, installendEngine) {}

        /// <summary>
        /// Used aircraft.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="hoursFlown"></param>
        /// <param name="registration"></param>
        /// <param name="commissioning"></param>
        /// <param name="currentValue"></param>
        /// <param name="installedExtras"></param>
        /// <param name="currentLocation"></param>
        /// <param name="layout"></param>
        public AircraftInstance(Aircraft type, float hoursFlown, 
                                string registration, DateTime commissioning,
								Dictionary<AircraftExtras,AircraftExtra> installedExtras, 
								Airport currentLocation, InteriorLayout layout,
                                Engine installendEngine) {
            Type = type;
            HoursFlown = hoursFlown;
            m_registration = registration;
            InitialOperation = commissioning;
			CurrentLocation = currentLocation;
			Interior = layout;
            InstalledEngine = installendEngine;

            InstalledExtras = new Dictionary<AircraftExtras, AircraftExtra>();

            if (installedExtras != null) {
                foreach (KeyValuePair<AircraftExtras, AircraftExtra> ie in installedExtras) {
                    InstalledExtras[ie.Key] = ie.Value;
                }
            }

            Services = new List<PlannedService>();
        }

        public bool IsExtraInstalled(AircraftExtras extraType) {
            return InstalledExtras[extraType] != null;
        }

		public bool Arrived(Airport destination) {
			if (destination != null) {
                CurrentLocation = destination;
				return true;
			}

			return false;
		}

		public void PlanService(PlannedService service) {
			Services.Add(service);
		}

		public bool AbortService(PlannedService service, DateTime currentTimestamp) {
			if (Services.Contains(service) && !service.IsRunning(currentTimestamp)) {
				Services.Remove(service);
				return true;
			}

			return false;
		}

		override
		public string ToString() {
			return Type + " (" + Registration + ")";
		}
	}
}
