using System;
using System.Collections.Generic;
using FirebaseWebGL.Examples.Utils;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Scripts.Objects;
using Proyecto26;
using TMPro;
using UnityEngine;

namespace FirebaseWebGL.Examples.Functions
{
    public class FunctionsExampleHandler : MonoBehaviour
    {
        public TMP_InputField functionNameInputField;
        public TMP_InputField parameterKeyInputField;
        public TMP_InputField parameterValueInputField;

        public TextMeshProUGUI outputText;
        public TextMeshProUGUI parametersText;

        public Dictionary<string, string> parameters = new Dictionary<string, string>();

        private void Start()
        {
            if (Application.platform != RuntimePlatform.WebGLPlayer)
                DisplayError(
                    "The code is not running on a WebGL build; as such, the Javascript functions will not be recognized.");
        }

        public void AddParameter()
        {
            parameters.Add(parameterKeyInputField.text, parameterValueInputField.text);
            DisplayParameters();
        }

        public void RemoveParameter()
        {
            parameters.Remove(parameterKeyInputField.text);
            DisplayParameters();
        }

        public void DisplayParameters() =>
            parametersText.text = "Parameters: " +
                                  StringSerializationAPI.Serialize(typeof(Dictionary<string, string>), parameters);

        public void CallCloudFunction()
        {
            FirebaseFunctions.CallCloudFunction(functionNameInputField.text,
                parameters,
                DisplayData, DisplayErrorObject);
        }

        public void DisplayData(ResponseHelper response)
        {
            outputText.color = outputText.color == Color.green ? Color.blue : Color.green;
            outputText.text = response.Text;
            Debug.Log(response.Text);
        }

        public void DisplayErrorObject(Exception error)
        {
            DisplayError(error.Message);
        }

        public void DisplayError(string error)
        {
            outputText.color = Color.red;
            outputText.text = error;
            Debug.LogError(error);
        }
    }
}