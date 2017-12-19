using System.Collections.Generic;
using AirlineManager.Business.ExceptionHandling;
using AirlineManager.Data;

namespace AirlineManager.Business {
	public class MainGameController {
		#region Attributes
		static MainGameController m_instance = null;
		Player m_currentPlayer = null;
		Airline m_currentAirline = null;
		#endregion

		#region Properties
		public static MainGameController Instance {
			get {
				if (m_instance == null) {
					m_instance = new MainGameController();
				}

				return m_instance;
			}
		}

		public Player CurrentPlayer {
			get {
				return m_currentPlayer;
			}

			set {
				m_currentPlayer = value;
			}
		}

		public Airline CurrentAirline {
			get {
				return m_currentAirline;
			}

			set {
				m_currentAirline = value;
			}
		}

		public List<Route> OperatedRoutes {
			get {
				List<Route> result = new List<Route>();

                if (m_currentAirline != null) {
                    foreach (Route r in m_currentAirline.RouteNetwork) {
                        if (r.IsAircraftAssigned) {
                            result.Add(r);
                        }
                    }
                }

				return result;
			}
		}

		public List<Route> UnoperatedRoutes {
			get {
				List<Route> result = new List<Route>();

				foreach (Route r in m_currentAirline.RouteNetwork) {
					if (!r.IsAircraftAssigned) {
						result.Add(r);
					}
				}

				return result;
			}
		}
		#endregion

		MainGameController() {
			
		}

		#region UIMethodCalls
		public void CreatePlayer(string playerName) {
			if (playerName.Length == 0) {
				throw new IncorrectInputUIException(null, "There is no name for your player account defined!", "Please choose a name for your account.");
			}
			
			CurrentPlayer = new Player(playerName);
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

		public void SaveGame() {
			SavegameHandler.SaveGame();
		}

		public void LoadGame() {
			SavegameHandler.LoadGame();
		}
		#endregion
	}
}
