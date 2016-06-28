using UnityEngine;
using System.Collections;

public class EntityStats : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}


public struct WeaponStats
{
    string name;
    int clipSize;
    int maxAmmo;
    float spreadFactor;

    public void setName(string value) { name = value; }
    public void setClipSize(int value) { clipSize = value; }
    public void setMaxAmmo(int value) { maxAmmo = value; }
    public void setSpreadFactor(float value) { spreadFactor = value; }

    public string getName() { return name; }
    public int getClipSize() { return clipSize; }
    public int getMaxAmmo() { return maxAmmo; }
    public float getSpreadFactor() { return spreadFactor; }
}