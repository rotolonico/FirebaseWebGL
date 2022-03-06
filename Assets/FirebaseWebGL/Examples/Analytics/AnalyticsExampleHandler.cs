using FirebaseWebGL.Scripts.FirebaseAnalytics;
using TMPro;
using UnityEngine;

namespace FirebaseWebGL.Examples.Analytics
{
    public class AnalyticsExampleHandler : MonoBehaviour
    {
        [SerializeField] TMP_InputField inputProperties;
        [SerializeField] TMP_InputField inputEventName1;
        [SerializeField] TMP_InputField inputEventName2;
        [SerializeField] TMP_InputField inputEventParam;

        public void SetUserProperties() =>
            FirebaseAnalytics.SetUserProperties(inputProperties.text);

        public void LogEvent() =>
            FirebaseAnalytics.LogEvent(inputEventName1.text);

        public void LogEventParameter() =>
            FirebaseAnalytics.LogEventParameter(inputEventName2.text, inputEventParam.text);
    }
}