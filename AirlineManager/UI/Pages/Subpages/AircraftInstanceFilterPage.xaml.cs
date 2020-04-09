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
        public int FlownHoursLowerValue { get; private set; }
        public int FlownHoursUpperValue { get; private set; }
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
        #region Button clicks
        private void BtnApplyFilter_Click(object sender, System.Windows.RoutedEventArgs e) {
            UpdatedListener?.FilterUpdated();
        }

        private void BtnResetFilter_Click(object sender, System.Windows.RoutedEventArgs e) {
            slAvailableRunwayLength.Value = 4000;
            slFlownHours.UpperValue = 500000;
            slFlownHours.LowerValue = 1000;
            slAge.UpperValue = 100;
            slAge.LowerValue = 0;
            cbAircraftType.SelectedValue = null;

            UpdatedListener?.FilterUpdated();
        }
        #endregion

        #region Value change events
        private void SlAvailableRunwayLength_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e) {
            AvailableRunwayLength = (int)e.NewValue;
        }

        private void SlFlownHours_LowerValueChanged(object sender, MahApps.Metro.Controls.RangeParameterChangedEventArgs e) {
            FlownHoursLowerValue = (int)e.NewValue;
        }

        private void SlFlownHours_UpperValueChanged(object sender, MahApps.Metro.Controls.RangeParameterChangedEventArgs e) {
            FlownHoursUpperValue = (int)e.NewValue;
        }

        private void SlFlownHours_RangeSelectionChanged(object sender, MahApps.Metro.Controls.RangeSelectionChangedEventArgs e) {
            FlownHoursLowerValue = (int)e.NewLowerValue;
            FlownHoursUpperValue = (int)e.NewUpperValue;
        }

        private void SlAge_LowerValueChanged(object sender, MahApps.Metro.Controls.RangeParameterChangedEventArgs e) {
            AgeLowerValue = (int)e.NewValue;
        }

        private void SlAge_UpperValueChanged(object sender, MahApps.Metro.Controls.RangeParameterChangedEventArgs e) {
            AgeUpperValue = (int)e.NewValue;
        }

        private void SlAge_RangeSelectionChanged(object sender, MahApps.Metro.Controls.RangeSelectionChangedEventArgs e) {
            AgeLowerValue = (int)e.NewLowerValue;
            AgeUpperValue = (int)e.NewUpperValue;
        }

        private void CbAircraftType_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            Type = e.AddedItems as Aircraft;
        }
        #endregion
        #endregion
    }
}
