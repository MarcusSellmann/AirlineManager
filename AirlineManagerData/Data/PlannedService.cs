﻿using System;
using System.Runtime.Serialization;

namespace AirlineManager.Data {
	[DataContract]
	public class PlannedService {
        #region Attributes
        #endregion

        #region Properties
        [DataMember]
        public ServiceLevel Level { get; private set; }

        [DataMember]
        public DateTime StartTime { get; private set; }

        [DataMember]
        public TimeSpan Duration { get; private set; }

        [DataMember]
        public long Costs { get; private set; }

        public DateTime EndTime {
			get {
				return StartTime + Duration;
			}
		}

		public bool Running {
			get {
				return (StartTime < DateTime.Now) && !Executed;
			}
		}

		public bool Executed {
			get {
				return EndTime < DateTime.Now;
			}
		}
		#endregion

		public PlannedService(ServiceLevel level, DateTime startTime, TimeSpan duration, long costs) {
            Level = level;
			StartTime = startTime;
			Duration = duration;
			Costs = costs;
		}

		override
		public string ToString() {
			return Level.ToString() + ": " + StartTime.ToString() + " -> " + EndTime.ToString();
		}
	}
}
