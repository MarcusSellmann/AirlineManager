using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using AirlineManager.Business.Databases;
using AirlineManager.Data;
using AirlineManager.UI.Interfaces;

namespace AirlineManager.UI.Pages.Subpages {
    /// <summary>
    /// Interaktionslogik für AircraftInstanceFilterPage.xaml
    /// </summary>
    public partial class AircraftInstanceFilterPage : Page {
        #region Attributes
        public IFilterUpdatedListener UpdatedListener { get; private set; }
        private ObservableCollection<Aircraft> m_aircrafts = new ObservableCollection<Aircraft>();
        #endregion

        #region Properties
        public int AvailableRunwayLength { get; private set; }
        public int FlownDistanceLowerValue { get; private set; }
        public int FlownDistanceUpperValue { get; private set; }
        public int AgeLowerValue { get; private set; }
        public int AgeUpperValue { get; private set; }
        public Aircraft Type { get; private set; }
        #endregion

        public AircraftInstanceFilterPage(IFilterUpdatedListener listener) {
            UpdatedListener = listener;
            InitializeComponent();

            List<Aircraft> acs = AircraftDatabase.Instance.DB;

            foreach (Aircraft ac in acs) {
                m_aircrafts.Add(ac);
            }

            cbAircraftType.ItemsSource = m_aircrafts;
        }

        #region UI actions
        private void btnApplyFilter_Click(object sender, System.Windows.RoutedEventArgs e) {
            UpdatedListener.FilterUpdated();
        }

        private void slAvailableRunwayLength_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e) {
            AvailableRunwayLength = (int)e.NewValue;
        }

        private void slFlownDistance_LowerValueChanged(object sender, MahApps.Metro.Controls.RangeParameterChangedEventArgs e) {
            FlownDistanceLowerValue = (int)e.NewValue;
        }

        private void slFlownDistance_UpperValueChanged(object sender, MahApps.Metro.Controls.RangeParameterChangedEventArgs e) {
            FlownDistanceUpperValue = (int)e.NewValue;
        }

        private void slFlownDistance_RangeSelectionChanged(object sender, MahApps.Metro.Controls.RangeSelectionChangedEventArgs e) {
            FlownDistanceLowerValue = (int)e.NewLowerValue;
            FlownDistanceUpperValue = (int)e.NewUpperValue;
        }

        private void slAge_LowerValueChanged(object sender, MahApps.Metro.Controls.RangeParameterChangedEventArgs e) {
            AgeLowerValue = (int)e.NewValue;
        }

        private void slAge_UpperValueChanged(object sender, MahApps.Metro.Controls.RangeParameterChangedEventArgs e) {
            AgeUpperValue = (int)e.NewValue;
        }

        private void slAge_RangeSelectionChanged(object sender, MahApps.Metro.Controls.RangeSelectionChangedEventArgs e) {
            AgeLowerValue = (int)e.NewLowerValue;
            AgeUpperValue = (int)e.NewUpperValue;
        }

        private void cbAircraftType_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            Type = e.AddedItems as Aircraft;
        }
        #endregion
    }
}
