using FirebaseWebGL.Examples.Utils;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Scripts.Objects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FirebaseWebGL.Examples.Firestore
{
    public class FirestoreExampleHandler : MonoBehaviour
    {
        public TMP_InputField collectionPathInputField;
        public TMP_InputField documentIdInputField;
        public TMP_InputField valueInputField;
        
        public TMP_InputField fieldIdInputField;
        public Toggle includeMetadataUpdatesToggle;
        public TMP_InputField incrementInputField;

        public TextMeshProUGUI outputText;

        private void Start()
        {
            if (Application.platform != RuntimePlatform.WebGLPlayer)
                DisplayError("The code is not running on a WebGL build; as such, the Javascript functions will not be recognized.");
        }

        public void GetDocument() =>
            FirebaseFirestore.GetDocument(collectionPathInputField.text, documentIdInputField.text, gameObject.name, "DisplayData", "DisplayErrorObject");
        
        public void GetDocumentsInCollection() =>
            FirebaseFirestore.GetDocumentsInCollection(collectionPathInputField.text, gameObject.name, "DisplayData", "DisplayErrorObject");

        public void SetDocument() => FirebaseFirestore.SetDocument(collectionPathInputField.text, documentIdInputField.text, valueInputField.text, gameObject.name,
            "DisplayInfo", "DisplayErrorObject");
        
        public void AddDocument() => FirebaseFirestore.AddDocument(collectionPathInputField.text, valueInputField.text, gameObject.name,
            "DisplayInfo", "DisplayErrorObject");
        
        public void UpdateDocument() => FirebaseFirestore.UpdateDocument(collectionPathInputField.text, documentIdInputField.text, valueInputField.text, gameObject.name,
            "DisplayInfo", "DisplayErrorObject");
        
        public void DeleteDocument() => FirebaseFirestore.DeleteDocument(collectionPathInputField.text, documentIdInputField.text, gameObject.name,
            "DisplayInfo", "DisplayErrorObject");
        
        public void DeleteField() => FirebaseFirestore.DeleteField(collectionPathInputField.text, documentIdInputField.text, fieldIdInputField.text, gameObject.name,
            "DisplayInfo", "DisplayErrorObject");

        public void AddElementInArrayField() => FirebaseFirestore.AddElementInArrayField(collectionPathInputField.text, documentIdInputField.text, fieldIdInputField.text, valueInputField.text, gameObject.name,
            "DisplayInfo", "DisplayErrorObject");
        
        public void RemoveElementInArrayField() => FirebaseFirestore.RemoveElementInArrayField(collectionPathInputField.text, documentIdInputField.text, fieldIdInputField.text, valueInputField.text, gameObject.name,
            "DisplayInfo", "DisplayErrorObject");
        
        public void IncrementFieldValue() => FirebaseFirestore.IncrementFieldValue(collectionPathInputField.text, documentIdInputField.text, fieldIdInputField.text, int.Parse(incrementInputField.text), gameObject.name,
            "DisplayInfo", "DisplayErrorObject");

        public void ListenForDocumentChange() =>
            FirebaseFirestore.ListenForDocumentChange(collectionPathInputField.text, documentIdInputField.text, includeMetadataUpdatesToggle.isOn, gameObject.name, "DisplayData", "DisplayErrorObject");

        public void StopListeningForDocumentChange() => FirebaseFirestore.StopListeningForDocumentChange(collectionPathInputField.text, documentIdInputField.text, gameObject.name, "DisplayInfo", "DisplayErrorObject");
        
        public void ListenForCollectionChange() =>
            FirebaseFirestore.ListenForCollectionChange(collectionPathInputField.text, includeMetadataUpdatesToggle.isOn, gameObject.name, "DisplayData", "DisplayErrorObject");

        public void StopListeningForCollectionChange() => FirebaseFirestore.StopListeningForCollectionChange(collectionPathInputField.text, gameObject.name, "DisplayInfo", "DisplayErrorObject");

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