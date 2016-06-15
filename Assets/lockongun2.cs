using UnityEngine;
using System.Collections;

public class lockongun2 : MonoBehaviour {
    GameObject a;
	// Use this for initialization
	void Start () {
        a = GameObject.Find("supporthand");
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = a.transform.position;
	}
}
