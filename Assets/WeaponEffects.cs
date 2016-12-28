using UnityEngine;
using System.Collections;


[System.Serializable]
public struct FiringEffectStruct
{
    public GameObject spriteFiringEffect;
    public float firingTime; // firing time will have to be synced with the fire rate of the weapon
    public float workingTime;
}

public class WeaponEffects : MonoBehaviour
{
    public FiringEffectStruct fes;
    public FiringEffectStruct bses;

    // Temporary; this will be the maximum clip size of the weapon in the future
    public int numShells;

    private bool aimingJoyActive;

    GameObject[] bulletShellArray;


    // Use this for initialization
    void Start()
    {
        initShells();
    }

    // Update is called once per frame
    void Update()
    {
        aimingJoyActive = GameObject.Find("GameController").GetComponent<ControlModule>().IsAimingJoyActive();
        FiringEffect();
        shellEffect();
    }

    private void FiringEffect()
    {
        if (aimingJoyActive)
        {
            fes.workingTime -= Time.deltaTime;
            if (fes.workingTime <= 0f)
            {
                if (fes.spriteFiringEffect.activeInHierarchy)
                {
                    fes.spriteFiringEffect.SetActive(false);
                    fes.workingTime = fes.firingTime;
                    return;
                }
                else
                {
                    fes.spriteFiringEffect.SetActive(true);
                    fes.workingTime = fes.firingTime;
                    return;
                }
            }
        }
        else if (fes.spriteFiringEffect.activeInHierarchy) { 
            fes.spriteFiringEffect.SetActive(false);
            fes.workingTime = 0f;
        }
    }


    //#### Bullet Shell Effect

    private void shellEffect()
    {
        if (aimingJoyActive)
        {
            bses.workingTime -= Time.deltaTime;
            if(bses.workingTime <= 0f)
            {
                for (int i = 0; i < bulletShellArray.Length; i++)
                {
                    if (!bulletShellArray[i].activeInHierarchy)
                    {
                        bulletShellArray[i].SetActive(true);
                        bulletShellArray[i].transform.position = GameObject.Find("BulletShellSpawnLocation").transform.position;
                        bses.workingTime = bses.firingTime;
                        return;
                    }
                }
            }
        }
    }

    private void initShells()
    {
        bulletShellArray = new GameObject[numShells];
        for (int i = 0; i < bulletShellArray.Length; i++)
        {
            GameObject tempBulletShell = (GameObject)Instantiate(bses.spriteFiringEffect);
            //tempBulletShell.transform.parent = this.transform;
            tempBulletShell.SetActive(false);
            bulletShellArray[i] = tempBulletShell;
        }
    }

}
