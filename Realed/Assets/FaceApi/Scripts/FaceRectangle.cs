using System.Collections.Generic;
using System;

[Serializable]
public class FaceRectangle
{
    public int width { get; set; }
    public int top { get; set; }
    public int left { get; set; }
    public int height { get; set; }
}
[Serializable]
public class Faces1
{
    public FaceRectangle face_rectangle { get; set; }
    public string face_token { get; set; }
}
[Serializable]
public class FaceRectangle2
{
    public int width { get; set; }
    public int top { get; set; }
    public int left { get; set; }
    public int height { get; set; }
}
[Serializable]
public class Faces2
{
    public FaceRectangle2 face_rectangle { get; set; }
    public string face_token { get; set; }
}
[Serializable]
public class Thresholds
{
    public double _1e3 { get; set; }
    public double _1e5 { get; set; }
    public double _1e4 { get; set; }
}
[Serializable]
public class FACompareObject
{
    public IList<Faces1> faces1 { get; set; }
    public IList<Faces2> faces2 { get; set; }
    public int time_used { get; set; }
    public Thresholds thresholds { get; set; }
    public double confidence { get; set; }
    public string image_id2 { get; set; }
    public string image_id1 { get; set; }
    public string request_id { get; set; }
}

