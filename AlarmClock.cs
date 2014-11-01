using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L2A
{
    class AlarmClock
    {
        #region fields

        private int _alarmHour;
        private int _alarmMinute;
        private int _hour;
        private int _minute;
        #endregion

        #region properties

        /// <summary>
        /// Sets _hour to integer 0-23 or returns its value
        /// </summary>
        public int Hour 
        {
            get { return _hour; }

            set
            {
                if (value < 0 || value > 23)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _hour = value;
            }
        }
        
        /// <summary>
        /// Sets _minute to integer 0-59 or returns its value
        /// </summary>
        public int Minute 
        {
            get { return _minute; }

            set 
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _minute = value;
            }
        }
        
        /// <summary>
        /// Sets _alarmHour to integer 0-23 or returns its value
        /// </summary>
        public int AlarmHour
        {
            get { return _alarmHour; }

            set
            {
                if (value < 0 || value > 23)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _alarmHour = value;
            }
        }
        
        /// <summary>
        /// Sets _alarmMinute to integer 0-59 or returns its value
        /// </summary>
        public int AlarmMinute 
        {
            get { return _alarmMinute; }

            set 
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _alarmMinute = value;
            }
        }
        #endregion

        #region methods
        /// <summary>
        /// Constructor
        /// </summary>
        public AlarmClock()
            :this(0,0)
        {

        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        public AlarmClock(int hour, int minute)
            :this (hour, minute, 0, 0)
        {

        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="alarmHour"></param>
        /// <param name="alarmMinute"></param>
        public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute)
           
        {
            Hour = hour;
            Minute = minute;
            AlarmHour = alarmHour;
            AlarmMinute = alarmMinute;
        }

        /// <summary>
        /// Method that increases the time with one minute
        /// </summary>
        /// <returns>true if new time is alarm time, otherwise false</returns>
        public bool TickTock()
        {
            if (Minute == 59)
            {
                if (Hour == 23)
                {
                    Hour = 0;
                }
                else
                {
                    Hour++;
                }

                Minute = 0;
            }
            else
            {
                Minute++;
            }

            if (Minute == AlarmMinute && Hour == AlarmHour)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Converts AlarmClock time to string
        /// </summary>
        /// <returns>an instance of AlarmClock represented as a string</returns>
        new public string ToString()
        {
            return String.Format("      {0,2}:{1:D2}    <{2,2}:{3:D2}>", Hour, Minute, AlarmHour, AlarmMinute);
        }

        #endregion

    }
}