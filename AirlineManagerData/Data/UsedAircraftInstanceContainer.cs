using System;
using System.Runtime.Serialization;

namespace AirlineManager.Data {
    [DataContract]
	public class UsedAircraftInstanceContainer {
        #region Properties
        [DataMember]
        public AircraftInstance Aircraft { get; set; }

        [DataMember]
        public DateTime AvailableTill { get; set; }
		#endregion

		public UsedAircraftInstanceContainer(AircraftInstance aircraft, DateTime availableTill) {
			Aircraft = aircraft;
			AvailableTill = availableTill;
		}
	}
}
