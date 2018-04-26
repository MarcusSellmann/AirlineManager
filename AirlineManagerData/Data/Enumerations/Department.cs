using System;

namespace AirlineManager.Data {
	[Serializable()]
	public enum Department {
        Pilot,
        FlightCrew,
        GroundCrew,
        CheckinCrew,
        CleaningCrew,
        Technicians
    }
}