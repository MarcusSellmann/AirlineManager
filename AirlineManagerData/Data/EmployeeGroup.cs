using System.Runtime.Serialization;

namespace AirlineManager.Data {
	[DataContract]
	public class EmployeeGroup {
        #region Attributes
        [DataMember]
        long m_loanPerEmployee;
        #endregion

        #region Properties
        [DataMember]
        public Department GroupDepartment { get; private set; }

        [DataMember]
        public int NumberOfEmployees { get; private set; }

		public long LoanPerEmployee {
			get => m_loanPerEmployee;

			set {
				if (value > 0) {
					m_loanPerEmployee = value;
				}
			}
		}

		public long TotalLoan {
			get => NumberOfEmployees * m_loanPerEmployee;
		}
		#endregion

		public EmployeeGroup(Department department, int numberOfEmployees, int loanPerEmployee) {
			GroupDepartment = department;
			NumberOfEmployees = numberOfEmployees;
			m_loanPerEmployee = loanPerEmployee;
		}

		override
		public string ToString() => GroupDepartment.ToString();

		private void updateMotivation() {
			// TODO: Implement motivation
		}
	}
}
