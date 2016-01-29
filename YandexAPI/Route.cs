using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace YandexAPI
{
    public class Route
    {
        private string routeId = "";

        private int requestTimeout = 10;
        // Длина в метрах
        private string routeLength = "0";
        // Время проезда в секундах с учетом пробок
        private string routeJamsTime = "0";
        // Время проезда в секундах
        private string routeTime = "0";
        // Длина в метрах
        private string routeHumanLength = "0";
        // Время проезда в секундах с учетом пробок
        private string routeHumanJamsTime = "0";
        // Время проезда в секундах
        private string routeHumanTime = "0";
        private string htmlTemplate = "<!DOCTYPE html><html lang=\"ru\"><head>" +
            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />" +
            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"><title>API Яндекс.Карт 2.х</title>" +      
            "<script src=\"https://yastatic.net/jquery/2.1.4/jquery.min.js\" type=\"text/javascript\"></script>" +
            "<script src=\"http://api-maps.yandex.ru/2.1/?load=package.full&lang=ru-RU&coordorder=longlat\" type=\"text/javascript\"></script>" +  
            "<script type=\"text/javascript\">{0}</script></head><body></body></html>";

        public Route()
        {
            
        }

        /// <summary>
        /// Маршрут
        /// </summary>
        /// <param name="RequestTimeout">Тайм-аут запроса</param>
        public Route(int RequestTimeout)
        {
            requestTimeout = RequestTimeout;
        }

        private string GetJSCode(PointD[] RoutePoints)
        {
            string strRoutePoints = "";

            foreach (PointD routePoint in RoutePoints)
            {
                string DotX = routePoint.X.ToString().Replace(",", ".");
                string DotY = routePoint.Y.ToString().Replace(",", ".");
                strRoutePoints += "[" + DotX + ", " + DotY + "],";
            }

            strRoutePoints = strRoutePoints.Trim(new[] { ' ', ',' });

            string jsCode = "ymaps.ready(init); " +
                "function init() { ymaps.route([" + strRoutePoints + "]).then(function (route) { " +
                "window.external.GetData(" + 
                "route.getLength(), route.getJamsTime(), route.getTime(), " +
                "route.getHumanLength(), route.getHumanJamsTime(), route.getHumanTime()" +
                "); }, function (error) { window.external.GetDataError(); });" +
                " }";

            return jsCode;
        }

        /// <summary>
        /// Тайм-аут запроса
        /// </summary>
        public int RequestTimeout
        {
            get
            {
                return requestTimeout;
            }
            set
            {
                requestTimeout = value;
            }
        }
                                                         
        [STAThread()]
        public Route Load(PointD[] RoutePoints)
        {
            using (WebBrowser webBrowser = new WebBrowser())
            {
                ScriptManager scriptManager = new ScriptManager();

                webBrowser.ScriptErrorsSuppressed = true;
                webBrowser.ObjectForScripting = scriptManager;
                webBrowser.WebBrowserShortcutsEnabled = false;

                scriptManager.GetState = ScriptManager.State.Running;

                string jsCode = GetJSCode(RoutePoints);
                webBrowser.DocumentText = String.Format(htmlTemplate, jsCode); 

                bool IsCheck = true;
                DateTime starTime = DateTime.Now;

                while (IsCheck)
                {
                    switch (scriptManager.GetState)
                    {
                        case ScriptManager.State.Ok:
                            Route route = new Route();
                            route.RouteId = Guid.NewGuid().ToString();
                            route.RouteLength = scriptManager.routeLength;
                            route.RouteJamsTime = scriptManager.routeJamsTime;
                            route.RouteTime = scriptManager.routeTime;
                            route.RouteHumanLength = scriptManager.routeHumanLength;
                            route.RouteHumanJamsTime = scriptManager.routeHumanJamsTime;
                            route.RouteHumanTime = scriptManager.routeHumanTime;
                            IsCheck = false;
                            return route;

                        case ScriptManager.State.Error:
                            IsCheck = false;
                            break;
                    }

                    // Выходим по TimeOut
                    TimeSpan ts = DateTime.Now - starTime;
                    if (ts.Seconds > requestTimeout)
                    {
                        IsCheck = false;
                    }
                    Thread.Sleep(100);
                    Application.DoEvents();
                } 

                webBrowser.Dispose(); 
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }

            return null;
        }

        [STAThread()]
        public Route Load(PointD DotA, PointD DotB)
        {
            bool IsLoad = false;

            PointD[] RoutePoints = new PointD[] { DotA, DotB };

            return Load(RoutePoints);
        }

        /// <summary>
        /// Id
        /// </summary>
        public string RouteId
        {
            get
            {
                return routeId;
            }
            set
            {
                routeId = value;
            }
        }

        /// <summary>
        /// Длина в метрах
        /// </summary>
        public string RouteLength
        {
            get
            {
                return routeLength;
            }
            set
            {
                routeLength = value;
            }
        }

        /// <summary>
        /// Время проезда в секундах с учетом пробок
        /// </summary>
        public string RouteJamsTime
        {
            get
            {
                return routeJamsTime;
            }
            set
            {
                routeJamsTime = value;
            }
        }

        /// <summary>
        /// Время проезда в секундах
        /// </summary>
        public string RouteTime
        {
            get
            {
                return routeTime;
            }
            set
            {
                routeTime = value;
            }
        }

        /// <summary>
        /// Возвращает строковое представление длины маршрута с единицами измерения.
        /// </summary>
        public string RouteHumanLength
        {
            get
            {
                return routeHumanLength;
            }
            set
            {
                routeHumanLength = value;
            }
        }

        /// <summary>
        /// Возвращает строковое представление времени проезда маршрута с единицами измерения с учетом пробок.
        /// </summary>
        public string RouteHumanJamsTime
        {
            get
            {
                return routeHumanJamsTime;
            }
            set
            {
                routeHumanJamsTime = value;
            }
        }

        /// <summary>
        /// Возвращает строковое представление времени проезда маршрута с единицами измерения.
        /// </summary>
        public string RouteHumanTime
        {
            get
            {
                return routeHumanTime;
            }
            set
            {
                routeHumanTime = value;
            }
        }

        [ComVisible(true)]
        public class ScriptManager
        {
            public State GetState = State.Running;

            // Длина в метрах
            public string routeLength = "0";
            // Время проезда в секундах с учетом пробок
            public string routeJamsTime = "0";
            // Время проезда в секундах
            public string routeTime = "0";

            // Возвращает строковое представление длины маршрута с единицами измерения.
            public string routeHumanLength = "0";
            // Возвращает строковое представление времени проезда маршрута с единицами измерения с учетом пробок.
            public string routeHumanJamsTime = "0";
            // Возвращает строковое представление времени проезда маршрута с единицами измерения.
            public string routeHumanTime = "0";

            public void GetData(object Length, object JamsTime, object CommonTime, 
                                object HumanLength, object HumanJamsTime, object HumanTime)
            {
                routeLength = Length.ToString();
                routeJamsTime = JamsTime.ToString();
                routeTime = CommonTime.ToString();
                routeHumanLength = HumanLength.ToString().Replace("&#160;", " ");
                routeHumanJamsTime = HumanJamsTime.ToString().Replace("&#160;", " ");
                routeHumanTime = HumanTime.ToString().Replace("&#160;", " ");
                GetState = State.Ok;
            }

            public void GetDataError()
            {
                GetState = State.Error;
            }

            public enum State
            {
                Running,
                Ok,
                Error
            }
        }
    }
}
