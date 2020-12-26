using System;
using System.Collections.Generic;
using System.Text;
using FirebaseWebGL.Examples.Utils;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Scripts.Objects;
using Proyecto26;
using TMPro;
using UnityEngine;

namespace FirebaseWebGL.Examples.Storage
{
    public class StorageExampleHandler : MonoBehaviour
    {
        public TMP_InputField filePathInputField;
        public TMP_InputField fileDataInputField;

        public TextMeshProUGUI outputText;

        private void Start()
        {
            if (Application.platform != RuntimePlatform.WebGLPlayer)
                DisplayError(
                    "The code is not running on a WebGL build; as such, the Javascript functions will not be recognized.");
        }

        public void UploadFile() => FirebaseStorage.UploadFile(filePathInputField.text,
            Convert.ToBase64String(Encoding.ASCII.GetBytes(fileDataInputField.text)), gameObject.name, "DisplayInfo", "DisplayErrorObject");

        public void DownloadFile() => FirebaseStorage.DownloadFile(filePathInputField.text, gameObject.name, "DisplayFile", "DisplayErrorObject");

        public void DisplayFile(string base64File)
        {
            var bytes = Convert.FromBase64String(base64File);
            var text = Encoding.ASCII.GetString(bytes);
            
            DisplayData(text);
            fileDataInputField.text = text;
        }
        
        public void DisplayInfo(string info)
        {
            outputText.color = Color.white;
            outputText.text = info;
            Debug.Log(info);
        }

        public void DisplayData(string data)
        {
            outputText.color = outputText.color == Color.green ? Color.blue : Color.green;
            outputText.text = data;
            Debug.Log(data);
        }

        public void DisplayErrorObject(string error)
        {
            Debug.LogError(error);
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