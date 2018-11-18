using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class APIConstants  {

    public static string APIKEY = "IyxqaTgYFczENwVebQu0t72focDwT3vq";
    public static string APISECRET = "oRqIhnU4hjvmlA2sXwh9-cmhc9SFZoYK";
    public static string APIURL_COMPARE = "https://api-us.faceplusplus.com/facepp/v3/compare";
    public static double Threshold = 85;
    public static string getUrlWKeys()
    {
        StringBuilder sb = new StringBuilder(APIURL_COMPARE);
        sb.Append("?api_key=").Append(APIKEY).Append("&api_secret=").Append(APISECRET);
        return sb.ToString();
    }
}
