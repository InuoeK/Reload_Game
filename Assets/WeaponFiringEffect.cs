using UnityEngine;
using System.Collections;

public class WeaponFiringEffect : MonoBehaviour
{
    private JoystickScripts aimingjoy;
    public GameObject firingEffect;
    public float firingDelay;
    public float firingEffectResetTime;

    private float t;
    void Start()
    {
        t = 0.0f;
        aimingjoy = GameObject.Find("AimingJoy").GetComponent<JoystickScripts>();
    }

    // Update is called once per frame
    // Check if aiming joy is active, 
    // if it is, check if the firing effect is already enabled. If it is, invoke the call to remove it.
    void Update()
    {
        if (aimingjoy.isActive)
        {
            if (firingEffect.activeSelf)
            {
                Invoke("DisableEffect", firingDelay);
            }
            else
            {
                if (t <= 0.0f)
                {
                    firingEffect.SetActive(true);
                    t = firingEffectResetTime;
                }        
            }
               
        }
    
        if(t > 0.0f)
        {
            t -= Time.deltaTime;
        }
    }

    void DisableEffect()
    {
        CancelInvoke();
        firingEffect.SetActive(false);
    }
}




