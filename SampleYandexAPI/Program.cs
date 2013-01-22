using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YandexAPI;
using YandexAPI.Maps;

namespace SampleYandexAPI
{
    class Program
    {
        static void Main( string[] args )
        {
            #region GET Request

            //string urlXml = "http://geocode-maps.yandex.ru/1.x/?geocode=" + "76.912335,43.280810" + "&results=1";

            //YandexAPI.Request request = new YandexAPI.Request();

            //string result = request.GetResponseToString(request.GET(urlXml));

            //Console.WriteLine( result );
            //Console.ReadLine();

            #endregion GET Request

            #region Search Object

            //YandexAPI.Maps.GeoCode geoCode = new GeoCode();

            //string result = geoCode.SearchObject( "Алматы, ул.Айтиева, 42" ); // 76.904529 43.254999

            //string result = geoCode.SearchObject( 76.904529, 43.254999 );
            
            //Console.WriteLine( result );
            //Console.ReadLine();

            #endregion Search Object

            #region Get Url Map Image

            //YandexAPI.Maps.GeoCode geoCode = new GeoCode();

            //string ResultSearchObject = geoCode.SearchObject( "Алматы, ул.Айтиева, 42" );
            //string result = geoCode.GetUrlMapImage(ResultSearchObject, 16, 650, 450);

            //Console.WriteLine( result );
            //Console.ReadLine();

            #endregion Get Url Map Image

            #region Get Point

            //YandexAPI.Maps.GeoCode geoCode = new GeoCode();

            //string ResultSearchObject = geoCode.SearchObject( "Алматы, ул.Айтиева, 42" );
            //string result = geoCode.GetPoint(ResultSearchObject);

            //Console.WriteLine( result );
            //Console.ReadLine();

            #endregion Get Point
        }
    }
}
