using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseWebglInterface.Firestore
{
    public class FirebaseFirestore
    {
        public static FirebaseFirestore DefaultInstance = new FirebaseFirestore();

        public FirebaseDocument Document(string path)
        {
            return new FirebaseDocument(path);
        }

        public FirebaseCollection Collection(string path)
        {
            return new FirebaseCollection(path);
        }
    }
}
