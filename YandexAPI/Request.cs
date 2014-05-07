using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace YandexAPI
{
    public class Request
    {
        private Stream _responseStream;

        public Stream POST( string url, string command )
        {
            _responseStream = ResponseStreamPost( url, command );
            return _responseStream;
        }

        public Stream POST( string url, string command, WebProxy proxy )
        {
            _responseStream = ResponseStreamPost( url, command, proxy );
            return _responseStream;
        }

        public Stream GET( string url )
        {
            _responseStream = ResponseStreamGet( url );
            return _responseStream;
        }

        public Stream GET( string url, WebProxy proxy )
        {
            _responseStream = ResponseStreamGet( url, proxy );
            return _responseStream;
        }

        public XDocument GetResponseToXDocument( Stream requestMetod )
        {
            XmlReader xmlReader = XmlReader.Create( requestMetod );
            return XDocument.Load( xmlReader );
        }

        public string GetResponseToString( Stream requestMetod )
        {
            using( StreamReader responseStreamReader = new StreamReader( requestMetod ) )
            {
                return responseStreamReader.ReadToEnd();
            }
        }

        private Stream ResponseStreamGet( string url, WebProxy proxy = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create( url );
            if( proxy != null )
            {
                request.Proxy = proxy;
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responsestream = response.GetResponseStream();
            return responsestream;
        }

        private Stream ResponseStreamPost( string url, string command, WebProxy proxy = null)
        {
            byte[] bytes = Encoding.UTF8.GetBytes( command );
            HttpRequestCachePolicy policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            HttpWebRequest.DefaultCachePolicy = policy;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create( url );
            request.Method = "POST";
            request.ContentLength = bytes.Length;
            request.ContentType = "text/xml";
            if( proxy != null )
            {
                request.Proxy = proxy;
            }
            using( Stream requestStream = request.GetRequestStream() )
            {
                requestStream.Write( bytes, 0, bytes.Length );
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responsestream = response.GetResponseStream();
            return responsestream;
        }
    }
}
