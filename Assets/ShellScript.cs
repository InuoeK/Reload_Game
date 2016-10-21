using UnityEngine;
using System.Collections;

public class ShellScript : MonoBehaviour {

    private GameObject playerObject;

    private float ground;

	// Use this for initialization
	void Start () {
        playerObject = GameObject.Find("PlayerOBjectContainer");
        ApplyForce();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void ApplyForce()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-1,.5f);
    }
}
