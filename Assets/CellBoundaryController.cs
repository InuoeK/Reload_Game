using UnityEngine;
using System.Collections;

public class CellBoundaryController : MonoBehaviour {
    private BoxCollider2D spawnLocation;

    // Goes north, east, south, west
    private BoxCollider2D[] boundaries = new BoxCollider2D[4];

	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void Init()
    {
        boundaries[0] = gameObject.transform.FindChild("NorthBoundary").GetComponent<BoxCollider2D>();
        boundaries[1] = gameObject.transform.FindChild("EastBoundary").GetComponent<BoxCollider2D>();
        boundaries[2] = gameObject.transform.FindChild("SouthBoundary").GetComponent<BoxCollider2D>();
        boundaries[3] = gameObject.transform.FindChild("WestBoundary").GetComponent<BoxCollider2D>();

    }

 
}
