using UnityEngine;
using System.Collections;

public class JSONTest : MonoBehaviour {
    public class WeaponStats
    {
        public string name;
        public int magazineSize;
        public int maximumMagazines;
        public float fireRate;

        public WeaponStats()
        {
            name = "generic";
            magazineSize = 1;
            maximumMagazines = 1;
            fireRate = 0.2f;
        }

        public string SaveToString()
        {
            Debug.Log("Generating JSON");
            return JsonUtility.ToJson(this);
        }
    }


	// Use this for initialization
	void Start () {
        GenerateJSON();
       // LoadJSON();
	}

    private void GenerateJSON()
    {
        WeaponStats abc = new WeaponStats();
        Debug.Log(abc.SaveToString());
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
