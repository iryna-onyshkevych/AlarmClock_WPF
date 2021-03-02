using System;

namespace AlarmClock
{
    [Serializable]
    public class AlarmClocks
    {
        public int alarmMinutes { get; set; }
        public int alarmHours { get; set; }
        public DateTime alarmDate { get; set; }
        public string alarmMessage { get; set; }
        public AlarmClocks()
        { }
    }
}
