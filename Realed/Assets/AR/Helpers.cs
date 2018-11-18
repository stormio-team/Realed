using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpers : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find("Body").SetActive(false);
	    GameObject.Find("Top_Info").SetActive(false);
	    GameObject.Find("Left_Info").SetActive(false);
	    GameObject.Find("Right_Info").SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
