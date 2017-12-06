using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineManager.Data {
	public class PlannedService {
		#region Attributes
		long m_startTime;
		long m_duration;
		long m_costs;
		#endregion

		#region Properties
		public long StartTime {
			get {
				return m_startTime;
			}
		}

		public long Duration {
			get {
				return m_duration;
			}
		}

		public long EndTime {
			get {
				return StartTime + Duration;
			}
		}

		public long Costs {
			get {
				return m_costs;
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
			m_startTime = startTime;
			m_duration = duration;
			m_costs = costs;
		}
	}
}
