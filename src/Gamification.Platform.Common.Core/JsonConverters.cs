using NetTopologySuite.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Gamification.Platform.Common.Core
{
    public class NetTopologySuiteGeometryConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var jsonSerializer = GeoJsonSerializer.Create();
            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                jsonSerializer.Serialize(jsonWriter, value);
                writer.WriteRawValue(stringWriter.ToString());
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonSerializer = NetTopologySuite.IO.GeoJsonSerializer.Create();

            return jsonSerializer.Deserialize<NetTopologySuite.Geometries.MultiPolygon>(reader);
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(string).IsAssignableFrom(objectType);
        }
    }

    public class NetTopologySuiteGeometryPointConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var jsonSerializer = GeoJsonSerializer.Create();
            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                jsonSerializer.Serialize(jsonWriter, value);
                writer.WriteRawValue(stringWriter.ToString());
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonSerializer = NetTopologySuite.IO.GeoJsonSerializer.Create();

            return jsonSerializer.Deserialize<NetTopologySuite.Geometries.Point>(reader);
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(string).IsAssignableFrom(objectType);
        }
    }
}
