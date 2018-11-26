using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Quacker_Hunter
{
    public class DataSerializer
    {
        public static void SerializeData(string fileName, Game data)
        {
            var formatter = new DataContractSerializer(typeof(Game));
            var s = new FileStream("save.dat", FileMode.Create);
            formatter.WriteObject(s, data);
            s.Close();
        }

        public static Game DeserializeItem(string fileName)
        {
            var s = new FileStream(fileName, FileMode.Open);
            var formatter = new DataContractSerializer(typeof(Game));
            return (Game)formatter.ReadObject(s);
        }

        public static void SerializeDataToRecords(string fileName, DataModel data)
        {
            DataContractSerializer formatter = new DataContractSerializer(typeof(DataModel));
            var s = new FileStream("saverecords.dat", FileMode.Create);
            formatter.WriteObject(s, data);
            s.Close();
        }

        public static DataModel DeserializeRecords(string fileName)
        {
            var s = new FileStream(fileName, FileMode.Open);
            var formatter = new DataContractSerializer(typeof(DataModel));
            return (DataModel)formatter.ReadObject(s);
        }
    }
}
