using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Hello");
        
        string fp0 = "C:\\Users\\bobic\\Desktop\\SLIKE\\img3.jpg";
        string fp1 = "C:\\Users\\bobic\\Desktop\\SLIKE\\img01.jpg";
        byte[] imgD0 = File.ReadAllBytes(fp0);
        //byte[] imgD1 = File.ReadAllBytes(fp1);
        DBService dbsr = new DBService("real_data.db");
        dbsr.AssertDatabaseExists();
        FARequest frf=new FARequest(APIConstants.APIKEY, APIConstants.APISECRET);
        frf.image_file1 = imgD0;
        //frf.image_file2 = imgD1;
        Debug.Log(FAUtils.getIdConfidenceForCompare(imgD0,dbsr));
        /*
        var obj = GameObject.Find("HttpUtil");
        HTTPUtils htp=obj.GetComponent<HTTPUtils>();
        htp.POST(APIConstants.APIURL_COMPARE, frf);
        while (!htp) { }
        double data;*/

       // frf.image_file1
    }

    // Update is called once per frame
    void Update () {
		
	}
}
