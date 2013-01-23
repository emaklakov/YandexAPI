using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace YandexAPI.Maps
{
    public class PolygonMap
    {
        private PointD[] _Points;
        
        public PolygonMap()
        {
            
        }

        public PolygonMap( PointD[] Points )
        {
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
                point.X = Double.Parse( coordinates[i], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture );
                point.Y = Double.Parse( coordinates[i + 1], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture );

                result[j] = point;

                if( j >= result.Length )
                    break;

                j++;
            }

            return result;
        }

        /// <summary>
        /// Точки полигона
        /// </summary>
        public PointD[] Points
        {
            get { return _Points; }
            set { _Points = value; }
        }
    }
}
