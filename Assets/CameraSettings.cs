using UnityEngine;
using System.Collections;

public class CameraSettings : MonoBehaviour {
    public int cameraFOV;

    private Camera cam;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void Init()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    public void SetFOV()
    {
        cam.fieldOfView = cameraFOV;
    }
}
