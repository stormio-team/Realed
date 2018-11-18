using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class HTTPUtils:MonoBehaviour
{
    public double confData=0;
    public bool isSignal = false;
   public void Start()
    {
       
    }

    //private static readonly string POSTAddUserURL = "http://db.url.com/api/addUser";
    public WWW POST(string url, FARequest req)
    {
        isSignal = false;
        WWW www;    
        WWWForm form = new WWWForm();
        //form.AddField("api_key",APIConstants.APIKEY);
        // form.AddField("api_secret", APIConstants.APISECRET);
        form.AddBinaryData("image_file1", req.image_file1, "img00.jpeg");
        //Debug.Log(req.image_file1);
        form.AddBinaryData("image_file2", req.image_file2, "img01.jpeg");
        //Debug.Log(req.image_file2);
        www = new WWW(APIConstants.getUrlWKeys(), form.data, form.headers);
        StartCoroutine(WaitForRequest(www));
        return www;
    }
    IEnumerator WaitForRequest(WWW data)
    {
        yield return data; // Wait until the download is done
        if (data.error != null)
        {
            Debug.Log(" " + data.text);
            Debug.Log("There was an error sending request: " + data.error+ " "+data.text);
            isSignal = true;
        }
        else
        {
            string dat = data.text;
            Debug.Log(dat);
            /*FACompareObject v = new FACompareObject();
            JsonUtility.FromJsonOverwrite(data.text,v);*/
            string[] par = dat.Split(',');
            string[] fconf= { };
            foreach (string st in par)
            {
                if (st.Contains("confidence")) { fconf = st.Split(':'); }
            }
            if (fconf.Length > 1) {Debug.Log(fconf[1]);confData =Convert.ToDouble(fconf[1]); };
            isSignal = true;
        }
    }

}
