using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseWebglInterface.Firestore
{
    public class DocumentSnapshot
    {
        public string Id;
        public bool Exists { get; }
        public Dictionary<string, object> dict;
        public bool TryGetValue<T>(string path, out T value) 
        {
            value = default(T);
            return false;
        }
        public T GetValue<T>(string path)
        {
            return default(T);
        }

        public bool ContainsField(string path)
        {
            return false;
        }

        public Dictionary<string, object> ToDictionary()
        {
            return null;
        }

    }
}
