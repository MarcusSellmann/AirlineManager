namespace AirlineManager.Data {
	public class EmployeeGroup {
		#region Attributes
		Department m_groupDepartment;
		int m_numberOfEmployees;
		long m_loanPerEmployee;
		#endregion

		#region Properties
		public Department GroupDepartment {
			get {
				return m_groupDepartment;
			}
		}

		public int NumberOfEmployees {
			get {
				return m_numberOfEmployees;
            }
		}

		public long LoanPerEmployee {
			get {
				return m_loanPerEmployee;
			}

			set {
				if (value > 0) {
					m_loanPerEmployee = value;
				}
			}
		}

		public long TotalLoan {
			get {
				return m_numberOfEmployees * m_loanPerEmployee;
			}
		}
		#endregion

		public EmployeeGroup(Department department, int numberOfEmployees, int loanPerEmployee) {
			m_groupDepartment = department;
			m_numberOfEmployees = numberOfEmployees;
			m_loanPerEmployee = loanPerEmployee;
		}

		private void updateMotivation() {
			// TODO: Implement motivation
		}
	}
}
