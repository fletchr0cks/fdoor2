using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinqToTwitterMvcDemo.Helpers
{
    public class Helpers
    {
    }

    public static class GoogleChartHelpers
    {

        public static string GoogleQR(string guid)
        {
            return "<img src='https://chart.googleapis.com/chart?cht=qr&chs=300x300&chl=http://fridgedoor.apphb.com/Mobile/Index?zcguid=" + guid + "' />";
        }

    }

}