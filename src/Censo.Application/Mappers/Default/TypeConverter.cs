using Newtonsoft.Json;

namespace Censo.Application.Mappers.Default
{
    public static class TypeConverter
    {
        public static T ConvertTo<T>(object value)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(value));
        }
    }
}
