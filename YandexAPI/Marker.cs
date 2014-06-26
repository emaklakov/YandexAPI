using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YandexAPI
{
    /// <summary>
    /// Вся информация по правильному созданию метки находится здесь http://api.yandex.ru/maps/doc/staticapi/1.x/dg/concepts/markers.xml
    /// </summary>
    public class Marker
    {

        public enum StyleMarker
        {
            pmS,
            pm2S,
            flagS,
            vkS
        }

        public enum ColorMarker
        {
            wtM,
            doM,
            dbM,
            blM,
            gnM,
            grM,
            lbM,
            ntM,
            orM,
            pnM,
            rdM,
            ywM,
            a,
            b,
            org,
            dir,
            blyw,
            bk,
            gr
        }
    }
}
