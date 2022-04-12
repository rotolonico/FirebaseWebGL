using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseWebglInterface.Firestore
{
    public class QuerySnapshot
    {
        public int Count { get; }
        public DocumentSnapshot[] Documents { get; }
    }
}
