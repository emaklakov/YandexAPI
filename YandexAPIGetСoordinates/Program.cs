/*
 * Autor: Zyshchyk Makism
 * Email: amporioo@gmail.com
 * Date: 11.05.2014
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexAPI.Maps;
using YandexMap = YandexAPI.Request;

namespace YandexAPIGetСoordinates
{
    class Program
    {
        static void Main(string[] args)
        {
            const string url = "http://geocode-maps.yandex.ru/1.x/?geocode=" + "Беларусь, Минск ул.Немига, 3" + "&results=1";
            Console.WriteLine("Прямое геокодирование API Яндекс.Карт");
            string result = YandexMap.Get(url);
            PointD pointD = GeoCode.GetPointD(result);
            string address = GeoCode.SearchObject(76.904529, 43.254999);
            Console.WriteLine(pointD);
            Console.ReadKey(true);
        }
    }
}
