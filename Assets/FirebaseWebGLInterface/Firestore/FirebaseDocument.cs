using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseWebglInterface.Firestore
{
    public class FirebaseDocument
    {
        private string path;
        public FirebaseDocument(string path)
        {
            this.path = path;
        }
        public ListenerRegistration Listen(Action<DocumentSnapshot> action)
        {
            //new EmptyGameObject..(name - path)
            //GetObjectByName().GetComponent<ObjectUpdate>()
            //firebaseBridge.listen(path, docId, false, "EmptyGameObject")
            return new ListenerRegistration();
        }

        public FirebaseCollection Collection(string collection)
        {
            return new FirebaseCollection(path + "/" + collection);
        }
    }
}

