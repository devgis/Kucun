using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CY
{
    public class pub
    {
        public static string username;
        public static string userid;
        public static string role_id;
        public static string TrackMsg;
        public static string TrackEn;
        public static string TrackRu;

        public static List<string> lstmenu2;
        public static string custid;
        public static string custname;
        public static string serverid;
        public static string servername;

        public static System.Drawing.Image img;

        public static long ConvertDateTimeInt(System.DateTime time)
        {
            //double intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            //intResult = (time- startTime).TotalMilliseconds;
            long t = (time.Ticks - startTime.Ticks) / 10000000;            //除10000调整为13位
            return t;
        }
        //public static daigou.SecurityHeader sh = new daigou.SecurityHeader();
        //public pub()
        //{
        //    sh.SecurityKey = "*1234asADDdf.sdf9877";
        //}
    }
}
