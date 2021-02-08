using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace SPA.Helpers
{
    /// <summary>
    /// Json converter for reading from JSON response where the JSON token could be a
    /// single object or a list of objects. e.g if the API doesn't follow a set format
    /// when there could be one or many items like in the tradier APIs response for Quotes,
    /// we can then use this converter on the specific properties with any given type
    /// and it will be converted into a list even if it only has one item.
    /// </summary>
    /// <typeparam name="T">
    /// The Type of the property to provide the single to list
    /// conversion on.
    /// </typeparam>
    public class SingleToListConverter<T> : JsonConverter<List<T>>
    {
        /// <summary>
        /// Currently Not implemented as our API has no need to write a single item to an
        /// array as it would already be given as an array.
        /// </summary>
        /// <param name="writer">JsonWriter to write our conversion to.</param>
        /// <param name="value">The List of type <see cref="T"/> to convert.</param>
        /// <param name="serializer">The current serializer in the serialization process.</param>
        public override void WriteJson(JsonWriter writer, List<T> value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts the JSON read in through the Deserialization process into a List of the type <see cref="T"/>.
        /// If the JSON token being read in is already an array then it is just returned as a List. If the token
        /// however is only a single object then we return a List with only that object in it.
        /// </summary>
        /// <param name="reader">JsonReader used to read the current JSON Token along with its children.</param>
        /// <param name="objectType">Type of the object being read.</param>
        /// <param name="existingValue">The Existing value of the object being read.</param>
        /// <param name="hasExistingValue">If the object being read already has an existing value.</param>
        /// <param name="serializer">The serializer of the current Serialization process used to deserialize our tokens.</param>
        /// <returns>
        /// A list with a single element of type <see cref="T"/> if the JSON token was not a list of items already
        /// otherwise it returns the JSON List as a List object.
        /// </returns>
        public override List<T> ReadJson(JsonReader reader, Type objectType, List<T> existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {

            var token = JToken.Load(reader);
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