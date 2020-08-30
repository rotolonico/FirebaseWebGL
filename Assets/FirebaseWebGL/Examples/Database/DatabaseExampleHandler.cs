using FirebaseWebGL.Examples.Utils;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Scripts.Objects;
using TMPro;
using UnityEngine;

namespace FirebaseWebGL.Examples.Database
{
    public class DatabaseExampleHandler : MonoBehaviour
    {
        public TMP_InputField pathInputField;
        public TMP_InputField valueInputField;

        public TMP_InputField amountInputField;

        public TextMeshProUGUI outputText;

        private void Start()
        {
            if (Application.platform != RuntimePlatform.WebGLPlayer)
                DisplayError("The code is not running on a WebGL build; as such, the Javascript functions will not be recognized.");
        }

        public void GetJSON() =>
            FirebaseDatabase.GetJSON(pathInputField.text, gameObject.name, "DisplayData", "DisplayErrorObject");

        public void PostJSON() => FirebaseDatabase.PostJSON(pathInputField.text, valueInputField.text, gameObject.name,
            "DisplayInfo", "DisplayErrorObject");

        public void PushJSON() => FirebaseDatabase.PushJSON(pathInputField.text, valueInputField.text, gameObject.name,
            "DisplayInfo", "DisplayErrorObject");

        public void UpdateJSON() => FirebaseDatabase.UpdateJSON(pathInputField.text, valueInputField.text,
            gameObject.name, "DisplayInfo", "DisplayErrorObject");

        public void DeleteJSON() =>
            FirebaseDatabase.DeleteJSON(pathInputField.text, gameObject.name, "DisplayInfo", "DisplayErrorObject");

        public void ListenForValueChanged() =>
            FirebaseDatabase.ListenForValueChanged(pathInputField.text, gameObject.name, "DisplayData", "DisplayErrorObject");

        public void StopListeningForValueChanged() => FirebaseDatabase.StopListeningForValueChanged(pathInputField.text, gameObject.name, "DisplayInfo", "DisplayErrorObject");

        public void ListenForChildAdded() =>
            FirebaseDatabase.ListenForChildAdded(pathInputField.text, gameObject.name, "DisplayData", "DisplayErrorObject");

        public void StopListeningForChildAdded() => FirebaseDatabase.StopListeningForChildAdded(pathInputField.text, gameObject.name, "DisplayInfo", "DisplayErrorObject");

        public void ListenForChildChanged() =>
            FirebaseDatabase.ListenForChildChanged(pathInputField.text, gameObject.name, "DisplayData", "DisplayErrorObject");

        public void StopListeningForChildChanged() => FirebaseDatabase.StopListeningForChildChanged(pathInputField.text, gameObject.name, "DisplayInfo", "DisplayErrorObject");

        public void ListenForChildRemoved() =>
            FirebaseDatabase.ListenForChildRemoved(pathInputField.text, gameObject.name, "DisplayData", "DisplayErrorObject");

        public void StopListeningForChildRemoved() => FirebaseDatabase.StopListeningForChildRemoved(pathInputField.text, gameObject.name, "DisplayInfo", "DisplayErrorObject");

        public void ModifyNumberWithTransaction()
        {
            float.TryParse(amountInputField.text, out var amount);
            FirebaseDatabase.ModifyNumberWithTransaction(pathInputField.text, amount, gameObject.name, "DisplayInfo",
                "DisplayErrorObject");
        }

        public void ToggleBooleanWithTransaction() =>
            FirebaseDatabase.ToggleBooleanWithTransaction(pathInputField.text, gameObject.name, "DisplayInfo",
                "DisplayErrorObject");

        public void DisplayData(string data)
        {
            outputText.color = outputText.color == Color.green ? Color.blue : Color.green;
            outputText.text = data;
            Debug.Log(data);
        }

        public void DisplayInfo(string info)
        {
            outputText.color = Color.white;
            outputText.text = info;
            Debug.Log(info);
        }

        public void DisplayErrorObject(string error)
        {
            var parsedError = StringSerializationAPI.Deserialize(typeof(FirebaseError), error) as FirebaseError;
            DisplayError(parsedError.message);
        }

        public void DisplayError(string error)
        {
            outputText.color = Color.red;
            outputText.text = error;
            Debug.LogError(error);
        }
    }
}