using System;
using System.Timers;
using AirlineManager.Data;
using Simplex;

namespace AirlineManager.Business {
	public class FuelPrize {
		public DateTime Calculated { get; set; }
		public double Prize { get; set; }

		public FuelPrize(DateTime calculated, double prize) {
			Calculated = calculated;
			Prize = prize;
		}

		override
		public string ToString() {
			return Calculated.ToString() + ": " + Prize;
		}
	}
	public class RandomCostsCalculator {
		#region Constants
		private const int FUEL_COST_RECALC_INTERVAL_MINUTE = 5;
		private const int MAX_FUEL_COST_FORECAST_VALUES = 2000;
		#endregion

		#region Attributes
		static RandomCostsCalculator m_instance = null;
		Timer m_fuelCostRecalcTimer = null;
		FuelPrize[] m_fuelCosts = new FuelPrize[MAX_FUEL_COST_FORECAST_VALUES];
		int m_currentFuelCostForecastIndex = 0;
		#endregion

		#region Properties
		public static RandomCostsCalculator Instance {
			get {
				if (m_instance == null) {
					m_instance = new RandomCostsCalculator();
				}

				return m_instance;
			}
		}

		public FuelPrize CurrentFuelPrize {
			get {
				return m_fuelCosts[m_currentFuelCostForecastIndex];
			}
		}

		/// <summary>
		/// The fuel prizes for the last ten calculations.
		/// </summary>
		public FuelPrize[] FuelPrizeEvolution {
			get {
				FuelPrize[] fp = new FuelPrize[10];

				if (m_currentFuelCostForecastIndex < fp.Length) {
					var currIndex = 0;
					var currFuelCostIndex = MAX_FUEL_COST_FORECAST_VALUES - fp.Length;

					do {
						fp[currIndex] = m_fuelCosts[currFuelCostIndex];
						
						currIndex++;
						currFuelCostIndex++;

						if (currFuelCostIndex == MAX_FUEL_COST_FORECAST_VALUES) {
							currFuelCostIndex = 0;
                        }
					} while (currFuelCostIndex != m_currentFuelCostForecastIndex);
				} else {
					for (int i = m_currentFuelCostForecastIndex - 10; i <= m_currentFuelCostForecastIndex; ++i) {
						fp[i] = m_fuelCosts[i];
					}
				}

                return fp;
			}
		}

		/// <summary>
		/// All created fuel prizes.
		/// </summary>
		public FuelPrize[] FuelPrizeFullRange {
			get {
				FuelPrize[] prizes = new FuelPrize[m_fuelCosts.Length];

				for(int i = 0; i < m_fuelCosts.Length; ++i) {
					m_fuelCosts[i].Calculated = DateTime.Now + TimeSpan.FromMinutes(i * FUEL_COST_RECALC_INTERVAL_MINUTE);
				}

				return m_fuelCosts;
			}
		}
		#endregion

		RandomCostsCalculator() {
			InitFuelCosts();

			m_fuelCostRecalcTimer = new Timer(FUEL_COST_RECALC_INTERVAL_MINUTE * 60000);
			m_fuelCostRecalcTimer.AutoReset = true;
			m_fuelCostRecalcTimer.Elapsed += OnFuelUpdateEvent;
			m_fuelCostRecalcTimer.Start();
		}

		public long CalculateFerryFlightCosts(Airport origin, Airport destination, AircraftInstance aircraft) {
			int distance = 0;
			long costs = 0;

			// TODO: Make up a nice algo to calculate the ferry flight costs.

			return costs;
		}

		private void InitFuelCosts() {
			float[] fc = Noise.Calc1D(m_fuelCosts.Length, 0.05f);
			
			for (int i = 0; i < m_fuelCosts.Length; ++i) {
				if (i > 0) {
					m_fuelCosts[i] = new FuelPrize(DateTime.Now + TimeSpan.FromMinutes(FUEL_COST_RECALC_INTERVAL_MINUTE), fc[i]);
                } else {
					m_fuelCosts[i] = new FuelPrize(DateTime.Now, fc[i]);
				}
			}
		}
		
		#region Timer methods
		private void OnFuelUpdateEvent(object source, ElapsedEventArgs e) {
			Console.WriteLine("Fuel cost recalculation initiated.");
			
			m_currentFuelCostForecastIndex++;

			if (m_currentFuelCostForecastIndex >= MAX_FUEL_COST_FORECAST_VALUES) {
				m_currentFuelCostForecastIndex = 0;
			}

			Console.WriteLine("New fuel prize: {0}", CurrentFuelPrize);
		}
		#endregion
	}
}
