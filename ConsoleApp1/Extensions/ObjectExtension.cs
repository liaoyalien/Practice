using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ERPWebSite.Common.Extensions
{
    public static class ObjectExtension
    {
        public static string GetJsonString(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            return JsonConvert.SerializeObject(obj);
        }

        public static T JsonConvertToModel<T>(this string jsonText)
        {
            if (string.IsNullOrWhiteSpace(jsonText))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(jsonText);
        }
    }
}
