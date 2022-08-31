using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace simaMovil.Models
{
    public class Constants
    {
#if DEBUG
        public static string DefaultApiUrl = "https://10.0.2.2:44392/api/";
#else
public static string ApiUrl = "https://SERVIDORWEB/api";
#endif 

        public static string ContentType = "application/json";
        public static string TokenType = "Bearer";

        public static bool IsDev = true;

        public static Color BackGroundColor = Color.Black;
        public static Color MainTextColor = Color.FromRgb(34, 105, 169);
        public static Color SubTextColor = Color.FromRgb(24, 150, 188);
    }
}
