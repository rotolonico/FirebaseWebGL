using System.Runtime.InteropServices;

namespace FirebaseWebGL.Scripts.FirebaseAnalytics
{
    public static class FirebaseAnalytics
    {
        /// <summary>
        /// Setup current user's properties
        /// </summary>
        /// <param name="props">JSON-formatted string of the property
        /// ex : {"name":"MonsterName", "lives":"3"}
        /// </param>
        [DllImport("__Internal")]
        public static extern void SetUserProperties(string props);

        /// <summary>
        /// Log an event without parameter
        /// </summary>
        /// <param name="eventName">Name of the event</param>
        [DllImport("__Internal")]
        public static extern void LogEvent(string eventName);

        /// <summary>
        /// Log an event with parameter
        /// </summary>
        /// <param name="eventName">Name of the event</param>
        /// <param name="eventParam">JSON-formatted string of parameter.
        /// ex : {"name":"MonsterName", "lives":"3"}
        /// </param>
        [DllImport("__Internal")]
        public static extern void LogEventParameter(string eventName, string eventParam);
    }
}