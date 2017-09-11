using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Lab5
{
    [DataContract]
    internal class DocumentStatistics
    {
        [DataMember]
        public int DocumentCount { get; set; }

        [DataMember]
        public List<string> Documents { get; set; }

        [DataMember]
        public Dictionary<string, int> WordCounts { get; set; }

        public DocumentStatistics()
        {
            DocumentCount = 0;
            Documents = new List<string>();
            WordCounts = new Dictionary<string, int>();
        }
    }
}