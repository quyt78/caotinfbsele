using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Selenium.Models
{


    public class MyArray
    {

        [JsonProperty("xLinkBaiDangfb")]
        public string XLinkBaiDangfb;

        [JsonProperty("xTenFb")]
        public string XTenFb;

        [JsonProperty("xLinkTenFb")]
        public string XLinkTenFb;

        [JsonProperty("xNgaydang")]
        public string XNgaydang;

        [JsonProperty("xNoiDung")]
        public string XNoiDung;

    }

    public class Root
    {

        [JsonProperty("MyArray")]
        public List<MyArray> MyArray;

    }

    public static class ConvertObject {

        public delegate bool TryParse<T>(string str, out T value);

        public static T GetValue<T>(this string str, TryParse<T> parseFunc)
        {
            T val;
            parseFunc(str, out val);
            return val;
        }

        public static bool HasProperty(this object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName) != null;
        }

        public static bool HasProperty(this Type obj, string propertyName)
        {
            return obj.GetProperty(propertyName) != null;
        }
    }

    

}
