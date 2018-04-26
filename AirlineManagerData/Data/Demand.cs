using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AirlineManager.Data {
	[DataContract]
	public class Demand : IAircraftInteriorLayout {
        #region Attributes
        #endregion

        #region Properties
        [DataMember]
        public Dictionary<ClassType, int> DemandPerClass { get; private set; }
        #endregion

        public Demand() : this(0,0,0,0) {}

		public Demand(int economy, int business, int first, int cargo) {
            DemandPerClass = new Dictionary<ClassType, int>();
			DemandPerClass[ClassType.Economy] = economy;
			DemandPerClass[ClassType.Business] = business;
			DemandPerClass[ClassType.First] = first;
			DemandPerClass[ClassType.Cargo] = cargo;
		}

		public int PaxInClass(ClassType classType) {
			return DemandPerClass[classType];
		}

		public int SumTotalPax() {
			int total = 0;

			total += DemandPerClass[ClassType.Economy];
			total += DemandPerClass[ClassType.Business];
			total += DemandPerClass[ClassType.First];

			return total;
		}

		public bool HasPax() {
			return DemandPerClass[ClassType.Economy] > 0 ||
				   DemandPerClass[ClassType.Business] > 0 ||
				   DemandPerClass[ClassType.First] > 0;
		}

		public bool HasCargo() {
			return DemandPerClass[ClassType.Cargo] > 0;
		}

		public bool IsCargoOnly() {
			return DemandPerClass[ClassType.Economy] == 0 &&
				   DemandPerClass[ClassType.Business] == 0 &&
				   DemandPerClass[ClassType.First] == 0 &&
				   DemandPerClass[ClassType.Cargo] > 0;
		}

		override
		public string ToString() {
            return DemandPerClass[ClassType.Economy] + " | " + DemandPerClass[ClassType.Business] + " | " + DemandPerClass[ClassType.First] + " | " + DemandPerClass[ClassType.Cargo];
		}
	}
}
