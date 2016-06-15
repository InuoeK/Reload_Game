using UnityEngine;
using System.Collections;

public class lockongun : MonoBehaviour {

    GameObject a;
	// Use this for initialization
	void Start () {
        a = GameObject.Find("gripposition");
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = a.transform.position;
	}
}
