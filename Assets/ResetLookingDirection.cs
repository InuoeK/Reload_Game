using UnityEngine;
using System.Collections;

public class ResetLookingDirection : MonoBehaviour {
    public GameObject playerObject;

    public GameObject playerTorso;
    private JoystickScripts aimingJoy;
    private float defaultRotation;

    float resetTimeSeconds;

    private float resetTimeMS;
    public float defaultResetTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void Init()
    {
        defaultRotation = playerTorso.transform.localEulerAngles.z;
    }

    private void ResetScale()
    {
        
    }

    private void ResetRotation()
    {
        if(resetTimeMS<=0.0f)
        {
            if(playerTorso.transform.localEulerAngles.z != defaultRotation)
            {

            }
        }
        resetTimeMS -= Time.deltaTime;

    }

    public void ResetSetResetTime()
    {
        resetTimeMS = defaultResetTime;
    }
}
