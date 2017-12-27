using AirlineManager.Data.Enumerations;

namespace AirlineManager.Data {
    public class Engine {
        #region Attributes
        EngineManufacturer m_manufacturer;
        string m_name;
        float m_thrust;
        #endregion

        #region Properties
        public EngineManufacturer Manufacturer {
            get {
                return m_manufacturer;
            }
        }

        public string Name {
            get {
                return m_name;
            }
        }

        public float Thrust {
            get {
                return m_thrust;
            }
        }
        #endregion

        public Engine(EngineManufacturer manufacturer, string name, float thrust) {
            m_manufacturer = manufacturer;
            m_name = name;
            m_thrust = thrust;
        }
    }
}
