using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ControlPanel : MonoBehaviour, IVirtualButtonEventHandler
{

    public GameObject Panel;

    private bool _visible;

    // Use this for initialization
    void Start () {
        GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }
	
    // Update is called once per frame
    void Update () {
		
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        _visible = !_visible;
        Panel.SetActive(_visible);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        //_top_info.SetActive(_visible);
    }
}
