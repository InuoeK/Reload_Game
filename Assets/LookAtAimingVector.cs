using UnityEngine;
using System.Collections;

public class LookAtAimingVector : MonoBehaviour
{

    public float angleTweak;
    private JoystickScripts aimingJoy;
    private GameObject playerUpperTorsoGroup;


    // Use this for initialization
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtAimingDirection();
    }

    private void LookAtAimingDirection()
    {
        if (aimingJoy.isActive)
        {
            FlipSpriteWhenLookingBackwards();
            float aimAngle = aimingJoy.GetDirectionAngle();

            // Need to apply angle mod if the player is looking behind
            if (aimingJoy.GetDirectionVector().x < 0)
            {
                aimAngle -= angleTweak;
            }

            playerUpperTorsoGroup.transform.rotation = Quaternion.AngleAxis(aimAngle, Vector3.forward);
        }

    }

    private void Init()
    {
        aimingJoy = GameObject.Find("AimingJoy").GetComponent<JoystickScripts>();
        playerUpperTorsoGroup = GameObject.Find("UpperTorso");
    }

    private void FlipSpriteWhenLookingBackwards()
    {
        Vector3 playerScale = playerUpperTorsoGroup.transform.parent.transform.localScale;
        Vector2 aimingVector = aimingJoy.GetDirectionVector();
        GameObject playerObjectMaster = playerUpperTorsoGroup.transform.parent.gameObject;

        if ((aimingVector.x < -0.1f && playerScale.x > 0.0f) || aimingVector.x > -0.10f && playerScale.x < 0.0f)
        {
            //playerScale.y *= -1;
            //playerObjectMaster.transform.localScale = playerScale;

            //Vector3 tRotation = playerObjectMaster.transform.localEulerAngles;
            //if (aimingVector.x > -0.09f)
            //{
            //    tRotation.z = 0.0f;
            //}
            //else if (aimingVector.x < -0.1f)
            //{
            //    tRotation.z = 180.0f;
            //}

            //playerObjectMaster.transform.localEulerAngles = tRotation;
            playerScale.x *= -1;
            playerObjectMaster.transform.localScale = playerScale;
        }
    }
}
