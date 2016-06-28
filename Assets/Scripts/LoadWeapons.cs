using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class LoadWeapons : MonoBehaviour {

	// Use this for initialization
	void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public class FileReader
{
    public List<WeaponStats> ReadWeaponStatsFromFile(string filepath)
    {
        StreamReader rd = new StreamReader(filepath);
        WeaponStats tws = new WeaponStats();
        List<WeaponStats> outputList = new List<WeaponStats>();
        
        while (!rd.EndOfStream)
        {
            string t = rd.ReadLine();
            if (!t.Contains("#"))
            {
                Debug.Log(t);
                string[] tt = t.Split(',');
                tws.setName(tt[0]);
                tws.setClipSize(int.Parse(tt[1]));
                tws.setMaxAmmo(int.Parse(tt[2]));
                tws.setSpreadFactor(float.Parse(tt[3]));


                Debug.Log("Added " + tws.getName() + " to weapon list");

                outputList.Add(tws);
            }
        }

        return outputList;
    }
}