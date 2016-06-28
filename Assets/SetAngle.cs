using UnityEngine;
using System.Collections;

public class SetAngle : MonoBehaviour
{
    public float modangle;
    ControlModule cm;
    // Use this for initialization
    void Start()
    {
        cm = GameObject.Find("GameController").GetComponent<ControlModule>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cm.IsAimingJoyActive())
        {
            Vector2 cmAngle = cm.getAimingDirectionVec();
            float angle = Mathf.Atan2(cmAngle.y, cmAngle.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (cm.getAimingDirectionVec().x < 0)
            {
                 angle = Mathf.Atan2(-cmAngle.y, cmAngle.x) * Mathf.Rad2Deg;
                Debug.Log(transform.rotation.z);
                transform.rotation = Quaternion.AngleAxis(angle + modangle, Vector3.forward);
            }
        }
    }
}
