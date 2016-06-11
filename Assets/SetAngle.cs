using UnityEngine;
using System.Collections;

public class SetAngle : MonoBehaviour
{
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
            this.gameObject.transform.localRotation = cm.GetAimingAngle() * new Quaternion(0, 0, 1, 90f * 3.14f/180f) ;
           

        }
    }
}
