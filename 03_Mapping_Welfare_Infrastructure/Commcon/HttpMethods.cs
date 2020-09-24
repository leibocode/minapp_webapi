using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace _03_Mapping_Welfare_Infrastructure.Commcon
{
    /// <summary>
    /// http方法
    /// </summary>
    public class HttpMethods
    {
        public static HttpClient CreateHttpClient(string url,IDictionary<string,string> cookies = null)
        {
            throw new Exception();
        }
    }
}
