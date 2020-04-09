using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Animation;
using AirlineManager.Business;
using AirlineManager.Data;
using AirlineManager.UI.Pages.Subpages;
using AirlineManager.UI.Interfaces;

namespace AirlineManager.UI.Pages
{
    /// <summary>
    /// Interaction logic for AircraftInstancePage.xaml
    /// </summary>
    public partial class AircraftInstancePage : Page, IFilterUpdatedListener
    {
        private ObservableCollection<AircraftInstance> m_aircraftInstances = new ObservableCollection<AircraftInstance>();
        private AircraftInstanceFilterPage m_aircraftInstanceFilterPage = null;

        public AircraftInstancePage()
        {
            MainGameController mGc = MainGameController.Instance;
            List<AircraftInstance> aircraftInstances = mGc.CurrentAirline.OwnedAircrafts;

            foreach (AircraftInstance ai in aircraftInstances)
            {
                m_aircraftInstances.Add(ai);
            }
            
            InitializeComponent();
            
            lvAircraftInstances.ItemsSource = m_aircraftInstances;
            m_aircraftInstanceFilterPage = new AircraftInstanceFilterPage(this);
            _filterSidebarFrame.Navigate(m_aircraftInstanceFilterPage);

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvAircraftInstances.ItemsSource);
            view.Filter = AircraftInstanceFilter;
        }

        public void FilterUpdated() {
            CollectionViewSource.GetDefaultView(lvAircraftInstances.ItemsSource).Refresh();
        }

        private void btnAddNewAircraftInstance_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new AircraftMarketPage());
        }

        #region Filter sidebar
        private void btnFilterMenuHide_Click(object sender, System.Windows.RoutedEventArgs e) {
            ShowHideMenu("sbHideFilterMenu", btnFilterMenuHide, btnFilterMenuShow, pnlFilterMenu);
        }

        private void btnFilterMenuShow_Click(object sender, System.Windows.RoutedEventArgs e) {
            ShowHideMenu("sbShowFilterMenu", btnFilterMenuHide, btnFilterMenuShow, pnlFilterMenu);
        }

        private void ShowHideMenu(string Storyboard, Button btnHide, Button btnShow, StackPanel pnl) {
            Storyboard sb = Resources[Storyboard] as Storyboard;
            sb.Begin(pnl);

            if (Storyboard.Contains("Show")) {
                btnHide.Visibility = System.Windows.Visibility.Visible;
                btnShow.Visibility = System.Windows.Visibility.Hidden;
            } else if (Storyboard.Contains("Hide")) {
                btnHide.Visibility = System.Windows.Visibility.Hidden;
                btnShow.Visibility = System.Windows.Visibility.Visible;
            }
        }
        #endregion

        private bool AircraftInstanceFilter(object item) {
            AircraftInstance ai = item as AircraftInstance;

            if (ai.Type.MinimalNeededRunwayLength <= m_aircraftInstanceFilterPage.AvailableRunwayLength &&
                ai.HoursFlown >= m_aircraftInstanceFilterPage.FlownHoursLowerValue &&
                ai.HoursFlown <= m_aircraftInstanceFilterPage.FlownHoursUpperValue &&
                ai.AgeInYears >= m_aircraftInstanceFilterPage.AgeLowerValue &&
                ai.AgeInYears <= m_aircraftInstanceFilterPage.AgeUpperValue) {
                if (m_aircraftInstanceFilterPage.Type == null ||
                    ai.Type == m_aircraftInstanceFilterPage.Type) {
                    return true;
                }
            }

            return false;
        }
    }
}
