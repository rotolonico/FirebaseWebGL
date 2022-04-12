using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseWebglInterface.Firestore
{
    public class FirebaseCollection
    {
        private string path;
        public FirebaseCollection(string path)
        {
            this.path = path;
        }
        public FirebaseCollection OrderByDescending(string orderBy)
        {
            return this;
        }

        public FirebaseCollection Limit(int limit)
        {
            return this;
        }
        public ListenerRegistration Listen(Action<QuerySnapshot> action)
        {
            return new ListenerRegistration();
        }

        public FirebaseDocument Document(string document)
        {
            return new FirebaseDocument(path + "/" + document);
        }
    }
}
