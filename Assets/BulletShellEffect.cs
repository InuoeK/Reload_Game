using UnityEngine;
using System.Collections;

public class BulletShellEffect : MonoBehaviour
{
    private JoystickScripts aimingJoy;
    public GameObject shellSpawnLocation;
    public float shellSpawnDelay;
    private float t;
    // Use this for initialization
    void Start()
    {
        aimingJoy = GameObject.Find("AimingJoy").GetComponent<JoystickScripts>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnShellsWhenShooting();
    }

    private void SpawnShellsWhenShooting()
    {
        if (aimingJoy.isActive)
        {
            if (t <= 0.0f)
            {
                GameObject tbs = Instantiate(Resources.Load("PlaceHolderShell"),  shellSpawnLocation.transform.position, Quaternion.identity ,null) as GameObject;
            }
            else if (t > 0.0f)
            {
                t -= Time.deltaTime;
            }
        }
    }
}
