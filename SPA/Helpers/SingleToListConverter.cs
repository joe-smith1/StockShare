#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace SPA.Helpers
{
    public class SingleToListConverter<T> : JsonConverter<List<T>>
    {
        public override void WriteJson(JsonWriter writer, List<T> value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override List<T> ReadJson(JsonReader reader, Type objectType, List<T> existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {

            var token = JToken.ReadFrom(reader);
            if (token == null || token.Type == JTokenType.Null)
            {
                return new List<T>();
            }
            else if (token.Type == JTokenType.Array)
            {
                return token.ToObject<List<T>>(serializer);
            }
            else
            {
                return new List<T>
                {
                    token.ToObject<T>(serializer)
                };
            }

        }
    }
}