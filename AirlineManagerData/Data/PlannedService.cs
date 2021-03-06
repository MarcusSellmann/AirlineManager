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
			get => StartTime + Duration;
		}
		#endregion

		public PlannedService(ServiceLevel level, DateTime startTime, TimeSpan duration, long costs) {
            Level = level;
			StartTime = startTime;
			Duration = duration;
			Costs = costs;
		}

        public bool IsRunning(DateTime currentTimeStamp) {
            return (StartTime < currentTimeStamp) && !IsExecuted(currentTimeStamp);
        }

        public bool IsExecuted(DateTime currentTimeStamp) {
            return EndTime < currentTimeStamp;
        }

        override
		public string ToString() => Level.ToString() + ": " + StartTime.ToString() + " -> " + EndTime.ToString();
	}
}
