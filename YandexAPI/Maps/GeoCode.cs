using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Xml;

namespace YandexAPI.Maps
{
    public class GeoCode
    {
        /// <summary>
        /// Определяем координаты объекта
        /// </summary>
        /// <param name="Address">Адрес объекта</param>
        /// <returns>Ответ в формате XML. YMapsML</returns>
        public string SearchObject(string Address)
        {
            string urlXml = "http://geocode-maps.yandex.ru/1.x/?geocode=" + Address + "&results=1";
            YandexAPI.Request request = new YandexAPI.Request();
            string result = request.GetResponseToString( request.GET( urlXml ) );
            return result;
        }

        /// <summary>
        /// Поиск объекта по координатам
        /// </summary>
        /// <param name="Latitude">Широта</param>
        /// <param name="Longitude">Долгота</param>
        /// <returns>Ответ в формате XML. YMapsML</returns>
        public string SearchObject(double Latitude, double Longitude)
        {
            string urlXml = "http://geocode-maps.yandex.ru/1.x/?geocode=" + String.Format( "{0},{1}", Latitude.ToString().Replace( ",", "." ), Longitude.ToString().Replace( ",", "." ) ) + "&results=1";
            YandexAPI.Request request = new YandexAPI.Request();
            string result = request.GetResponseToString( request.GET( urlXml ) );
            return result;
        }

        /// <summary>
        /// Получаем найденный адрес
        /// </summary>
        /// <param name="ResultSearchObject">XML резудьтат поиска</param>
        /// <returns>Возвращает адрес</returns>
        public string GetAddress(string ResultSearchObject)
        {
            string Address = "";

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(ResultSearchObject);

            XmlNode ymaps = xd.DocumentElement;

            XmlNodeList GeoObjectTemp = xd.GetElementsByTagName("GeocoderMetaData");

            foreach (XmlNode node in GeoObjectTemp)
            {
                foreach (XmlNode item in node.ChildNodes)
                {
                    if (item.Name == "text")
                    {
                        Address = item.LastChild.InnerText;
                        break;
                    }
                } 
                break;
            }

            return Address;
        }

        public string GetKML(string Url)
        {
            YandexAPI.Request request = new YandexAPI.Request();
            string result = request.GetResponseToString(request.GET(Url));
            return result;    
        }

        public string GetKMLFromFile( string PathFile )
        {
            YandexAPI.Request request = new YandexAPI.Request();
            FileStream kml = new FileStream(PathFile, FileMode.Open);
            string result = request.GetResponseToString(kml);
            return result;
        }

        /// <summary>
        /// Возвращает URL на статический рисунок карты с точкой поиска в центре
        /// </summary>
        /// <param name="ResultSearchObject">XML резудьтат поиска</param>
        /// <param name="zPosition">Может быть от 1 до 17</param>
        /// <param name="Width">Ширина. Может быть от 1 до 650</param>
        /// <param name="Height">Высота. Может быть от 1 до 450</param>
        /// <returns>Url на Image</returns>
        public string GetUrlMapImage( string ResultSearchObject, int zPosition, int Width, int Height )
        {
            string point = GetPoint(ResultSearchObject);

            return String.Format( "http://static-maps.yandex.ru/1.x/?ll={0}&size={1},{2}&z={3}&l=map&pt={0},pm2lbm&lang=ru-RU", point, Width, Height, zPosition );
        }

        public string GetPoint( string ResultSearchObject )
        {
            string point = "";

            XmlDocument xd = new XmlDocument();
            xd.LoadXml( ResultSearchObject );

            XmlNode ymaps = xd.DocumentElement;

            XmlNodeList GeoObjectTemp = xd.GetElementsByTagName( "GeoObject" );

            foreach( XmlNode node in GeoObjectTemp )
            {
                foreach( XmlNode item in node.ChildNodes )
                {
                    if( item.Name == "Point" )
                    {
                        point = item.LastChild.InnerXml.Replace( ' ', ',' );
                    }
                }

                break;
            }

            return point;
        }

        public PointD GetPointD( string ResultSearchObject )
        {
            PointD result = new PointD( GetPoint( ResultSearchObject ) );
            return result;
        }

        /// <summary>
        /// Метод для скачивания Image из интернета
        /// </summary>
        /// <param name="URL">URL скачиваемой Image</param>
        /// <returns>Возвращаем объект Image</returns>
        public Image DownloadMapImage( string Url )
        {
            return DownloadMapImage(Url, null);
        }

        /// <summary>
        /// Метод для скачивания Image из интернета
        /// </summary>
        /// <param name="URL">URL скачиваемой Image</param>
        /// <param name="Proxy">Передаем Proxy для подключения</param>
        /// <returns>Возвращаем объект Image</returns>
        public Image DownloadMapImage(string Url, WebProxy Proxy)
        {
            Image tmpImage = null;

            // Open a connection
            System.Net.HttpWebRequest HttpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create( Url );

            if ( Proxy != null )
            {
                HttpWebRequest.Proxy = Proxy;
            }

            HttpWebRequest.AllowWriteStreamBuffering = true;

            // You can also specify additional header values like the user agent or the referer: (Optional)
            HttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
            HttpWebRequest.Referer = "http://www.google.com/";

            // set timeout for 20 seconds (Optional)
            HttpWebRequest.Timeout = 20000;

            // Request response:
            using( System.Net.WebResponse WebResponse = HttpWebRequest.GetResponse() )
            {
                // Open data stream:
                using( System.IO.Stream WebStream = WebResponse.GetResponseStream() )
                {
                    // convert webstream to image
                    tmpImage = Image.FromStream( WebStream );
                }

                // Cleanup - ?
                //WebResponse.Close();
                //WebResponse.Close();
            }

            return tmpImage;
        }
    }
}
