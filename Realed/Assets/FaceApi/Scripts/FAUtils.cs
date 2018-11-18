using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;

public class FAUtils {

	public static int getIdConfidenceForCompare(byte[] image,DBService dbService)
    {
       // string fp0 = "C:\\Users\\bobic\\Desktop\\SLIKE\\img00.jpg";
        ///string fp1 = "C:\\Users\\bobic\\Desktop\\SLIKE\\img01.jpg";
       // byte[] imgD0 = File.ReadAllBytes(fp0);
        //byte[] imgD1 = File.ReadAllBytes(fp1);
        FARequest frf = new FARequest(APIConstants.APIKEY, APIConstants.APISECRET);
        frf.image_file1 = image;
        //frf.image_file2;
        int id = 0;
        List<Patient> lst = Patient.GetAll(dbService);
        Patient mk= Patient.GetInfo(dbService,3);
        
        var obj = GameObject.Find("HttpUtil");
        HTTPUtils htp = obj.GetComponent<HTTPUtils>();
        Debug.Log(lst.Count + 1);
        
            byte[] imgD1 = File.ReadAllBytes(mk.PicPath);
            frf.image_file2 = imgD1;
         
           
            
            WWW util = htp.POST(APIConstants.APIURL_COMPARE, frf);
            while (!util.isDone) { }
            for (int i = 0; i < 10000; i++) ;
            double data = htp.confData;
            Debug.Log(data);
            if (data > APIConstants.Threshold) { return mk.Id; }
        return mk.Id;

    }
}
