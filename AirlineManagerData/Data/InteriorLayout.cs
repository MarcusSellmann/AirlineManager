using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AirlineManager.Data {
	[DataContract]
	public class InteriorLayout : IAircraftInteriorLayout, IComparable {
        #region Attributes
        #endregion

        #region Properties
        [DataMember]
        public Dictionary<ClassType, int> ClassLayout { get; private set; }
		#endregion

		public InteriorLayout() : this(0, 0, 0, 0) {}

		public InteriorLayout(int economy, int business, int first, int cargo) {
            ClassLayout = new Dictionary<ClassType, int> {
                [ClassType.Economy] = economy,
                [ClassType.Business] = business,
                [ClassType.First] = first,
                [ClassType.Cargo] = cargo
            };
        }

        public bool HasCargo() => ClassLayout[ClassType.Cargo] > 0;

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

		public int PaxInClass(ClassType classType) => ClassLayout[classType];

		public int SumTotalPax() {
			int total = 0;

			total += ClassLayout[ClassType.Economy];
			total += ClassLayout[ClassType.Business];
			total += ClassLayout[ClassType.First];

			return total;
		}

		override
		public string ToString() => ClassLayout[ClassType.Economy] + " | " + ClassLayout[ClassType.Business] + " | " + ClassLayout[ClassType.First] + " | " + ClassLayout[ClassType.Cargo];

        public int CompareTo(object obj) {
            int[] results = new int[4];

            if (obj is InteriorLayout) {
                results[0] = ClassLayout[ClassType.Economy].CompareTo((obj as InteriorLayout).ClassLayout[ClassType.Economy]);
                results[1] = ClassLayout[ClassType.Business].CompareTo((obj as InteriorLayout).ClassLayout[ClassType.Business]);
                results[2] = ClassLayout[ClassType.First].CompareTo((obj as InteriorLayout).ClassLayout[ClassType.First]);
                results[3] = ClassLayout[ClassType.Cargo].CompareTo((obj as InteriorLayout).ClassLayout[ClassType.Cargo]);

                if (results[0] != 0) {
                    return results[0];
                } else {
                    if (results[1] != 0) {
                        return results[1];
                    } else {
                        if (results[2] != 0) {
                            return results[2];
                        } else {
                            return results[3];
                        }
                    }
                }
            }

            return -1;
        }
    }
}
