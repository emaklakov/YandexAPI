using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public string SearchObject( double Latitude, double Longitude )
        {
            string urlXml = "http://geocode-maps.yandex.ru/1.x/?geocode=" + String.Format( "{0},{1}", Latitude.ToString().Replace( ",", "." ), Longitude.ToString().Replace( ",", "." ) ) + "&results=1";
            YandexAPI.Request request = new YandexAPI.Request();
            string result = request.GetResponseToString( request.GET( urlXml ) );
            return result;
        }
    }
}
