using System;

namespace AlarmClock
{
    [Serializable]
    public class AlarmClocks
    {
        public int AlarmMinutes { get; set; }
        public int AlarmHours { get; set; }
        public int AlarmSeconds { get; set; }
        public DateTime AlarmDate { get; set; }
        public string AlarmMessage { get; set; }
        public bool AlarmIsCalled { get; set; }
        public AlarmClocks()
        { }
    }
}
