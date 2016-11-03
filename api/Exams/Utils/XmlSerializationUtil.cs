using System.IO;
using System.Xml.Serialization;

namespace Exams.Utils
{
    public static class XmlSerializationUtil
    {
        public static T DeserializeFile<T>(string filePath) where T : class, new()
        {
            using (var fileStrem = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                var obj = xmlSerializer.Deserialize(fileStrem);
                T result = obj as T;
                return result;
            }
        }
    }
}