using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace ChAvTicks.Application.UrlConverter
{
    public static class UrlConverter
    {
        public static string ConvertToQueryParams<T>(this T requestParamsModel) where T : class
        {
            if (typeof(T).GetCustomAttributes(typeof(UrlConvertibleAttribute), false).Length > 0)
            {
                var properties = requestParamsModel.GetType().GetProperties()
                    .Where(x => x.GetValue(requestParamsModel, null) is not null
                    && x.CustomAttributes.Any(_ => _.AttributeType.Name == nameof(FromQueryAttribute)))
                    .Select(x => x.Name + "=" + HttpUtility.UrlEncode(x.GetValue(requestParamsModel, null)!.ToString()));

                return string.Join("&", properties.ToArray()).Replace("%3a", ":");
            }

            return string.Empty;
        }
    }
}
