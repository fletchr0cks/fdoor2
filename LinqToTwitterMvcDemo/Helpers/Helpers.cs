using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinqToTwitterMvcDemo.Helpers
{
    public class Helpers
    {
        
    }

    public static class FormatHelpers
    {
        public static string formatTimeStamp(DateTime datetime)
        {
            DateTime now = DateTime.Now;
            var daysago = (now - datetime).Days;
            var time_txt = "";
            time_txt = daysago + "d";
            if (Convert.ToInt32(daysago) == 0)
            {
                var hoursago = (now - datetime).Hours;
                time_txt = hoursago + "h";

                if (Convert.ToInt32(hoursago) < 1)
                {
                    var minsago = (now - datetime).Minutes;
                    time_txt = minsago + "m";

                    if (Convert.ToInt32(minsago) < 1)
                    {
                        var secsago = (now - datetime).Seconds;
                        time_txt = secsago + "s";
                    }

                }

            }


            return time_txt;
        }

    }

    public static class GoogleChartHelpers
    {

        public static string GoogleQR(string guid)
        {
            return "<img src='https://chart.googleapis.com/chart?cht=qr&chs=300x300&chl=http://fridgedoor.apphb.com/Mobile/Index?zcguid=" + guid + "' />";
        }

    }

}