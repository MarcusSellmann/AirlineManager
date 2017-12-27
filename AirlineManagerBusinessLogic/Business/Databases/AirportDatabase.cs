using System;
using System.Collections.Generic;
using GeoCoordinatePortable;
using AirlineManager.Data;

namespace AirlineManager.Business.Databases {
	public class AirportDatabase {
		#region Attributes
		static AirportDatabase m_instance = null;
		List<Airport> m_db = new List<Airport>();
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
                return m_db[new Random().Next(0, m_db.Count - 1)];
			}
		}

		public List<Airport> DB {
			get {
				return m_db;
			}
		}
		#endregion

		AirportDatabase() {
			// TODO: Extend database by reading from file.
			ICAOCode iEDDT = new ICAOCode("EDDT");
			ICAOCode iEDDF = new ICAOCode("EDDF");
			ICAOCode iKJFK = new ICAOCode("KJFK");
			ICAOCode iKLAX = new ICAOCode("KLAX");
			ICAOCode iKATL = new ICAOCode("KATL");

			GeoCoordinate gcEDDT = new GeoCoordinate(52.559686, 13.287711);
			GeoCoordinate gcEDDF = new GeoCoordinate(50.033333, 8.570556);
			GeoCoordinate gcKJFK = new GeoCoordinate(40.63975, -73.778925);
			GeoCoordinate gcKLAX = new GeoCoordinate(33.942536, -118.408075);
			GeoCoordinate gcKATL = new GeoCoordinate(33.639167, -84.427778);

			Airport aEDDT = new Airport(iEDDT, "TXL", "Berlin-Tegel", "Berlin", 3023, gcEDDT);
			Airport aEDDF = new Airport(iEDDF, "FRA", "Frankfurt am Main", "Frankfurt am Main", 4000, gcEDDF);
			Airport aKJFK = new Airport(iKJFK, "JFK", "John F. Kennedy International Airport", "New York", 4423, gcKJFK);
			Airport aKLAX = new Airport(iKLAX, "LAX", "Los Angeles International Airport", "Los Angeles", 3685, gcKLAX);
			Airport aKATL = new Airport(iKATL, "ATL", "Hartsfield–Jackson Atlanta International Airport", "Atlanta", 3624, gcKATL);

            m_db.Add(aEDDT);
			m_db.Add(aEDDF);
			m_db.Add(aKJFK);
			m_db.Add(aKLAX);
			m_db.Add(aKATL);
		}
	}
}
