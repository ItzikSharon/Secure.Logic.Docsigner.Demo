using Newtonsoft.Json;

namespace com.slg.docsigner.demo
{
    public class ToStringHelper {

        /// <summary>
        /// Prints JSON Messages
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonObject"></param>
        /// <returns></returns>
        public static string JSONToString<T>(object jsonObject)
        {
            if (jsonObject == null){
                return "Null Value";
            }
            string objectAsJson = JsonConvert.SerializeObject(jsonObject);
            return objectAsJson;
        }
    }

    /// <summary>
    /// This is the API connection settings
    /// </summary>
    public class APISettings {

        public string BaseURL { get; set; } = string.Empty;
        public string APIID { get; set; } = string.Empty;
        public string APIKey { get; set; } = string.Empty;
    }

}
