using UnityEngine;
using System.Collections;

public class BulletShellEffect : MonoBehaviour
{
    private JoystickScripts aimingJoy;
    public GameObject shellSpawnLocation;
    public float shellSpawnDelay;
    private float t;

    private DecalController decalController;

   


    // Use this for initialization
    void Start()
    {
        aimingJoy = GameObject.Find("AimingJoy").GetComponent<JoystickScripts>();
        decalController = GameObject.Find("GameController").GetComponent<DecalController>();
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
                //GameObject tbs = Instantiate(Resources.Load("Shell_Rifle"),  shellSpawnLocation.transform.position, Quaternion.identity ,null) as GameObject;
                decalController.spawnBulletShell(shellSpawnLocation);
                t = shellSpawnDelay;
            }
            else if (t > 0.0f)
            {
                t -= Time.deltaTime;
            }
        }
    }
}
