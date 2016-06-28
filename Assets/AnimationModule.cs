using UnityEngine;
using System.Collections;

public class AnimationModule : MonoBehaviour
{
    GameObject weaponObject;

    Animator weaponAnimator;

    // Weapon Variables

    public bool isShooting;
    public string weaponObjectName;

    // Use this for initialization
    void Start()
    {
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        weaponAnimator.SetBool("IsShooting", isShooting);

        SetHandTargetsAsChildOfObject();
    }

    public void SetWeaponAnimator(string objName)
    {
        weaponAnimator = GameObject.Find(objName).GetComponent<Animator>();
        Debug.Log("Set animator");
    }

    // Set Hand Targets as children of weapon
    private void SetHandTargetsAsChildOfObject()
    {
        GameObject.Find("L_ArmTarget").transform.parent = GameObject.Find(weaponObjectName).transform;
        GameObject.Find("R_ArmTarget").transform.parent = GameObject.Find(weaponObjectName).transform;
    }

    public void SetWeaponObjectName(string value)
    {
        weaponObjectName = value;
    }
    
}
