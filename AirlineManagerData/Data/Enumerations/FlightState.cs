using System;

namespace AirlineManager.Data {
	[Serializable()]
	public enum FlightState {
        Scheduled,
        Boarding,
        InFlight,
        Landed
    }
}