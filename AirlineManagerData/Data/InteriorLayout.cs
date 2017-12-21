using System.Collections.Generic;

namespace AirlineManager.Data {
	public class InteriorLayout : IAircraftInteriorLayout {
		#region Attributes
		Dictionary<ClassType, int> m_classLayout = new Dictionary<ClassType, int>();
		#endregion

		#region Properties
		public Dictionary<ClassType, int> ClassLayout {
			get {
				return m_classLayout;
			}
		}
		#endregion

		public InteriorLayout() {
			m_classLayout[ClassType.Economy] = 0;
			m_classLayout[ClassType.Business] = 0;
			m_classLayout[ClassType.First] = 0;
			m_classLayout[ClassType.Cargo] = 0;
		}

		public InteriorLayout(int economy, int business, int first, int cargo) {
			m_classLayout[ClassType.Economy] = economy;
			m_classLayout[ClassType.Business] = business;
			m_classLayout[ClassType.First] = first;
			m_classLayout[ClassType.Cargo] = cargo;
		}

		public bool HasCargo() {
			return m_classLayout[ClassType.Cargo] > 0;
		}

		public bool HasPax() {
			return m_classLayout[ClassType.Economy] > 0 || 
				   m_classLayout[ClassType.Business] > 0 || 
				   m_classLayout[ClassType.First] > 0;
		}

		public bool IsCargoOnly() {
			return m_classLayout[ClassType.Economy] == 0 && 
				   m_classLayout[ClassType.Business] == 0 && 
				   m_classLayout[ClassType.First] == 0 &&
				   m_classLayout[ClassType.First] > 0;
		}

		public int PaxInClass(ClassType classType) {
			return m_classLayout[classType];
        }

		public int SumTotalPax() {
			int total = 0;

			total += m_classLayout[ClassType.Economy];
			total += m_classLayout[ClassType.Business];
			total += m_classLayout[ClassType.First];

			return total;
		}

		override
		public string ToString() {
			return ClassLayout[ClassType.Economy] + " | " + ClassLayout[ClassType.Business] + " | " + ClassLayout[ClassType.First] + " | " + ClassLayout[ClassType.Cargo];
		}
	}
}
