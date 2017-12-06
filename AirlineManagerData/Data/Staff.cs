using System.Collections.Generic;

namespace AirlineManager.Data {
	public class Staff {
		#region Attributes
		Dictionary<Department, int> m_employeeArrangement = new Dictionary<Department, int>();
		#endregion

		#region Properties
		public Dictionary<Department, int> EmployeeArrangement {
			get {
				return m_employeeArrangement;
			}
		}

		public int TotalNeededStaff {
			get {
				int total = 0;

				foreach (KeyValuePair<Department, int> dep in m_employeeArrangement) {
					total += dep.Value;
				}

				return total;
			}
		}
		#endregion

		public Staff() {
			m_employeeArrangement[Department.Pilot] = 0;
			m_employeeArrangement[Department.FlightCrew] = 0;
			m_employeeArrangement[Department.GroundCrew] = 0;
			m_employeeArrangement[Department.CheckinCrew] = 0;
			m_employeeArrangement[Department.CleaningCrew] = 0;
			m_employeeArrangement[Department.Technicians] = 0;
		}

		public Staff(int pilots, int flightCrew, int groundCrew, int checkinCrew, int cleaningCrew, int technicians) {
			m_employeeArrangement[Department.Pilot] = pilots;
			m_employeeArrangement[Department.FlightCrew] = flightCrew;
			m_employeeArrangement[Department.GroundCrew] = groundCrew;
			m_employeeArrangement[Department.CheckinCrew] = checkinCrew;
			m_employeeArrangement[Department.CleaningCrew] = cleaningCrew;
			m_employeeArrangement[Department.Technicians] = technicians;
		}

		public void AddEmployees(Department department, int amount) {
			if (m_employeeArrangement.ContainsKey(department)) {
				m_employeeArrangement[department] += amount;
			} else {
				m_employeeArrangement[department] = amount;
			}
		}

		public bool RemoveEmployees(Department department, int amount) {
			if (m_employeeArrangement.ContainsKey(department)) {
				if (m_employeeArrangement[department] >= amount) {
					m_employeeArrangement[department] -= amount;
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
	}
}
