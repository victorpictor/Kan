using Newtonsoft.Json;

namespace Publisher
{
    public class Serializer
    {
        public string Serialize<T>(T messageObject)
        {
           return JsonConvert.SerializeObject(messageObject);
        }
    }
}