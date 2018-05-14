using AirlineManager.Business;
using AirlineManager.Business.Databases;
using AirlineManager.UI.Control;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Windows.Controls;

namespace AirlineManager.UI.Pages {
	/// <summary>
	/// Interaction logic for DashboardPage.xaml
	/// </summary>
	public partial class DashboardPage : Page {
		DashboardGraphUserControl m_fuelCostsUc = null;
		DashboardInfoTileUserControl m_amountMoneyUc = null;
		DashboardInfoTileUserControl m_reputationUc = null;
		DashboardInfoTileUserControl m_numberOfAircraftsUc = null;
		DashboardInfoTileUserControl m_numberOfRoutesUc = null;
		DashboardInfoTileUserControl m_numberOfUsedAircraftsUc = null;
        DashboardInfoTileUserControl m_numberOfScheduledFlightsUc = null;

        public DashboardPage() {
			InitializeComponent();

			DateTimePoint[] fuelPrizes = Convert(RandomCostsCalculator.Instance.FuelPrizeEvolution);

			m_fuelCostsUc = FuelCostsUc;
			m_fuelCostsUc.DiagrammTitle = "Fuel prize";
			m_fuelCostsUc.FormatterXAxis = value => new DateTime((long)value).ToString("dd.MM.yyyy HH:mm");
			m_fuelCostsUc.ShowLegend = false;
			m_fuelCostsUc.Collection = new SeriesCollection {
                new LineSeries {
					Values = new ChartValues<DateTimePoint>(fuelPrizes)
				}
			};

            var currAl = MainGameController.Instance.CurrentAirline;

			m_amountMoneyUc = AmountMoneyUc;
			m_amountMoneyUc.Title = "Money";
			m_amountMoneyUc.Value = currAl.Money.ToString("C");

			m_reputationUc = ReputationUc;
			m_reputationUc.Title = "Reputation";
			m_reputationUc.Value = currAl.Reputation.ToString();

			m_numberOfAircraftsUc = NumberOfAircraftsUc;
			m_numberOfAircraftsUc.Title = "Planes";
			m_numberOfAircraftsUc.Value = currAl.OwnedAircrafts.Count.ToString();

			m_numberOfRoutesUc = NumberOfRoutesUc;
			m_numberOfRoutesUc.Title = "Routes";
			m_numberOfRoutesUc.Value = currAl.RouteNetwork.Count.ToString();

			m_numberOfUsedAircraftsUc = NumberOfUsedAircraftsUc;
			m_numberOfUsedAircraftsUc.Title = "Used aircrafts";
			m_numberOfUsedAircraftsUc.Value = AircraftInstanceDatabase.Instance.NumberOfUsedAircraftsAvailable.ToString();

            m_numberOfScheduledFlightsUc = NumberOfScheduledFlightsUc;
            m_numberOfScheduledFlightsUc.Title = "Scheduled flights";
            m_numberOfScheduledFlightsUc.Value = currAl.FlightSchedule.ScheduledFlights.Count.ToString();
        }

		private DateTimePoint Convert(FuelPrize fp) {
			return new DateTimePoint(fp.Calculated, fp.Prize);
		}

		private DateTimePoint[] Convert(FuelPrize[] fp) {
			DateTimePoint[] dtp = new DateTimePoint[fp.Length];

			for (int i = 0; i < fp.Length; ++i) {
				dtp[i] = Convert(fp[i]);
			}

			return dtp;
		}
	}
}
