/*
 *  
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Security.Policy;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace YandexAPI
{
    public class Request
    {
       
        public static string Get(string url, WebProxy proxy = null)
        {
            return ResponseToStringGet(url, proxy);
        }

        public static string Post(string url, string command, WebProxy proxy = null)
        {
            return ResponseToStringPost(url, command, proxy);
        }

        private static string ResponseToStringGet(string url, WebProxy proxy = null)
        {
            string result = String.Empty;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.KeepAlive = false;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:24.0) Gecko/20100101 Firefox/24.0";
            if (proxy != null) request.Proxy = proxy;
            using (var resp = (HttpWebResponse)request.GetResponse())
            {
                var respStream = new StreamReader(resp.GetResponseStream());
                result = respStream.ReadToEnd();
                resp.Close();
                respStream.Close();
            }
            return result;
        }


        private static string ResponseToStringPost(string url, string command, WebProxy proxy = null)
        {
            string result = String.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpRequestCachePolicy policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            HttpWebRequest.DefaultCachePolicy = policy;
            request.Method = "POST";
            request.KeepAlive = false;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:24.0) Gecko/20100101 Firefox/24.0";
            byte[] bytes = Encoding.UTF8.GetBytes(command);
            request.ContentLength = bytes.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            if (proxy != null) request.Proxy = proxy;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                var respStream = new StreamReader(response.GetResponseStream());
                result = respStream.ReadToEnd();
                response.Close();
                respStream.Close();
            }
            return result;
        }

        #region Outdated methods

        private Stream _responseStream;

        [Obsolete("Устаревший метод, лучше использовать Post(string url, string command, WebProxy proxy = null)")]
        public Stream POST(string url, string command)
        {
            _responseStream = ResponseStreamPost(url, command);
            return _responseStream;
        }

        [Obsolete("Устаревший метод, лучше использовать Post(string url, string command, WebProxy proxy = null)")]
        public Stream POST(string url, string command, WebProxy proxy)
        {
            _responseStream = ResponseStreamPost(url, command, proxy);
            return _responseStream;
        }

        [Obsolete("Устаревший метод, лучше использовать Get(string url, WebProxy proxy = null)")]
        public Stream GET(string url)
        {
            _responseStream = ResponseStreamGet(url);
            return _responseStream;
        }

        [Obsolete("Устаревший метод, лучше использовать Get(string url, WebProxy proxy = null)")]
        public Stream GET(string url, WebProxy proxy)
        {
            _responseStream = ResponseStreamGet(url, proxy);
            return _responseStream;
        }

        [Obsolete("Устаревший метод")]
        public string GetResponseToString(Stream requestMetod)
        {
            using (StreamReader responseStreamReader = new StreamReader(requestMetod))
            {
                return responseStreamReader.ReadToEnd();
            }
        }

        private Stream ResponseStreamGet(string url, WebProxy proxy = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            if (proxy != null)
            {
                request.Proxy = proxy;
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responsestream = response.GetResponseStream();
            return responsestream;
        }

        private Stream ResponseStreamPost(string url, string command, WebProxy proxy = null)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(command);
            HttpRequestCachePolicy policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            HttpWebRequest.DefaultCachePolicy = policy;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = bytes.Length;
            request.ContentType = "text/xml";
            if (proxy != null)
            {
                request.Proxy = proxy;
            }
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responsestream = response.GetResponseStream();
            return responsestream;
        }

        #endregion
    }
}
