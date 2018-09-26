using System;
using System.Timers;

namespace AirlineManager.Business {
    [Serializable()]
    public class GameClock {
        #region Attributes
        private Timer m_timer = new Timer(1000);
        #endregion

        #region Property
        public DateTime InitialStartTime { get; private set; }

        public float TimeScaleFactor { get; set; }

        public TimeSpan TimePlayedGameTime { get; private set; }

        public TimeSpan TimePlayedRealTime {
            get {
                return DateTime.Now - InitialStartTime;
            }
        }

        public DateTime CurrentTimeGameTime {
            get {
                return InitialStartTime + TimePlayedGameTime;
            }
        }
        #endregion

        public GameClock(float timeScaleFactor = 1.0f) {
            InitialStartTime = DateTime.Now;
            TimeScaleFactor = timeScaleFactor;
            TimePlayedGameTime = TimeSpan.FromSeconds(0);

            m_timer.Elapsed += Timer_Elapsed;
            m_timer.AutoReset = true;
            m_timer.Start();
        }

        public void IncreaseTimeScaleFactor(float by = 0.5f) {
            TimeScaleFactor += by;
        }

        public void DecreaseTimeScaleFactor(float by = 0.5f) {
            TimeScaleFactor -= by;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            TimePlayedGameTime += TimeSpan.FromSeconds(TimeScaleFactor);
        }
    }
}
