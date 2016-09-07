using UnityEngine;
using System.Collections;

public class SpawnNewCellWhenPlayerEnters : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject t = Instantiate(Resources.Load("SimpleCell")) as GameObject;
        t.transform.position = this.gameObject.transform.parent.transform.position;
        Destroy(this.gameObject);
    }

}
