using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
namespace WebAPI.Common
{
    public static class Util
    {
        public class IpAddress
        {
            public string country
            {
                get;
                set;
            }
        }
        public static string getBrowser()
        {
            HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
            int arg_16_0 = browser.ScreenPixelsWidth;
            string arg_4D_0 = (browser.IsMobileDevice ? "From Mobile" : "From PC") + " " + browser.Browser.ToString();
            string str = browser.Version.ToString();
            return arg_4D_0 + str;
        }
        public static string getIP()
        {
            string text = string.Empty;
            text = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (text == null || text == string.Empty)
            {
                text = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (text == null || text == string.Empty)
            {
                text = HttpContext.Current.Request.UserHostAddress;
            }
            if (text == null || text == string.Empty)
            {
                return "0.0.0.0";
            }
            return text;
        }
        public static string Ip2Country(string ip)
        {
            string result;
            try
            {
                string input = Util.Get("http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=js&ip=" + ip, 10000).Split(new char[]
                {
                    '='
                })[1].Trim(new char[]
                {
                    ';'
                }).Trim();
                result = new JavaScriptSerializer().Deserialize<Util.IpAddress>(input).country;
            }
            catch
            {
                result = "ERROR";
            }
            return result;
        }
        public static string Get(string url, int time = 60000)
        {
            HttpWebRequest expr_10 = WebRequest.Create(new Uri(url)) as HttpWebRequest;
            expr_10.Method = "GET";
            expr_10.ContentType = "application/json;charset=utf-8";
            expr_10.Timeout = time;
            string result = "";
            using (HttpWebResponse httpWebResponse = expr_10.GetResponse() as HttpWebResponse)
            {
                result = new StreamReader(httpWebResponse.GetResponseStream()).ReadToEnd();
            }
            return result;
        }
    }
}
