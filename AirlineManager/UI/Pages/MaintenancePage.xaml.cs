using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using nGantt;
using nGantt.GanttChart;
using nGantt.PeriodSplitter;

using AirlineManager.Data;
using AirlineManager.UI.Utilities;
using AirlineManager.Business;

namespace AirlineManager.UI.Pages {
    /// <summary>
    /// Interaktionslogik für MaintenancePage.xaml
    /// </summary>
    public partial class MaintenancePage : Page {
        readonly CultureInfo culture = new CultureInfo("de-DE");
        public List<MaintenanceServiceContainer> chartData { get; private set; } = new List<MaintenanceServiceContainer>();

        public MaintenancePage() {
            chartData = new List<MaintenanceServiceContainer>();

            InitializeComponent();

            Dictionary<AircraftInstance, List<PlannedService>> serviceData = MainGameController.Instance.CurrentAirline.AllPlannedServices;

            foreach(KeyValuePair<AircraftInstance, List<PlannedService>> sd in serviceData) {
                foreach(PlannedService ps in sd.Value) {
                    chartData.Add(new MaintenanceServiceContainer(sd.Key.ToString(), ps));
                }
            }

            chartData.Add(new MaintenanceServiceContainer("D-NAGZ", new PlannedService(ServiceLevel.A, DateTime.Now.AddMinutes(20), TimeSpan.FromHours(2), 545632)));
            chartData.Add(new MaintenanceServiceContainer("D-BGAH", new PlannedService(ServiceLevel.C, DateTime.Now.AddHours(1), TimeSpan.FromHours(13), 2548545632)));
            chartData.Add(new MaintenanceServiceContainer("D-AHFD", new PlannedService(ServiceLevel.B, DateTime.Now.AddHours(1).AddMinutes(10), TimeSpan.FromHours(7), 25485632)));

            DateTime minDate = DateTime.Now;

            if (chartData.Count > 0) {
                minDate = chartData.Min(s => s.Service.StartTime).AddHours(-minDate.Hour);
            }
            
            ConvertData(minDate, minDate.AddDays(1));
        }

        public void ConvertData(DateTime minDate, DateTime maxDate) {
            // Set max and min dates
            ganttUserControl.Initialize(minDate, maxDate);

            // Create timelines and define how they should be presented
            ganttUserControl.CreateTimeLine(new PeriodYearSplitter(minDate, maxDate), p => p.Start.Year.ToString());
            ganttUserControl.CreateTimeLine(new PeriodMonthSplitter(minDate, maxDate), p => p.Start.Month.ToString());
            ganttUserControl.CreateTimeLine(new PeriodDaySplitter(minDate, maxDate), p => p.Start.Day.ToString());
            var gridLineTimeLine = ganttUserControl.CreateTimeLine(new PeriodHourSplitter(minDate, maxDate), p => p.Start.Hour.ToString());

            // Set the timeline to attach gridlines to
            ganttUserControl.SetGridLinesTimeline(gridLineTimeLine, DetermineBackground);

            HeaderedGanttRowGroup servicesLevelA = ganttUserControl.CreateGanttRowGroup("Level A");
            HeaderedGanttRowGroup servicesLevelB = ganttUserControl.CreateGanttRowGroup("Level B");
            HeaderedGanttRowGroup servicesLevelC = ganttUserControl.CreateGanttRowGroup("Level C");
            HeaderedGanttRowGroup servicesLevelD = ganttUserControl.CreateGanttRowGroup("Level D");
            HeaderedGanttRowGroup servicesExtras = ganttUserControl.CreateGanttRowGroup("Extras");

            foreach (MaintenanceServiceContainer plannedService in chartData) {
                GanttRow row = null;

                switch (plannedService.Service.Level) {
                    case ServiceLevel.A:
                        row = ganttUserControl.CreateGanttRow(servicesLevelA, plannedService.Name);
                        break;

                    case ServiceLevel.B:
                        row = ganttUserControl.CreateGanttRow(servicesLevelB, plannedService.Name);
                        break;

                    case ServiceLevel.C:
                        row = ganttUserControl.CreateGanttRow(servicesLevelC, plannedService.Name);
                        break;

                    case ServiceLevel.D:
                        row = ganttUserControl.CreateGanttRow(servicesLevelD, plannedService.Name);
                        break;

                    default:
                        row = ganttUserControl.CreateGanttRow(servicesExtras, plannedService.Name);
                        break;
                }

                List<MaintenanceServiceContainer> sortedChartTimeSpan = chartData.FindAll(p => p.Name.Equals(plannedService.Name));

                foreach (MaintenanceServiceContainer sorted in sortedChartTimeSpan) {
                    ganttUserControl.AddGanttTask(row, new GanttTask {
                        Start = sorted.Service.StartTime,
                        End = sorted.Service.EndTime,
                        Name = sorted.Name,
                        Radius = sorted.Service.Duration.TotalDays < 3 ? 0 : 5,
                        Color = sorted.Selected ? Colors.White : Colors.DodgerBlue,
                        TaskProgressVisibility = Visibility.Hidden
                    });
                }
            }
        }

        private Brush DetermineBackground(TimeLineItem timeLineItem) {
            if (timeLineItem.End.Date.DayOfWeek == DayOfWeek.Saturday || timeLineItem.End.Date.DayOfWeek == DayOfWeek.Sunday) {
                return new SolidColorBrush(Colors.White);
            }
            
            return new SolidColorBrush(Colors.Transparent);
        }

        private void btnAddMaintenanceService_Click(object sender, RoutedEventArgs e) {

        }
    }
}
