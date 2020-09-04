using AirlineManager.Business;
using AirlineManager.Business.Utilities;
using AirlineManager.Data;
using AirlineManager.UI.Interfaces;
using AirlineManager.UI.Pages.Subpages;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media.Animation;

namespace AirlineManager.UI.Pages {
    /// <summary>
    /// Interaction logic for AircraftInstancePage.xaml
    /// </summary>
    public partial class AircraftInstancePage : Page, IFilterUpdatedListener {
        #region Attributes
        private ObservableCollection<AircraftInstance> m_aircraftInstances = new ObservableCollection<AircraftInstance>();
        private AircraftInstanceFilterPage m_aircraftInstanceFilterPage = null;
        private GridViewColumnHeader m_lastHeaderClicked = null;
        private ListSortDirection m_lastDirection = ListSortDirection.Ascending;
        #endregion

        #region Properties
        private GridViewColumnHeader LastHeaderClicked {
            get => m_lastHeaderClicked;
            set {
                if (m_lastHeaderClicked == value) {
                    if (m_lastDirection == ListSortDirection.Ascending) {
                        m_lastDirection = ListSortDirection.Descending;
                    } else {
                        m_lastDirection = ListSortDirection.Ascending;
                    }
                }

                m_lastHeaderClicked = value;
            }
        }
        #endregion

        public AircraftInstancePage() {
            MainGameController mGc = MainGameController.Instance;
            List<AircraftInstance> aircraftInstances = mGc.CurrentAirline.OwnedAircrafts;

            foreach (AircraftInstance ai in aircraftInstances) {
                m_aircraftInstances.Add(ai);
            }

            InitializeComponent();

            lvAircraftInstances.ItemsSource = m_aircraftInstances;
            AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(LvAircraftInstances_OnColumnClick));

            m_aircraftInstanceFilterPage = new AircraftInstanceFilterPage(this);
            _filterSidebarFrame.Navigate(m_aircraftInstanceFilterPage);

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvAircraftInstances.ItemsSource);
            view.Filter = AircraftInstanceFilter;
        }

        public void FilterUpdated() {
            CollectionViewSource.GetDefaultView(lvAircraftInstances.ItemsSource).Refresh();
        }

        private void LvAircraftInstances_OnColumnClick(object sender, RoutedEventArgs e) {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction;

            if (headerClicked != null) {
                if (headerClicked.Content.ToString() != "Image") {
                    if (headerClicked.Role != GridViewColumnHeaderRole.Padding) {
                        if (headerClicked != m_lastHeaderClicked) {
                            direction = ListSortDirection.Ascending;
                        } else {
                            if (m_lastDirection == ListSortDirection.Ascending) {
                                direction = ListSortDirection.Descending;
                            } else {
                                direction = ListSortDirection.Ascending;
                            }
                        }

                        var columnBinding = headerClicked.Column.DisplayMemberBinding as Binding;
                        var sortBy = columnBinding?.Path.Path ?? headerClicked.Column.Header as string;

                        Sort(sortBy, direction);

                        if (direction == ListSortDirection.Ascending) {
                            headerClicked.Column.HeaderTemplate =
                              Resources["HeaderTemplateArrowUp"] as DataTemplate;
                        } else {
                            headerClicked.Column.HeaderTemplate =
                              Resources["HeaderTemplateArrowDown"] as DataTemplate;
                        }

                        // Remove arrow from previously sorted header
                        if (m_lastHeaderClicked != null && m_lastHeaderClicked != headerClicked) {
                            m_lastHeaderClicked.Column.HeaderTemplate = null;
                        }

                        m_lastHeaderClicked = headerClicked;
                        m_lastDirection = direction;
                    }
                }
            }
        }

        private void Sort(string sortBy, ListSortDirection direction) {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(lvAircraftInstances.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }

        private void btnAddNewAircraftInstance_Click(object sender, RoutedEventArgs e) {
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
            double aiAge = AircraftAgeHelper.AircraftAgeInYears(ai.InitialOperation, MainGameController.Instance.GameClock.CurrentGameTime);

            if (ai.Type.MinimalNeededRunwayLength <= m_aircraftInstanceFilterPage.AvailableRunwayLength &&
                ai.HoursFlown >= m_aircraftInstanceFilterPage.FlownHoursLowerValue &&
                ai.HoursFlown <= m_aircraftInstanceFilterPage.FlownHoursUpperValue &&
                aiAge >= m_aircraftInstanceFilterPage.AgeLowerValue &&
                aiAge <= m_aircraftInstanceFilterPage.AgeUpperValue) {
                if (m_aircraftInstanceFilterPage.Type == null ||
                    ai.Type == m_aircraftInstanceFilterPage.Type) {
                    return true;
                }
            }

            return false;
        }
    }
}
