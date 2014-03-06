using System.Text;
using Newtonsoft.Json;

namespace Publisher
{
    public class Serializer
    {
        public byte[] Serialize<T>(T messageObject)
        {
           return Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(messageObject));
        }
    }
}