using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AirlineManager.Data;

namespace AirlineManager.UI.Utilities {
    public class MaintenanceServiceContainer {
        #region Properties
        public string Name { get; private set; }
        public bool Selected { get; private set; }
        public PlannedService Service { get; private set; }
        #endregion

        public MaintenanceServiceContainer(string name, PlannedService service, bool selected = false) {
            Name = name;
            Selected = selected;
            Service = service;
        }
    }
}
