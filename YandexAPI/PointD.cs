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
