using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace YandexAPI.Maps
{
    public class PolygonMap
    {
        private string _id;
        private PointD[] _points;

        /// <summary>
        /// Id полигона
        /// </summary>
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Точки полигона
        /// </summary>
        public PointD[] Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public PolygonMap( string id )
        {
            _id = id;
        }

        public PolygonMap( string id, PointD[] points)
        {
            _id = id;
            _points = points;
        }

        /// <summary>
        /// Алгоритмом поиска принадлежности точки полигону на двухмерной плоскости
        /// </summary>
        /// <param name="mainPoint">Точка проверки</param>
        /// <returns>Результат принадлежности к полигону</returns>
        public bool IsInPolygon( PointD mainPoint)
        {
            bool result = false;

            for( int i = 0, j = Points.Length - 1; i < Points.Length; j = i++ )
            {
                if( Points[i].Y < mainPoint.Y && Points[j].Y >= mainPoint.Y ||
                    Points[j].Y < mainPoint.Y && Points[i].Y >= mainPoint.Y )
                {
                    if( Points[i].X + ( mainPoint.Y - Points[i].Y ) /
                      ( Points[j].Y - Points[i].Y ) *
                      ( Points[j].X - Points[i].X ) < mainPoint.X )
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
        /// <param name="stringPoints">Строка с координатами</param>
        /// <returns>Возвращает массив точек</returns>
        public static PointD[] GetPointsFromString(string stringPoints)
        {
            string[] coordinates = stringPoints.Split(new[] {' '});
            var result = new PointD[coordinates.Length/2];
            int j = 0;
            for( int i = 0; i < coordinates.Length;  i = i+2 )
            {
                PointD point = new PointD();
                point.X = Double.Parse( coordinates[i], new CultureInfo( "en-GB" ) );
                point.Y = Double.Parse( coordinates[i + 1], new CultureInfo( "en-GB" ));
                result[j] = point;
                if( j >= result.Length )
                    break;
                j++;
            }
            return result;
        }

        /// <summary>
        /// Возвращаем Id полигона, которому пренадлежит точка
        /// </summary>
        /// <param name="polygons">Полигоны, которых нужно искать точку</param>
        /// <param name="mainPoint">Точка для проверки</param>
        /// <returns>Возвращает Id полигона</returns>
        public static string GetIdPolygonOwnerPoint( PolygonMap[] polygons, PointD mainPoint )
        {
            return polygons.Where(x => x.IsInPolygon(mainPoint)).Select(polygonMap => polygonMap.Id).FirstOrDefault();
        }
    }
}
