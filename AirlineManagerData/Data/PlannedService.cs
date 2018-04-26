using System;
using System.Runtime.Serialization;

namespace AirlineManager.Data {
	[DataContract]
	public class PlannedService {
        #region Attributes
        #endregion

        #region Properties
        [DataMember]
        public long StartTime { get; private set; }

        [DataMember]
        public long Duration { get; private set; }

        [DataMember]
        public long Costs { get; private set; }

        public long EndTime {
			get {
				return StartTime + Duration;
			}
		}

		public bool Running {
			get {
				return (StartTime < DateTime.Now.Ticks) && !Executed;
			}
		}

		public bool Executed {
			get {
				return EndTime < DateTime.Now.Ticks;
			}
		}
		#endregion

		public PlannedService(long startTime, long duration, long costs) {
			StartTime = startTime;
			Duration = duration;
			Costs = costs;
		}

		override
		public string ToString() {
			return StartTime.ToString();
		}
	}
}
