using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace INF2course
{
    public static class HttpContextExtensions
    {
        public static Dictionary<string, string> GetBodyData(this HttpListenerContext context)
        {
            var request = context.Request;
            if (!request.HasEntityBody)
            {
                return null;
            }

            Stream body = request.InputStream;
            Encoding encoding = request.ContentEncoding;
            StreamReader reader = new StreamReader(body, encoding);

            var data = HttpUtility.ParseQueryString(reader.ReadToEnd());
            body.Close();
            reader.Close();

            var dataDict = data.ToDictionary();
            return dataDict;
        }

    }
}
