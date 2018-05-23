using System;
using System.Collections.Generic;
using AirlineManager.Business.ExceptionHandling;
using AirlineManager.Data;
using AirlineManager.Business.Databases;

namespace AirlineManager.Business {
    public static class GlobalConstants {
        public const int USED_AIRCRAFT_MARKET_INITIAL_INSTANCE_AMOUNT = 20;
        public const int USED_AIRCRAFT_MARKET_UPDATE_INTERVAL_MINUTES = 1;
        public const int USED_AIRCRAFT_MARKET_START_YEAR_FOR_INITIAL_OPERATION = 1970;
        public const int USED_AIRCRAFT_MARKET_MAXIMUM_DISTANCE_FLOWN = 200000;
    }

    [Serializable()]
    public class MainGameController {
        #region Attributes
        static MainGameController m_instance = null;
        #endregion

        #region Properties
        public static MainGameController Instance {
            get {
                if (m_instance == null) {
                    m_instance = new MainGameController();
                }

                return m_instance;
            }

            set {
                m_instance = value;
            }
        }

        public Player CurrentPlayer { get; set; }

        public Airline CurrentAirline { get; set; }

        public List<Route> OperatedRoutes {
            get {
                return CurrentAirline.FlightSchedule.RoutesForScheduledFlights;
            }
        }

        public List<Route> UnoperatedRoutes {
            get {
                List<Route> result = new List<Route>();
                result.AddRange(CurrentAirline.RouteNetwork);

                foreach (Route r in OperatedRoutes) {
                    if (result.Contains(r)) {
                        result.Remove(r);
                    }
                }

                return result;
            }
        }

        public List<Airport> UnlicensedAirports {
            get {
                List<Airport> ua = new List<Airport>();
                List<Airport> aDB = AirportDatabase.Instance.DB;
                List<Airport> la = CurrentAirline.LicensedAirports;

                foreach (Airport a in aDB) {
                    if (!la.Contains(a)) {
                        ua.Add(a);
                    }
                }

                return ua;
            }
        }
        #endregion

        MainGameController() {
        }

        #region UI method calls
        public void CreatePlayer(string playerName) {
            if (playerName.Length == 0) {
                throw new IncorrectInputUIException(null, "There is no name for your player account defined!", "Please choose a name for your account.");
            }

            CurrentPlayer = new Player(playerName);
        }

        public bool IsPlayerExisting() {
            return CurrentPlayer != null;
        }

        public void CreateAirline(string name, string airlineCode) {
            if (CurrentPlayer == null) {
                throw new IncorrectInputUIException(null, "There is currently no player defined!", "Define a player first.");
            }

            if (name.Length == 0) {
                throw new IncorrectInputUIException(null, "There is no name for your airline defined!", "Please choose a name for your airline.");
            }

            if (airlineCode.Length == 0) {
                throw new IncorrectInputUIException(null, "There is no code for your airline defined!", "Please choose a code for your airline.");
            }

            CurrentAirline = new Airline(CurrentPlayer, name, airlineCode, new List<AircraftInstance>(), new List<EmployeeGroup>());
        }

        public bool IsAirlineExisting() {
            return CurrentAirline != null;
        }

        public bool IsRouteExisting(string routeNumber) {
            foreach (Route r in CurrentAirline.RouteNetwork) {
                if (r.RouteNumber.Equals(routeNumber)) {
                    return true;
                }
            }

            return false;
        }

        public bool BuyAircraft(UsedAircraftInstanceContainer ai) {
            if (ai.AvailableTill > DateTime.Now && CurrentAirline.BuyAircraft(ai.Aircraft)) {
                AircraftInstanceDatabase.Instance.UsedAircrafts.Remove(ai);
                return true;
            }

            return false;
        }

        #region Savegame handler
        public void SaveGame() {
            SavegameHandler.SaveGame(this);
        }

        public void LoadGame() {
            SavegameHandler.LoadGame();
        }
        #endregion
        #endregion
    }
}
