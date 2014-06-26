using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Win32.SafeHandles;

namespace YandexAPI.Maps
{
    public class PolygonMap
    {
        private string _Id;
        private PointD[] _Points;

        public PolygonMap()
        {
        }
        
        public PolygonMap( string Id )
        {
            _Id = Id;
        }

        public PolygonMap( string Id, PointD[] Points )
        {
            _Id = Id;
            _Points = Points;
        }

        /// <summary>
        /// Алгоритмом поиска принадлежности точки полигону на двухмерной плоскости
        /// </summary>
        /// <param name="PolygonPoints">Массив точек полигона</param>
        /// <param name="MainPoint">Точка проверки</param>
        /// <returns>Результат принадлежности к полигону</returns>
        public bool IsInPolygon( PointD MainPoint )
        {
            bool result = false;

            for( int i = 0, j = Points.Length - 1; i < Points.Length; j = i++ )
            {
                if( Points[i].Y < MainPoint.Y && Points[j].Y >= MainPoint.Y ||
                    Points[j].Y < MainPoint.Y && Points[i].Y >= MainPoint.Y )
                {
                    if( Points[i].X + ( MainPoint.Y - Points[i].Y ) /
                      ( Points[j].Y - Points[i].Y ) *
                      ( Points[j].X - Points[i].X ) < MainPoint.X )
                    {
                        result = !result;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Получаем точки полигона из строки с координатами
        /// </summary>
        /// <param name="StringPoints">Строка с координатами</param>
        /// <returns>Возвращает массив точек</returns>
        public static PointD[] GetPointsFromString(string StringPoints)
        {
            string[] coordinates = StringPoints.Split(new char[] {' '});

            PointD[] result = new PointD[coordinates.Length/2];

            int j = 0;
            for( int i = 0; i < coordinates.Length;  i = i+2 )
            {
                PointD point = new PointD();
                point.X = Double.Parse( coordinates[i], new CultureInfo( "en-GB" ) );
                point.Y = Double.Parse( coordinates[i + 1], new CultureInfo( "en-GB" ) );

                result[j] = point;

                if( j >= result.Length )
                    break;

                j++;
            }

            return result;
        }

        public static List<PolygonMap> GetPolygonsOnMap(string ResultKML)
        {
            List<PolygonMap> Polygons = new List<PolygonMap>();

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(ResultKML);

            XmlNode kml = xd.DocumentElement;

            XmlNodeList GeoObjectTemp = xd.GetElementsByTagName("Folder");

            foreach (XmlNode node in GeoObjectTemp)
            {
                foreach (XmlNode item in node.ChildNodes)
                {
                    
                    if (item.Name == "Placemark")
                    {
                        PolygonMap Polygon = new PolygonMap();
                        bool IsPolygon = false;

                        foreach (XmlNode PlacemarkItems in item.ChildNodes)
                        {
                            if (PlacemarkItems.Name == "description")
                            {
                                IsPolygon = (PlacemarkItems.InnerXml.Trim() == "Polygon");
                            }
                            else if (PlacemarkItems.Name == "name")
                            {
                                Polygon.Id = PlacemarkItems.InnerXml;
                            }
                            else if (PlacemarkItems.Name == "LinearRing")
                            {
                                Polygon.Points = PolygonMap.GetPointsFromString(item.LastChild["coordinates"].InnerXml.Replace(',', ' '));
                            }
                        }
                        
                        if (IsPolygon)
                        {
                            Polygons.Add(Polygon);    
                        }
                    }
                }

                
            }

            return Polygons;
        }

        /// <summary>
        /// Возвращаем Id полигона, которому пренадлежит точка
        /// </summary>
        /// <param name="Polygons">Полигоны, которых нужно искать точку</param>
        /// <param name="MainPoint">Точка для проверки</param>
        /// <returns>Возвращает Id полигона</returns>
        public static string GetIdPolygonOwnerPoint(IEnumerable<PolygonMap> Polygons, PointD MainPoint)
        {
            foreach (var polygonMap in Polygons)
            {
                if( polygonMap.IsInPolygon( MainPoint ) )
                {
                    return polygonMap.Id;
                }
            }

            return null;
        }

        /// <summary>
        /// Id полигона
        /// </summary>
        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        /// <summary>
        /// Точки полигона
        /// </summary>
        public PointD[] Points
        {
            get { return _Points; }
            set { _Points = value; }
        }

        public override string ToString()
        {
            string result = "";

            foreach (PointD pointD in _Points)
            {
                result += String.Format("{0} {1} ", pointD.X.ToString(), pointD.Y.ToString());
            }

            return result.Trim();
        }
    }
}
