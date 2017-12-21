using System;
using System.Collections.Generic;

namespace AirlineManager.Data {
	public class Demand : IAircraftInteriorLayout {
		#region Attributes
		Dictionary<ClassType, int> m_demandPerClass = new Dictionary<ClassType, int>();
		#endregion

		#region Properties
		public Dictionary<ClassType, int> DemandPerClass {
			get {
				return m_demandPerClass;
			}
		}
		#endregion

		public Demand() {
			m_demandPerClass[ClassType.Economy] = 0;
			m_demandPerClass[ClassType.Business] = 0;
			m_demandPerClass[ClassType.First] = 0;
			m_demandPerClass[ClassType.Cargo] = 0;
		}

		public Demand(int economy, int business, int first, int cargo) {
			m_demandPerClass[ClassType.Economy] = economy;
			m_demandPerClass[ClassType.Business] = business;
			m_demandPerClass[ClassType.First] = first;
			m_demandPerClass[ClassType.Cargo] = cargo;
		}

		public int PaxInClass(ClassType classType) {
			return m_demandPerClass[classType];
		}

		public int SumTotalPax() {
			int total = 0;

			total += m_demandPerClass[ClassType.Economy];
			total += m_demandPerClass[ClassType.Business];
			total += m_demandPerClass[ClassType.First];

			return total;
		}

		public bool HasPax() {
			return m_demandPerClass[ClassType.Economy] > 0 ||
				   m_demandPerClass[ClassType.Business] > 0 ||
				   m_demandPerClass[ClassType.First] > 0;
		}

		public bool HasCargo() {
			return m_demandPerClass[ClassType.Cargo] > 0;
		}

		public bool IsCargoOnly() {
			return m_demandPerClass[ClassType.Economy] == 0 &&
				   m_demandPerClass[ClassType.Business] == 0 &&
				   m_demandPerClass[ClassType.First] == 0 &&
				   m_demandPerClass[ClassType.First] > 0;
		}

		override
		public string ToString() {
            return DemandPerClass[ClassType.Economy] + " | " + DemandPerClass[ClassType.Business] + " | " + DemandPerClass[ClassType.First] + " | " + DemandPerClass[ClassType.Cargo];
		}
	}
}
