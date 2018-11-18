using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FARequest {
    public FARequest(string api_key, string api_secret)
    {
        this.api_key = api_key;
        this.api_secret = api_secret;
    }
    public string api_key { get; set; }
    public string api_secret { get; set; }
    public byte[] image_file1 { get; set; }
    public byte[] image_file2 { get; set; }

}
[Serializable]
public class FARequestURL
{
    public FARequestURL(string api_key, string api_secret)
    {
        this.api_key = api_key;
        this.api_secret = api_secret;
    }
    public string api_key { get; set; }
    public string api_secret { get; set; }
    public byte[] image_url1 { get; set; }
    public byte[] image_url2 { get; set; }

}
