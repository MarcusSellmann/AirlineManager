using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AirlineManager.Data {
	[DataContract]
	public class Staff {
        #region Attributes
        #endregion

        #region Properties
        [DataMember]
        public Dictionary<Department, int> EmployeeArrangement { get; private set; }

		public int TotalNeededStaff {
			get {
				int total = 0;

				foreach (KeyValuePair<Department, int> dep in EmployeeArrangement) {
					total += dep.Value;
				}

				return total;
			}
		}
		#endregion

		public Staff() : this(0, 0, 0, 0, 0, 0) {}

		public Staff(int pilots, int flightCrew, int groundCrew, int checkinCrew, int cleaningCrew, int technicians) {
            EmployeeArrangement = new Dictionary<Department, int>();
			EmployeeArrangement[Department.Pilot] = pilots;
			EmployeeArrangement[Department.FlightCrew] = flightCrew;
			EmployeeArrangement[Department.GroundCrew] = groundCrew;
			EmployeeArrangement[Department.CheckinCrew] = checkinCrew;
			EmployeeArrangement[Department.CleaningCrew] = cleaningCrew;
			EmployeeArrangement[Department.Technicians] = technicians;
		}

		public void AddEmployees(Department department, int amount) {
			if (EmployeeArrangement.ContainsKey(department)) {
				EmployeeArrangement[department] += amount;
			} else {
				EmployeeArrangement[department] = amount;
			}
		}

		public bool RemoveEmployees(Department department, int amount) {
			if (EmployeeArrangement.ContainsKey(department)) {
				if (EmployeeArrangement[department] >= amount) {
					EmployeeArrangement[department] -= amount;
					return true;
                }
			}

			return false;
		}

		public void IncrementEmployee(Department department) {
			AddEmployees(department, 1);
		}

		public bool DecrementEmployee(Department department) {
			return RemoveEmployees(department, 1);
		}

		override
		public string ToString() {
			return EmployeeArrangement[Department.Pilot] + " | " + EmployeeArrangement[Department.FlightCrew] + " | " + EmployeeArrangement[Department.GroundCrew] + " | " + EmployeeArrangement[Department.CheckinCrew] + " | " + EmployeeArrangement[Department.CleaningCrew] + " | " + EmployeeArrangement[Department.Technicians];
		}
	}
}
