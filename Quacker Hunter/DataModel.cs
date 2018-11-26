using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Quacker_Hunter
{
    [DataContract]
    public class DataModel
    {
        public static string DataPath = "saverecords.dat";
        [DataMember]
        public List<Profile> Records { get; set; }

        public DataModel()
        {
            Records = new List<Profile>();
        }

        public static DataModel Load()
        {
            if (File.Exists(DataPath))
            {
                return DataSerializer.DeserializeRecords(DataPath);
            }
            return new DataModel();
        }

        public void Save()
        {
            DataSerializer.SerializeDataToRecords(DataPath, this);
        }
    }
}
