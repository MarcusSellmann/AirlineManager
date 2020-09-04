using System;
using System.Runtime.Serialization;
using AirlineManager.Data.Enumerations;

namespace AirlineManager.Data {
	[DataContract]
	public class Engine : IComparable {
        #region Attributes
        #endregion

        #region Properties
        [DataMember]
        public EngineManufacturer Manufacturer { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public float Thrust { get; private set; }
        #endregion

        public Engine(EngineManufacturer manufacturer, string name, float thrust) {
            Manufacturer = manufacturer;
            Name = name;
            Thrust = thrust;
        }

        override
        public string ToString() => Manufacturer + " " + Name;

        public int CompareTo(object obj) {
            return ToString().CompareTo(obj.ToString());
        }
    }
}
