using System.Runtime.Serialization;

namespace AirlineManager.Data {
    [DataContract]
    public class TicketPrizes {
        #region Properties
        [DataMember]
        public long Economy { get; set; }

        [DataMember]
        public long Business { get; set; }

        [DataMember]
        public long First { get; set; }

        [DataMember]
        public long Cargo { get; set; }
        #endregion

        public TicketPrizes(long economy = 0, long business = 0, long first = 0, long cargo = 0) {
            Economy = economy;
            Business = business;
            First = first;
            Cargo = cargo;
        }

        override
        public string ToString() {
            return Economy + " | " + Business + " | " + First + " | " + Cargo;
        }
    }
}
