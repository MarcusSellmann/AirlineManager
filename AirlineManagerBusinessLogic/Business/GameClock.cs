using System;
using System.Collections.Generic;
using System.Timers;

using AirlineManager.Business.Interfaces;

namespace AirlineManager.Business {
    [Serializable]
    public class GameClock {
        #region Attributes
        private readonly Timer m_timer = new Timer(1000);
        [NonSerialized]
        private readonly List<IGameClockTickReceiver> m_gameClockTickReceivers;
        #endregion

        #region Property
        public DateTime GameCreationTime { get; private set; }

        public float TimeScaleFactor { get; set; }

        public TimeSpan GameTimePlayed { get; private set; }

        public DateTime CurrentGameTime {
            get => GameCreationTime + GameTimePlayed;
        }
        #endregion

        public GameClock() {
            m_gameClockTickReceivers = new List<IGameClockTickReceiver>();
            m_timer.Elapsed += Timer_Elapsed;
            m_timer.AutoReset = true;
        }

        public void InitGameClock() {
            GameCreationTime = DateTime.Now;
            TimeScaleFactor = 1.0f;
            GameTimePlayed = TimeSpan.FromSeconds(0);
        }

        public void AddTickReceiver(IGameClockTickReceiver tickReceiver) {
            if (tickReceiver != null) {
                m_gameClockTickReceivers.Add(tickReceiver);
            }
        }

        public void StartGameTick() => m_timer.Start();

        public void IncreaseTimeScaleFactor(float by = 5f) {
            TimeScaleFactor += by;
        }

        public void DecreaseTimeScaleFactor(float by = 5f) {
            if (TimeScaleFactor >= by) {
                TimeScaleFactor -= by;
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            GameTimePlayed += TimeSpan.FromSeconds(TimeScaleFactor);

            foreach (IGameClockTickReceiver receiver in m_gameClockTickReceivers) {
                receiver.GameTickReceived();
            }
        }
    }
}
