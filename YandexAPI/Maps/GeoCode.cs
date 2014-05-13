using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Security.Policy;
using System.Text;
using System.Xml;

namespace YandexAPI.Maps
{
    public class GeoCode
    {

        private static string _uri = "http://geocode-maps.yandex.ru/1.x/?geocode={0}&results=1";

        /// <summary>
        /// Определяем координаты объекта
        /// </summary>
        /// <param name="address">Адрес объекта</param>
        /// <returns>Ответ в формате XML. YMapsML</returns>
        public static string SearchObject(string address)
        {
            string urlXml = String.Format(_uri, address);
            string result = Request.Get(urlXml);
            return result;
        }

        /// <summary>
        /// Поиск объекта по координатам
        /// </summary>
        /// <param name="latitude">Широта</param>
        /// <param name="longitude">Долгота</param>
        /// <returns>Ответ в формате XML. YMapsML</returns>
        public static string SearchObject(double latitude, double longitude)
        {
            string urlXml = String.Format(_uri, String.Format("{0},{1}", latitude.ToString(CultureInfo.InvariantCulture).Replace(",", "."), longitude.ToString(CultureInfo.InvariantCulture).Replace(",", ".")));
            string result = Request.Get(urlXml);
            return result;
        }

        /// <summary>
        /// Возвращает URL на статический рисунок карты с точкой поиска в центре
        /// </summary>
        /// <param name="resultSearchObject">XML резудьтат поиска</param>
        /// <param name="zPosition">Может быть от 1 до 17</param>
        /// <param name="width">Ширина. Может быть от 1 до 650</param>
        /// <param name="height">Высота. Может быть от 1 до 450</param>
        /// <returns>Url на Image</returns>
        public static string GetUrlMapImage(string resultSearchObject, int zPosition, int width, int height)
        {
            string point = GetPoint(resultSearchObject);
            return String.Format("http://static-maps.yandex.ru/1.x/?ll={0}&size={1},{2}&z={3}&l=map&pt={0},pm2lbm&lang=ru-RU", point, width, height, zPosition);
        }

        public static string GetPoint(string resultSearchObject)
        {
            string point = String.Empty;
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(resultSearchObject);
            XmlNodeList geoObjectTemp = xd.GetElementsByTagName("GeoObject");
            foreach (XmlNode node in geoObjectTemp)
            {
                foreach (XmlNode item in node.ChildNodes)
                {
                    if (item.Name == "Point")
                    {
                        point = item.LastChild.InnerXml.Replace(' ', ',');
                    }
                }
                break;
            }
            return point;
        }

        public static PointD GetPointD(string resultSearchObject)
        {
            PointD result = new PointD(GetPoint(resultSearchObject));
            return result;
        }

        /// <summary>
        /// Метод для скачивания Image из интернета
        /// </summary>
        /// <param name="uri">URL скачиваемой Image</param>
        /// <returns>Возвращаем объект Image</returns>
        public static Image DownloadMapImage(string uri)
        {
            return DownloadMapImage(uri, null);
        }

        /// <summary>
        /// Метод для скачивания Image из интернета
        /// </summary>
        /// <param name="uri">URL скачиваемой Image</param>
        /// <param name="proxy">Передаем Proxy для подключения</param>
        /// <returns>Возвращаем объект Image</returns>
        public static Image DownloadMapImage(string uri, WebProxy proxy)
        {
            Image tmpImage = null;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            if (proxy != null)
            {
                httpWebRequest.Proxy = proxy;
            }
            httpWebRequest.AllowWriteStreamBuffering = true;
            httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
            httpWebRequest.Referer = "http://www.google.com/";
            httpWebRequest.Timeout = 20000;
            using (WebResponse webResponse = httpWebRequest.GetResponse())
            {
                using (System.IO.Stream webStream = webResponse.GetResponseStream())
                {
                    if (webStream != null) tmpImage = Image.FromStream(webStream);
                }
            }
            return tmpImage;
        }
    }
}
