using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Media.Imaging;

namespace AirlineManager.Data {
	[DataContract]
	public class Aircraft : IComparable {
		#region Attributes
        #endregion

        #region Properties
        [DataMember]
		public AircraftManufacturer Manufacturer { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public float Length { get; private set; }

        [DataMember]
        public float Width { get; private set; }

        [DataMember]
        public float Height { get; private set; }

        [DataMember]
        public float FuelUsagePerMinute { get; private set; }

        [DataMember]
        public string ImageName { get; private set; }

        [DataMember]
        public long OriginalPrize { get; private set; }

        [DataMember]
        public int TravelVelocity { get; private set; }

        [DataMember]
        public int Range { get; private set; }

        [DataMember]
        public long TurnoverTime { get; private set; }

        [DataMember]
        public int MinimalNeededRunwayLength { get; private set; }

        [DataMember]
        public Staff NeededStaff { get; private set; }

        [DataMember]
        public List<Engine> AvailableEngines { get; private set; }

        [DataMember]
        public int NumberOfEngines { get; private set; }

        [DataMember]
        public int MaxNumberOfEconomySeats { get; private set; }

        public BitmapImage Image {
            get => new BitmapImage(new Uri(@"pack://application:,,,/AirlineManager;component/res/ac/" + ImageName));
        }
        #endregion

        public Aircraft(AircraftManufacturer manufacturer, string name, float length, float width, 
						float height, float fuelUsagePerMinute, string image, 
                        long originalPrize, int travelVelocity, int range, 
                        long turnoverTime, int minimalNeededRunwayLength, Staff neededStaff,
                        List<Engine> availableEngines, int numberOfEngines, int maxEconomySeating) {
			Manufacturer = manufacturer;
			Name = name;
            Length = length;
            Width = width;
            Height = height;
            FuelUsagePerMinute = fuelUsagePerMinute;
            ImageName = image;
            OriginalPrize = originalPrize;
            TravelVelocity = travelVelocity;
            Range = range;
            TurnoverTime = turnoverTime;
			MinimalNeededRunwayLength = minimalNeededRunwayLength;
			NeededStaff = neededStaff;
            NumberOfEngines = numberOfEngines;
            MaxNumberOfEconomySeats = maxEconomySeating;

            AvailableEngines = new List<Engine>();

            if (availableEngines != null) {
                AvailableEngines.AddRange(availableEngines);
            }
        }

		override
		public string ToString() {
			return Manufacturer.ToString() + " " + Name;
		}

        public int CompareTo(object obj) {
            return ToString().CompareTo(obj.ToString());
        }
    }
}