using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AirlineManager.Data {
	[DataContract]
	public class InteriorLayout : IAircraftInteriorLayout {
        #region Attributes
        #endregion

        #region Properties
        [DataMember]
        public Dictionary<ClassType, int> ClassLayout { get; private set; }
		#endregion

		public InteriorLayout() : this(0, 0, 0, 0) {}

		public InteriorLayout(int economy, int business, int first, int cargo) {
            ClassLayout = new Dictionary<ClassType, int>();
			ClassLayout[ClassType.Economy] = economy;
			ClassLayout[ClassType.Business] = business;
			ClassLayout[ClassType.First] = first;
			ClassLayout[ClassType.Cargo] = cargo;
		}

		public bool HasCargo() {
			return ClassLayout[ClassType.Cargo] > 0;
		}

		public bool HasPax() {
			return ClassLayout[ClassType.Economy] > 0 || 
				   ClassLayout[ClassType.Business] > 0 || 
				   ClassLayout[ClassType.First] > 0;
		}

		public bool IsCargoOnly() {
			return ClassLayout[ClassType.Economy] == 0 && 
				   ClassLayout[ClassType.Business] == 0 && 
				   ClassLayout[ClassType.First] == 0 &&
				   ClassLayout[ClassType.First] > 0;
		}

		public int PaxInClass(ClassType classType) {
			return ClassLayout[classType];
        }

		public int SumTotalPax() {
			int total = 0;

			total += ClassLayout[ClassType.Economy];
			total += ClassLayout[ClassType.Business];
			total += ClassLayout[ClassType.First];

			return total;
		}

		override
		public string ToString() {
			return ClassLayout[ClassType.Economy] + " | " + ClassLayout[ClassType.Business] + " | " + ClassLayout[ClassType.First] + " | " + ClassLayout[ClassType.Cargo];
		}
	}
}
