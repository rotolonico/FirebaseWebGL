using UnityEngine;
using UnityEngine.SceneManagement;

namespace FirebaseWebGL.Examples.Utils
{
    public class ExampleScenesHandler : MonoBehaviour
    {
        public void GoToDatabaseScene() => SceneManager.LoadScene("DatabaseExampleScene");
        
        public void GoToAuthScene() => SceneManager.LoadScene("AuthExampleScene");
        
        public void GoToFunctionsScene() => SceneManager.LoadScene("FunctionsExampleScene");
        
        public void GoToStorageScene() => SceneManager.LoadScene("StorageExampleScene");
        
        public void GoToFirestoreScene() => SceneManager.LoadScene("FirestoreExampleScene");
    }
}
