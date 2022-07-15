using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace ChAvTicks.Application.UrlConverter
{
    public static class UrlConverter
    {
        public static string ConvertQueryParams<T>(this T request) where T : class
        {
            if (typeof(T).GetCustomAttributes(typeof(UrlConvertibleAttribute), false).Length > 0)
            {
                var properties = request!.GetType().GetProperties()
                    .Where(x => x.GetValue(request, null) is not null)
                    .Where(x => x.CustomAttributes.Any(_ => _.AttributeType.Name == nameof(FromQueryAttribute)))
                    .Select(x => x.Name + "=" + HttpUtility.UrlEncode(x.GetValue(request, null)!.ToString()));

                return string.Join("&", properties.ToArray());
            }

            return string.Empty;
        }
    }
}
