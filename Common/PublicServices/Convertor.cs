using System;
using System.Text.Json;

namespace Common.PublicServices
{
    public static class Convertor
    {
        public static string ToJsonn<T>(T tObject)
        {
            return JsonSerializer.Serialize(tObject);
        }
        public static T ToModel<T>(string JsonString)
        {
            return JsonSerializer.Deserialize<T>(JsonString);
        }
        public static void GetPersianDate(DateTime GregorianDate)
        {


        }
    }
}
