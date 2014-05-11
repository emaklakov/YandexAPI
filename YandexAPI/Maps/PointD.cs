using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace YandexAPI.Maps
{
    public class PointD
    {
        private double _x;
        private double _y;

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

        public PointD()
        {

        }

        public PointD(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public PointD(string point)
        {
            string[] coordinate = point.Split(new[] { ',' });
            _x = Double.Parse(coordinate[0], new CultureInfo("en-GB"));
            _y = Double.Parse(coordinate[1], new CultureInfo("en-GB"));
        }

        /// <summary>
        /// Возвращаем GPS координаты точки
        /// </summary>
        /// <param name="point">Точка с координатами Яндекса</param>
        /// <returns>GPS координаты</returns>
        public static PointD ConvertToGpsPoint(PointD point)
        {
            PointD result = new PointD();
            double integerX = Math.Truncate(point.X);
            result.X = integerX + (point.X - integerX) * 0.6;
            double integerY = Math.Truncate(point.Y);
            result.Y = integerY + (point.Y - integerY) * 0.6;
            return result;
        }

        /// <summary>
        /// Возвращаем Яндекс координаты точки
        /// </summary>
        /// <param name="point">Точка с GPS координатами</param>
        /// <returns>Яндекс координаты</returns>
        public static PointD ConvertGpsToYandexPoint(PointD point)
        {
            var result = new PointD();
            double integerX = Math.Truncate(point.X);
            result.X = integerX + (point.X - integerX) / 0.6;
            double integerY = Math.Truncate(point.Y);
            result.Y = integerY + (point.Y - integerY) / 0.6;
            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", X, Y);
        }
        
    }
}
