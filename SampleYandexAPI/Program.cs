using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using YandexAPI;
using YandexAPI.Maps;

namespace SampleYandexAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            #region GET Request

            string urlXml = "http://geocode-maps.yandex.ru/1.x/?geocode=" + "76.912335,43.280810" + "&results=1";

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

            //string result = GeoCode.SearchObject("Алматы, ул.Айтиева, 42"); // 76.904529 43.254999

            //string result = GeoCode.SearchObject(76.904529, 43.254999);

            //Console.WriteLine( result );
            //Console.ReadLine();

            #endregion Search Object

            #region Get Url Map Image

            //string resultSearchObject = GeoCode.SearchObject("Алматы, ул.Айтиева, 42");
            //string result = GeoCode.GetUrlMapImage(resultSearchObject, 16, 650, 450);
            //Console.WriteLine(result);
            //Console.ReadLine();

            #endregion Get Url Map Image

            #region Get Point

            string resultSearchObject = GeoCode.SearchObject("Алматы, ул.Айтиева, 42");
            string result = GeoCode.GetPoint(resultSearchObject);

            Console.WriteLine(result);
            Console.ReadLine();

            #endregion Get Point

            #region Download Map Image

            //string resultSearchObject = GeoCode.SearchObject("Алматы, ул.Айтиева, 42");
            //string imageUrl = GeoCode.GetUrlMapImage(resultSearchObject, 16, 650, 450);
            //Image result = GeoCode.DownloadMapImage(imageUrl);

            ////Use Proxy
            //var proxy = new WebProxy("localhost", 8080);
            //proxy.Credentials = CredentialCache.DefaultCredentials; //Получаем системные учетные данные
            //Image result = GeoCode.DownloadMapImage(imageUrl, proxy);

            //Console.WriteLine("OK");

            #endregion

            #region IsInPolygon

            //string ResultSearchObject = GeoCode.SearchObject("Алматы, ул.Айтиева, 42");
            //PointD MainPoint = GeoCode.GetPointD(ResultSearchObject);
            //PointD MainPoint = new PointD("76.9113710185236, 43.254288472262346");

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
            //        "76.90175091173897 43.25658413329047 76.91089188006175 43.2575251251192 76.91127811815986 43.25423158964632 76.91638504412424 43.25451389971651 76.91629921343578 43.25369833369539 76.9159988060261 43.252820019524655 76.91144977953685 43.25250633280052 76.90239464190255 43.25181621627961 76.90175091173897 43.25658413329047");


            //PolygonMap polygon = new PolygonMap("1", Points);

            //bool result = polygon.IsInPolygon(MainPoint);

            //Console.WriteLine(result.ToString());
            //Console.ReadLine();

            #endregion IsInPolygon

            #region GetIdPolygonOwnerPoint
            
            //string ResultSearchObject = GeoCode.SearchObject("Алматы, ул.Айтиева, 42");
            //PointD MainPoint = GeoCode.GetPointD(ResultSearchObject);

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

            //PolygonMap[] polygons = new PolygonMap[] { new PolygonMap("A", PointsA), new PolygonMap("B", PointsB) };

            //string result = PolygonMap.GetIdPolygonOwnerPoint(polygons, MainPoint);

            //Console.WriteLine(result);
            //Console.ReadLine();

            #endregion GetIdPolygonOwnerPoint

            #region ConvertToGPSPoint

            //string ResultSearchObject = GeoCode.SearchObject("Алматы, ул.Айтиева, 42");
            //PointD MainPoint = GeoCode.GetPointD(ResultSearchObject);
            //PointD pointGPS = PointD.ConvertToGpsPoint(MainPoint);

            #endregion ConvertToGPSPoint

            #region ConvertGPSToYandexPoint

            //PointD MainPoint = new PointD(77.333, 43.927);

            //PointD pointYandex = PointD.ConvertGpsToYandexPoint(MainPoint);

            //string result = String.Format("{0}, {1}", pointYandex.X, pointYandex.Y);

            #endregion ConvertGPSToYandexPoint
        }
    }
}