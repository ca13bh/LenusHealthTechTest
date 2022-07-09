namespace LenusHealthTechTest.Entities.Enum
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortByValues
    {
        Title,

        Author,

        Price,
    }
}
