using System;
using System.Collections.Generic;
using GeoCoordinatePortable;
using AirlineManager.Data;

namespace AirlineManager.Business.Databases {
	public class AirportDatabase {
		#region Attributes
		static AirportDatabase m_instance = null;
		#endregion

		#region Properties
		public static AirportDatabase Instance {
			get {
				if (m_instance == null) {
					m_instance = new AirportDatabase();
				}

				return m_instance;
			}
		}

		public Airport Random {
			get {
                return DB[new Random().Next(0, DB.Count - 1)];
			}
		}

		public List<Airport> DB { get; private set; }
		#endregion

		AirportDatabase() {
            DB = new List<Airport>();

            // TODO: Extend database by reading from file.
            DB.Add(new Airport(new ICAOCode("EDDB"), "SXF", "Flughafen Berlin-Schönefeld", "Berlin", 3600, new GeoCoordinate(52.388333, 13.52)));
            DB.Add(new Airport(new ICAOCode("EDDC"), "DRS", "Flughafen Dresden", "Dresden", 2850, new GeoCoordinate(51.134344, 13.768)));
            DB.Add(new Airport(new ICAOCode("EDDE"), "ERF", "Flughafen Erfurt-Weimar", "Erfurt", 2600, new GeoCoordinate(50.979811, 10.958106)));
            DB.Add(new Airport(new ICAOCode("EDDF"), "FRA", "Flughafen Frankfurt am Main", "Frankfurt am Main", 4000, new GeoCoordinate(50.033333, 8.570556)));
            DB.Add(new Airport(new ICAOCode("EDDG"), "FMO", "Münster Osnabrück International Airport", "Münster", 2170, new GeoCoordinate(52.134642, 7.684831)));
            DB.Add(new Airport(new ICAOCode("EDDH"), "HAM", "Flughafen Hamburg", "Hamburg", 3666, new GeoCoordinate(53.630278, 9.988333)));
            DB.Add(new Airport(new ICAOCode("EDDK"), "CGN", "Flughafen Köln/Bonn 'Konrad Adenauer'", "Köln", 3815, new GeoCoordinate(50.865917, 7.142744)));
            DB.Add(new Airport(new ICAOCode("EDDL"), "DUS", "Düsseldorf Airport", "Düsseldorf", 3000, new GeoCoordinate(51.280925, 6.757311)));
            DB.Add(new Airport(new ICAOCode("EDDM"), "MUC", "Flughafen München 'Franz Josef Strauß'", "München", 4000, new GeoCoordinate(48.353783, 11.786086)));
            DB.Add(new Airport(new ICAOCode("EDDN"), "NUE", "Flughafen Nürnberg 'Albrecht Dürer'", "Nürnberg", 2700, new GeoCoordinate(49.4987, 11.078008)));
            DB.Add(new Airport(new ICAOCode("EDDP"), "LEJ", "Leipzig/Halle Airport", "Leipzig", 3600, new GeoCoordinate(51.423992, 12.236356)));
            DB.Add(new Airport(new ICAOCode("EDDR"), "SCN", "Flughafen Saarbrücken", "Saarbrücken", 2000, new GeoCoordinate(49.214553, 7.109508)));
            DB.Add(new Airport(new ICAOCode("EDDS"), "STR", "Flughafen Stuttgart - Manfred Rommel Flughafen", "Stuttgart", 3345, new GeoCoordinate(48.689878, 9.221964)));
            DB.Add(new Airport(new ICAOCode("EDDT"), "TXL", "Flughafen Berlin-Tegel 'Otto Lilienthal'", "Berlin", 3023, new GeoCoordinate(52.559686, 13.287711)));
            DB.Add(new Airport(new ICAOCode("EDDV"), "HAJ", "Flughafen Hannover-Langenhagen", "Hannover", 3200, new GeoCoordinate(52.461056, 9.685078)));
            DB.Add(new Airport(new ICAOCode("EDDW"), "BRE", "Flughafen Bremen", "Bremen", 2040, new GeoCoordinate(53.0475, 8.786667)));
            DB.Add(new Airport(new ICAOCode("KATL"), "ATL", "Hartsfield–Jackson Atlanta International Airport", "Atlanta", 3624, new GeoCoordinate(33.639167, -84.427778)));
            DB.Add(new Airport(new ICAOCode("KJFK"), "JFK", "John F. Kennedy International Airport", "New York City", 4423, new GeoCoordinate(40.63975, -73.778925)));
            DB.Add(new Airport(new ICAOCode("KLAX"), "LAX", "Los Angeles International Airport", "Los Angeles", 3685, new GeoCoordinate(33.942536, -118.408075)));
        }
    }
}
