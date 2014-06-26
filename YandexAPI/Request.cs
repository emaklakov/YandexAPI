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
        private Stream responseStream;

        public Stream POST( string Url, string Command )
        {
            responseStream = ResponseStreamPOST( Url, Command );
            return responseStream;
        }

        public Stream POST( string Url, string Command, WebProxy Proxy )
        {
            responseStream = ResponseStreamPOST( Url, Command, Proxy );
            return responseStream;
        }

        public Stream GET( string Url )
        {
            responseStream = ResponseStreamGET( Url );
            return responseStream;
        }

        public Stream GET( string Url, WebProxy Proxy )
        {
            responseStream = ResponseStreamGET( Url, Proxy );
            return responseStream;
        }

        public XDocument GetResponseToXDocument( Stream RequestMetod )
        {
            XmlReader xmlReader = XmlReader.Create( RequestMetod );
            return XDocument.Load( xmlReader );
        }

        public string GetResponseToString( Stream RequestMetod )
        {
            using( StreamReader ResponseStreamReader = new StreamReader( RequestMetod ) )
            {
                return ResponseStreamReader.ReadToEnd();
            }
        }

        private Stream ResponseStreamGET( string Url )
        {
            return ResponseStreamGET(Url, null);
        }

        private Stream ResponseStreamGET( string Url, WebProxy Proxy )
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create( Url );

            if( Proxy != null )
            {
                request.Proxy = Proxy;
            }

            //Получение ответа.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responsestream = response.GetResponseStream();
            return responsestream;
        }

        private Stream ResponseStreamPOST( string Url, string Command )
        {
            return ResponseStreamPOST(Url, Command, null);
        }

        private Stream ResponseStreamPOST( string Url, string Command, WebProxy Proxy )
        {
            byte[] bytes = Encoding.UTF8.GetBytes( Command );

            // Объект, с помощью которого будем отсылать запрос и получать ответ.
            HttpRequestCachePolicy policy = new HttpRequestCachePolicy( HttpRequestCacheLevel.NoCacheNoStore );
            HttpWebRequest.DefaultCachePolicy = policy;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create( Url );

            request.Method = "POST";
            request.ContentLength = bytes.Length;
            request.ContentType = "text/xml";

            if( Proxy != null )
            {
                request.Proxy = Proxy;
            }

            // Пишем наш XML-запрос в поток
            using( Stream requestStream = request.GetRequestStream() )
            {
                requestStream.Write( bytes, 0, bytes.Length );
            }

            // Получаем ответ
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responsestream = response.GetResponseStream();
            return responsestream;
        }
    }
}
