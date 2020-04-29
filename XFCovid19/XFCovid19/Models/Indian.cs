namespace XFCovid19.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Globalization;

    public partial class Indian
    {
        [JsonProperty("cases_time_series")]
        public CasesTimeSery[] CasesTimeSeries { get; set; }

        [JsonProperty("statewise")]
        public Statewise[] Statewise { get; set; }

        [JsonProperty("tested")]
        public Tested[] Tested { get; set; }
    }

    public partial class CasesTimeSery
    {
        [JsonProperty("dailyconfirmed")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Dailyconfirmed { get; set; }

        [JsonProperty("dailydeceased")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Dailydeceased { get; set; }

        [JsonProperty("dailyrecovered")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Dailyrecovered { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("totalconfirmed")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Totalconfirmed { get; set; }

        [JsonProperty("totaldeceased")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Totaldeceased { get; set; }

        [JsonProperty("totalrecovered")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Totalrecovered { get; set; }
    }

    public partial class Statewise
    {
        [JsonProperty("active")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Active { get; set; }

        [JsonProperty("confirmed")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Confirmed { get; set; }

        [JsonProperty("deaths")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Deaths { get; set; }

        [JsonProperty("deltaconfirmed")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Deltaconfirmed { get; set; }

        [JsonProperty("deltadeaths")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Deltadeaths { get; set; }

        [JsonProperty("deltarecovered")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Deltarecovered { get; set; }

        [JsonProperty("lastupdatedtime")]
        public string Lastupdatedtime { get; set; }

        [JsonProperty("recovered")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Recovered { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("statecode")]
        public string Statecode { get; set; }

        [JsonProperty("statenotes")]
        public string Statenotes { get; set; }
    }

    public partial class Tested
    {
        [JsonProperty("individualstestedperconfirmedcase")]
        public string Individualstestedperconfirmedcase { get; set; }

        [JsonProperty("positivecasesfromsamplesreported")]
        public string Positivecasesfromsamplesreported { get; set; }

        [JsonProperty("samplereportedtoday")]
        public string Samplereportedtoday { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("testpositivityrate")]
        public string Testpositivityrate { get; set; }

        [JsonProperty("testsconductedbyprivatelabs")]
        public string Testsconductedbyprivatelabs { get; set; }

        [JsonProperty("testsperconfirmedcase")]
        public string Testsperconfirmedcase { get; set; }

        [JsonProperty("totalindividualstested")]
        public string Totalindividualstested { get; set; }

        [JsonProperty("totalpositivecases")]
        public string Totalpositivecases { get; set; }

        [JsonProperty("totalsamplestested")]
        public string Totalsamplestested { get; set; }

        [JsonProperty("updatetimestamp")]
        public string Updatetimestamp { get; set; }
    }

    public enum SamplereportedtodayEnum { Empty, The15583 };

    public partial struct SamplereportedtodayUnion
    {
        public SamplereportedtodayEnum? Enum;
        public long? Integer;

        public static implicit operator SamplereportedtodayUnion(SamplereportedtodayEnum Enum) => new SamplereportedtodayUnion { Enum = Enum };

        public static implicit operator SamplereportedtodayUnion(long Integer) => new SamplereportedtodayUnion { Integer = Integer };
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                SamplereportedtodayUnionConverter.Singleton,
                SamplereportedtodayEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class SamplereportedtodayUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SamplereportedtodayUnion) || t == typeof(SamplereportedtodayUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    switch (stringValue)
                    {
                        case "":
                            return new SamplereportedtodayUnion { Enum = SamplereportedtodayEnum.Empty };

                        case "15,583":
                            return new SamplereportedtodayUnion { Enum = SamplereportedtodayEnum.The15583 };
                    }
                    long l;
                    if (Int64.TryParse(stringValue, out l))
                    {
                        return new SamplereportedtodayUnion { Integer = l };
                    }
                    break;
            }
            throw new Exception("Cannot unmarshal type SamplereportedtodayUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (SamplereportedtodayUnion)untypedValue;
            if (value.Enum != null)
            {
                switch (value.Enum)
                {
                    case SamplereportedtodayEnum.Empty:
                        serializer.Serialize(writer, "");
                        return;

                    case SamplereportedtodayEnum.The15583:
                        serializer.Serialize(writer, "15,583");
                        return;
                }
            }
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value.ToString());
                return;
            }
            throw new Exception("Cannot marshal type SamplereportedtodayUnion");
        }

        public static readonly SamplereportedtodayUnionConverter Singleton = new SamplereportedtodayUnionConverter();
    }

    internal class SamplereportedtodayEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SamplereportedtodayEnum) || t == typeof(SamplereportedtodayEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return SamplereportedtodayEnum.Empty;

                case "15,583":
                    return SamplereportedtodayEnum.The15583;
            }
            throw new Exception("Cannot unmarshal type SamplereportedtodayEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SamplereportedtodayEnum)untypedValue;
            switch (value)
            {
                case SamplereportedtodayEnum.Empty:
                    serializer.Serialize(writer, "");
                    return;

                case SamplereportedtodayEnum.The15583:
                    serializer.Serialize(writer, "15,583");
                    return;
            }
            throw new Exception("Cannot marshal type SamplereportedtodayEnum");
        }

        public static readonly SamplereportedtodayEnumConverter Singleton = new SamplereportedtodayEnumConverter();
    }
}