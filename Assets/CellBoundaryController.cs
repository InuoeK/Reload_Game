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
        boundaries[0] = gameObject.transform.Find("NorthBoundary").GetComponent<BoxCollider2D>();
        boundaries[1] = gameObject.transform.Find("EastBoundary").GetComponent<BoxCollider2D>();
        boundaries[2] = gameObject.transform.Find("SouthBoundary").GetComponent<BoxCollider2D>();
        boundaries[3] = gameObject.transform.Find("WestBoundary").GetComponent<BoxCollider2D>();

    }

 
}
