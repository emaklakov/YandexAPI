using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YandexAPI;
using YandexAPI.Maps;

namespace SampleYandexAPI
{
    class Program
    {
        [STAThread()]
        static void Main( string[] args )
        {
            #region GET Request

            //string urlXml = "http://geocode-maps.yandex.ru/1.x/?geocode=" + "76.912335,43.280810" + "&results=1";

            //YandexAPI.Request request = new YandexAPI.Request();
            //79.134.7.86:3128

            //string result = request.GetResponseToString( request.GET( urlXml ) );

            //Use Proxy
            //var Proxy = new WebProxy( "199.91.172.25", 3128 );
            //Proxy.Credentials = CredentialCache.DefaultCredentials; //Получаем системные учетные данные
            //string result = request.GetResponseToString( request.GET( urlXml, Proxy ) );

            //Console.WriteLine( result );
            //Console.ReadLine();

            #endregion GET Request

            #region Search Object

            //YandexAPI.Maps.GeoCode geoCode = new GeoCode();

            //string result = geoCode.SearchObject( "Алматы, ул.Айтиева, 42" ); // 76.904529 43.254999

            //string ResultSearchObject = geoCode.SearchObject( 76.904529, 43.254999 );

            //string Address = geoCode.GetAddress(ResultSearchObject);

            //Console.WriteLine( result );
            //Console.WriteLine(Address);
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

            #region Download Map Image

            //YandexAPI.Maps.GeoCode geoCode = new GeoCode();

            //string ResultSearchObject = geoCode.SearchObject( "Алматы, ул.Айтиева, 42" );
            //string ImageUrl = geoCode.GetUrlMapImage( ResultSearchObject, 16, 650, 450 );
            //Image result = geoCode.DownloadMapImage(ImageUrl);

            ////Use Proxy
            //var Proxy = new WebProxy("localhost", 8080);
            //Proxy.Credentials = CredentialCache.DefaultCredentials; //Получаем системные учетные данные
            //Image result = geoCode.DownloadMapImage(ImageUrl, Proxy);

            //Console.WriteLine("OK");

            #endregion

            #region IsInPolygon

            //YandexAPI.Maps.GeoCode geoCode = new GeoCode();

            //string ResultSearchObject = geoCode.SearchObject( "Алматы, ул.Айтиева, 42" );
            //PointD MainPoint = geoCode.GetPointD( ResultSearchObject );
            //PointD MainPoint = new PointD( "76.9113710185236, 43.254288472262346" );

            //// False
            //PointD[] Points = new PointD[] { new PointD( 76.91874334111112, 43.25301084554285 ), 
            //                                 new PointD( 76.9328624893655, 43.25401462895744 ), 
            //                                 new PointD( 76.93333455815213, 43.25046994430479 ), 
            //                                 new PointD( 76.94032975926298, 43.2510345982507 ), 
            //                                 new PointD( 76.94127389683624, 43.24203087665198 ), 
            //                                 new PointD( 76.93093129887478, 43.24121514228232 ), 
            //                                 new PointD( 76.93041631474394, 43.245168214021774 ), 
            //                                 new PointD( 76.92346402897735, 43.244760369365515 ), 
            //                                 new PointD( 76.92376443638703, 43.24278385246077 ), 
            //                                 new PointD( 76.91629716648956, 43.242532861565905 ), 
            //                                 new PointD( 76.91492387547393, 43.25275989708564 ), 
            //                                 new PointD( 76.91874334111112, 43.25301084554285 ) };

            //// True
            //PointD[] Points = new PointD[] { new PointD( 76.90175091173897, 43.25658413329047 ), 
            //                                 new PointD( 76.91089188006175, 43.2575251251192 ), 
            //                                 new PointD( 76.91127811815986, 43.25423158964632 ), 
            //                                 new PointD( 76.91638504412424, 43.25451389971651  ), 
            //                                 new PointD( 76.91629921343578, 43.25369833369539 ), 
            //                                 new PointD( 76.9159988060261, 43.252820019524655 ), 
            //                                 new PointD( 76.91144977953685, 43.25250633280052 ), 
            //                                 new PointD( 76.90239464190255, 43.25181621627961  ), 
            //                                 new PointD( 76.90175091173897, 43.25658413329047 ) };

            //// True
            //PointD[] Points = new PointD[] { new PointD( 76.90175091173897, 43.25658413329047 ), 
            //                                 new PointD( 76.91089188006175, 43.2575251251192 ), 
            //                                 new PointD( 76.91127811815986, 43.25423158964632 ), 
            //                                 new PointD( 76.91638504412424, 43.25451389971651  ), 
            //                                 new PointD( 76.91629921343578, 43.25369833369539 ), 
            //                                 new PointD( 76.9159988060261, 43.252820019524655 ), 
            //                                 new PointD( 76.91144977953685, 43.25250633280052 ), 
            //                                 new PointD( 76.90239464190255, 43.25181621627961  ), 
            //                                 new PointD( 76.90175091173897, 43.25658413329047 ) };

            //PointD[] Points = PolygonMap.GetPointsFromString(
            //        "76.90175091173897 43.25658413329047 76.91089188006175 43.2575251251192 76.91127811815986 43.25423158964632 76.91638504412424 43.25451389971651 76.91629921343578 43.25369833369539 76.9159988060261 43.252820019524655 76.91144977953685 43.25250633280052 76.90239464190255 43.25181621627961 76.90175091173897 43.25658413329047" );


            //PolygonMap polygon = new PolygonMap("1", Points );

            //bool result = polygon.IsInPolygon( MainPoint );

            //Console.WriteLine( result.ToString() );
            //Console.ReadLine();

            #endregion IsInPolygon

            #region GetPolygonFromKML

            //YandexAPI.Maps.GeoCode geoCode = new GeoCode();

            /*
             При создании полигона в описание полигона надо написать: Polygon 
             */

            //string ResultKML = geoCode.GetKML("http://maps.yandex.ru/export/usermaps/CWF_KCyzzmrChLts1Szs3E2hHh8m-iiB.kml");

            //List<PolygonMap> polygons = PolygonMap.GetPolygonsOnMap(ResultKML);

            //PointD MainPoint = new PointD(76.90679583201461, 43.2556333183541);

            //string result = PolygonMap.GetIdPolygonOwnerPoint(polygons, MainPoint);

            #endregion GetPolygonFromYMapsML

            #region GetIdPolygonOwnerPoint

            //YandexAPI.Maps.GeoCode geoCode = new GeoCode();

            //string ResultSearchObject = geoCode.SearchObject("Алматы, ул.Айтиева, 42");
            //PointD MainPoint = geoCode.GetPointD(ResultSearchObject);

            //// False
            //PointD[] PointsA = new PointD[] { new PointD( 76.91874334111112, 43.25301084554285 ), 
            //                                 new PointD( 76.9328624893655, 43.25401462895744 ), 
            //                                 new PointD( 76.93333455815213, 43.25046994430479 ), 
            //                                 new PointD( 76.94032975926298, 43.2510345982507 ), 
            //                                 new PointD( 76.94127389683624, 43.24203087665198 ), 
            //                                 new PointD( 76.93093129887478, 43.24121514228232 ), 
            //                                 new PointD( 76.93041631474394, 43.245168214021774 ), 
            //                                 new PointD( 76.92346402897735, 43.244760369365515 ), 
            //                                 new PointD( 76.92376443638703, 43.24278385246077 ), 
            //                                 new PointD( 76.91629716648956, 43.242532861565905 ), 
            //                                 new PointD( 76.91492387547393, 43.25275989708564 ), 
            //                                 new PointD( 76.91874334111112, 43.25301084554285 ) };

            //// True
            //PointD[] PointsB = new PointD[] { new PointD( 76.90175091173897, 43.25658413329047 ), 
            //                                 new PointD( 76.91089188006175, 43.2575251251192 ), 
            //                                 new PointD( 76.91127811815986, 43.25423158964632 ), 
            //                                 new PointD( 76.91638504412424, 43.25451389971651  ), 
            //                                 new PointD( 76.91629921343578, 43.25369833369539 ), 
            //                                 new PointD( 76.9159988060261, 43.252820019524655 ), 
            //                                 new PointD( 76.91144977953685, 43.25250633280052 ), 
            //                                 new PointD( 76.90239464190255, 43.25181621627961  ), 
            //                                 new PointD( 76.90175091173897, 43.25658413329047 ) };

            //PointD[] PointsA = PolygonMap.GetPointsFromString(
            //        "76.90175091173897 43.25658413329047 76.91089188006175 43.2575251251192 76.91127811815986 43.25423158964632 76.91638504412424 43.25451389971651 76.91629921343578 43.25369833369539 76.9159988060261 43.252820019524655 76.91144977953685 43.25250633280052 76.90239464190255 43.25181621627961 76.90175091173897 43.25658413329047");

            //PointD[] PointsB = PolygonMap.GetPointsFromString(
            //        "76.90175091173897 43.25658413329047 76.91089188006175 43.2575251251192 76.91127811815986 43.25423158964632 76.91638504412424 43.25451389971651 76.91629921343578 43.25369833369539 76.9159988060261 43.252820019524655 76.91144977953685 43.25250633280052 76.90239464190255 43.25181621627961 76.90175091173897 43.25658413329047");

            //PolygonMap[] polygons = new PolygonMap[] { new PolygonMap("A", PointsA), new PolygonMap("B", PointsB) };

            //string result = PolygonMap.GetIdPolygonOwnerPoint(polygons, MainPoint);

            //Console.WriteLine( result );
            //Console.ReadLine();

            #endregion GetIdPolygonOwnerPoint

            #region ConvertToGPSPoint

            //YandexAPI.Maps.GeoCode geoCode = new GeoCode();

            //string ResultSearchObject = geoCode.SearchObject( "Алматы, ул.Айтиева, 42" );
            //PointD MainPoint = geoCode.GetPointD( ResultSearchObject );

            //PointD pointGPS = PointD.ConvertToGPSPoint(MainPoint);

            #endregion ConvertToGPSPoint

            #region ConvertGPSToYandexPoint

            //PointD MainPoint = new PointD(77.333, 43.927);

            //PointD pointYandex = PointD.ConvertGPSToYandexPoint( MainPoint );

            //string result = String.Format("{0}, {1}", pointYandex.X, pointYandex.Y);

            #endregion ConvertGPSToYandexPoint

            #region Route 

            //PointD[] Dots = new PointD[] { new PointD(76.950127, 43.228284), new PointD(76.944463, 43.270571) };

            //PointD DotA = new PointD(76.950127, 43.228284);
            //PointD DotB = new PointD(76.944463, 43.270571);                             

            //PointD DotA = new PointD(76.950127, 43.228284);
            //PointD DotB = new PointD(76.944463, 43.270571);

            //PointD DotA = new PointD(36.2656938, 50.6912032);
            //PointD DotB = new PointD(36.265112, 50.6916124);

            //Route route = new Route(10);

            //if (route.Load(DotA, DotB))
            //{
            //    string RouteLength = route.RouteLength; // Длина в метрах
            //    string RouteJamsTime = route.RouteJamsTime; // Время проезда в секундах с учетом пробок
            //    string RouteTime = route.RouteTime; // Время проезда в секундах
            //    string RouteHumanLength = route.RouteHumanLength; // Возвращает строковое представление длины маршрута с единицами измерения.
            //    string RouteHumanJamsTime = route.RouteHumanJamsTime; // Возвращает строковое представление времени проезда маршрута с единицами измерения с учетом пробок.
            //    string RouteHumanTime = route.RouteHumanTime; // Возвращает строковое представление времени проезда маршрута с единицами измерения.

            //    Console.WriteLine(RouteLength);
            //    Console.WriteLine(RouteJamsTime);
            //    Console.WriteLine(RouteTime);
            //    Console.WriteLine(RouteHumanLength);
            //    Console.WriteLine(RouteHumanJamsTime);
            //    Console.WriteLine(RouteHumanTime);
            //}  

            //if (route.Load(Dots))
            //{
            //    string RouteLength = route.RouteLength; // Длина в метрах
            //    string RouteJamsTime = route.RouteJamsTime; // Время проезда в секундах с учетом пробок
            //    string RouteTime = route.RouteTime; // Время проезда в секундах
            //    string RouteHumanLength = route.RouteHumanLength; // Возвращает строковое представление длины маршрута с единицами измерения.
            //    string RouteHumanJamsTime = route.RouteHumanJamsTime; // Возвращает строковое представление времени проезда маршрута с единицами измерения с учетом пробок.
            //    string RouteHumanTime = route.RouteHumanTime; // Возвращает строковое представление времени проезда маршрута с единицами измерения.

            //    Console.WriteLine(RouteLength);
            //    Console.WriteLine(RouteJamsTime);
            //    Console.WriteLine(RouteTime);
            //    Console.WriteLine(RouteHumanLength);
            //    Console.WriteLine(RouteHumanJamsTime);
            //    Console.WriteLine(RouteHumanTime);
            //}

            //for (int i = 0; i < 3000; i++)
            //{
            //    PointD DotA = new PointD(36.2656938, 50.6912032);
            //    PointD DotB = new PointD(36.265112, 50.6916124);

            //    if (route.Load(DotA, DotB))
            //    {
            //        Console.WriteLine(route.RouteHumanLength);
            //    }

            //    //Thread.Sleep(300);
            //}

            PointD[][] DotsArray = new PointD[][]
            {
                new PointD[] { new PointD(76.889332, 43.238630), new PointD(76.947697, 43.242520) },
                new PointD[] { new PointD(76.886585, 43.259083), new PointD(76.949757, 43.228337) },
                new PointD[] { new PointD(76.744028, 43.227022), new PointD(76.885493, 43.272172) },
                new PointD[] { new PointD(76.905406, 43.201009), new PointD(76.948149, 43.242437) },
                new PointD[] { new PointD(76.986945, 43.284965), new PointD(76.887724, 43.224739) },
                new PointD[] { new PointD(76.938536, 43.353955), new PointD(77.054408, 43.302073) },
                new PointD[] { new PointD(76.765501, 43.358840), new PointD(76.827128, 43.285146) },
                new PointD[] { new PointD(76.960693, 43.271698), new PointD(77.128407, 43.306433) },
                new PointD[] { new PointD(77.025238, 43.319846), new PointD(77.225567, 43.388616) },
                new PointD[] { new PointD(76.994167, 43.497559), new PointD(77.169864, 43.399362) }
            };

            foreach (PointD[] Dots in DotsArray)
            {
                Thread thread = new Thread(TestThread);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start(Dots);
            }

            Console.WriteLine("END");
            Console.ReadLine();

            #endregion Route
        }

        public static void TestThread(object Dots)
        {
            Route route = new Route(10);
            route = route.Load(Dots as PointD[]);

            if (route != null)
            {
                string RouteLength = route.RouteLength; // Длина в метрах
                string RouteJamsTime = route.RouteJamsTime; // Время проезда в секундах с учетом пробок
                string RouteTime = route.RouteTime; // Время проезда в секундах
                string RouteHumanLength = route.RouteHumanLength; // Возвращает строковое представление длины маршрута с единицами измерения.
                string RouteHumanJamsTime = route.RouteHumanJamsTime; // Возвращает строковое представление времени проезда маршрута с единицами измерения с учетом пробок.
                string RouteHumanTime = route.RouteHumanTime; // Возвращает строковое представление времени проезда маршрута с единицами измерения.

                Console.WriteLine("---------------------------");
                Console.WriteLine(RouteLength);
                Console.WriteLine(RouteJamsTime);
                Console.WriteLine(RouteTime);
                Console.WriteLine(RouteHumanLength);
                Console.WriteLine(RouteHumanJamsTime);
                Console.WriteLine(RouteHumanTime);
                Console.WriteLine("---------------------------");
            }
        }
        
    }
}