using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Quacker_Hunter
{
    [DataContract]
    public class Profile
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Record { get; set; }

        public Profile(string name, int record)
        {
            Name = name;
            Record = record;
        }
    }
}
