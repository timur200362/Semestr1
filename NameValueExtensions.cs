using System.Collections.Generic;
using System.Collections.Specialized;
namespace INF2course
{
    public static class NameValueExtensions
    {
        public static Dictionary<string, string> ToDictionary(this NameValueCollection @this)
        {
            var dict = new Dictionary<string, string>();

            if (@this != null)
            {
                foreach (string key in @this.AllKeys)
                {
                    dict.Add(key, @this[key]);
                }
            }

            return dict;
        }
    }
}
