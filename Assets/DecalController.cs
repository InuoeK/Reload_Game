using UnityEngine;
using System.Collections;

public class DecalController : MonoBehaviour {

    public GameObject bullet;
    bool enableBulletshells;

    GameObject[] bulletShellArray;

	// Use this for initialization
	void Start () {
        initDecals();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void spawnBulletShell(GameObject gameObjectForLocation)
    {
        for (int i = 0; i < bulletShellArray.Length; i++)
        {
                if (!bulletShellArray[i].activeInHierarchy)
                {
                    bulletShellArray[i].SetActive(true);
                    bulletShellArray[i].transform.position = gameObjectForLocation.transform.position;
                break;
                }
        }
    }

    private void initDecals()
    {
        enableBulletshells = true;
        bulletShellArray = new GameObject[50];

        for (int i = 0; i < bulletShellArray.Length; i++)
        {
            GameObject obj = (GameObject)Instantiate(bullet);
            obj.SetActive(false);
            bulletShellArray[i] = obj;
        }
    }
}
