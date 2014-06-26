using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace YandexAPI
{
    public class PointD
    {
        private double _x;
        private double _y;

        public PointD(string Point)
        {
            string[] coordinate = Point.Split( new char[] { ',' } );
            _x = Double.Parse( coordinate[0], new CultureInfo( "en-GB" ) );
            _y = Double.Parse( coordinate[1], new CultureInfo( "en-GB" ) );
        }

        public PointD( double x, double y )
        {
            _x = x;
            _y = y;
        }

        public PointD()
        {

        }

        /// <summary>
        /// Возвращаем GPS координаты точки
        /// </summary>
        /// <param name="Point">Точка с координатами Яндекса</param>
        /// <returns>GPS координаты</returns>
        public static PointD ConvertToGPSPoint( PointD Point )
        {
            PointD result = new PointD();

            double integerX = Math.Truncate(Point.X);
            result.X = integerX + ( Point.X - integerX ) * 0.6;

            double integerY = Math.Truncate( Point.Y );
            result.Y = integerY + ( Point.Y - integerY ) * 0.6;

            return result;
        }

        /// <summary>
        /// Возвращаем Яндекс координаты точки
        /// </summary>
        /// <param name="Point">Точка с GPS координатами</param>
        /// <returns>Яндекс координаты</returns>
        public static PointD ConvertGPSToYandexPoint( PointD Point )
        {
            PointD result = new PointD();

            double integerX = Math.Truncate( Point.X );
            result.X = integerX + ( Point.X - integerX ) / 0.6;

            double integerY = Math.Truncate( Point.Y );
            result.Y = integerY + ( Point.Y - integerY ) / 0.6;

            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", X, Y);
        }

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }
}
