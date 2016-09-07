using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JoystickDebugger : MonoBehaviour {
    public GameObject joystickObject;
    private JoystickScripts jss;
    private Text t;

	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateText();
	}

    private void Init()
    {
        jss = joystickObject.GetComponent<JoystickScripts>();
        t = gameObject.GetComponent<Text>();
    }

    private void UpdateText()
    {
        t.text = "Active: " + jss.isActive + "/nVector: " + jss.GetDirectionVector();
    }
}
