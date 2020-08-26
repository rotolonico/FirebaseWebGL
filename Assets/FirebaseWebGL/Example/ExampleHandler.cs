using FirebaseWebGL.Scripts;
using TMPro;
using UnityEngine;

namespace FirebaseWebGL.Example
{
    public class ExampleHandler : MonoBehaviour
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
            FirebaseBridge.GetJSON(pathInputField.text, gameObject.name, "DisplayData", "DisplayError");

        public void PostJSON() => FirebaseBridge.PostJSON(pathInputField.text, valueInputField.text, gameObject.name,
            "DisplayInfo", "DisplayError");

        public void PushJSON() => FirebaseBridge.PushJSON(pathInputField.text, valueInputField.text, gameObject.name,
            "DisplayInfo", "DisplayError");

        public void UpdateJSON() => FirebaseBridge.UpdateJSON(pathInputField.text, valueInputField.text,
            gameObject.name, "DisplayInfo", "DisplayError");

        public void DeleteJSON() =>
            FirebaseBridge.DeleteJSON(pathInputField.text, gameObject.name, "DisplayInfo", "DisplayError");

        public void ListenForValueChanged() =>
            FirebaseBridge.ListenForValueChanged(pathInputField.text, gameObject.name, "DisplayData", "DisplayError");

        public void StopListeningForValueChanged() => FirebaseBridge.StopListeningForValueChanged(pathInputField.text, gameObject.name, "DisplayInfo", "DisplayError");

        public void ListenForChildAdded() =>
            FirebaseBridge.ListenForChildAdded(pathInputField.text, gameObject.name, "DisplayData", "DisplayError");

        public void StopListeningForChildAdded() => FirebaseBridge.StopListeningForChildAdded(pathInputField.text, gameObject.name, "DisplayInfo", "DisplayError");

        public void ListenForChildChanged() =>
            FirebaseBridge.ListenForChildChanged(pathInputField.text, gameObject.name, "DisplayData", "DisplayError");

        public void StopListeningForChildChanged() => FirebaseBridge.StopListeningForChildChanged(pathInputField.text, gameObject.name, "DisplayInfo", "DisplayError");

        public void ListenForChildRemoved() =>
            FirebaseBridge.ListenForChildRemoved(pathInputField.text, gameObject.name, "DisplayData", "DisplayError");

        public void StopListeningForChildRemoved() => FirebaseBridge.StopListeningForChildRemoved(pathInputField.text, gameObject.name, "DisplayInfo", "DisplayError");

        public void ModifyNumberWithTransaction()
        {
            float.TryParse(amountInputField.text, out var amount);
            FirebaseBridge.ModifyNumberWithTransaction(pathInputField.text, amount, gameObject.name, "DisplayInfo",
                "DisplayError");
        }

        public void ToggleBooleanWithTransaction() =>
            FirebaseBridge.ToggleBooleanWithTransaction(pathInputField.text, gameObject.name, "DisplayInfo",
                "DisplayError");

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

        public void DisplayError(string error)
        {
            outputText.color = Color.red;
            outputText.text = error;
            Debug.LogError(error);
        }
    }
}