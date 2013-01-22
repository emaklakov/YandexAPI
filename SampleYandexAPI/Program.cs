using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YandexAPI;

namespace SampleYandexAPI
{
    class Program
    {
        static void Main( string[] args )
        {
            #region GET Request
            string urlXml = "http://geocode-maps.yandex.ru/1.x/?geocode=" + "Алматы" + "&results=1";

            YandexAPI.Request request = new YandexAPI.Request();

            Console.WriteLine( request.GetResponseToString( request.GET( urlXml ) ) );
            Console.ReadLine();

            #endregion GET Request
        }
    }
}
