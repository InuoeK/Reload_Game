using UnityEngine;
using System.Collections;

public class ControlModule : MonoBehaviour
{

    JoystickScripts mJoy;
    JoystickScripts aJoy;
    AnimationModule am;

    // Use this for initialization
    void Start()
    {
        mJoy = GameObject.Find("MovementJoy").GetComponent<JoystickScripts>();
        aJoy = GameObject.Find("AimingJoy").GetComponent<JoystickScripts>();
        am = GameObject.Find("GameController").GetComponent<AnimationModule>();
    }

    // Update is called once per frame
    void Update()
    {
       UpdateAnimatorParameters();
      // FlipSpriteOnAimingVec();
    }

    /*##########################################
     *  PUBLICS
     * 
     *##########################################
     */

    public Vector2 getAimingDirectionVec() { return aJoy.GetDirectionVector(); }
    public Vector2 getMovementDirectionVec() { return mJoy.GetDirectionVector(); }
    public Quaternion GetAimingAngle() { return aJoy.GetDirectionQuaternion(); }
    public Quaternion GetMovementAngle() { return mJoy.GetDirectionQuaternion(); }
    public bool IsAimingJoyActive() { return aJoy.isActive; }
    public bool IsMovementJoyActive() { return mJoy.isActive; }

    void UpdateAnimatorParameters()
    {
        am.isShooting = IsAimingJoyActive();
    }

   public void FlipSpriteOnAimingVec()
    {
        GameObject player = GameObject.Find("PlayerChibi");
        Vector3 plrScale = player.transform.localScale;
        if ((getAimingDirectionVec().x < -0.1f && plrScale.y > 0.0f) || getAimingDirectionVec().x > -0.10f && plrScale.y < 0.0f)
        {
            // Old method, would break CCD
            //plrScale.x *= -1;
            //player.transform.localScale = plrScale;

            // New method, instead of rotation on the x axis, the sprite is flipped along the y axis and then an offset rotation of 180 degrees is applied on the sprite
            // This avoids any manipulation of the x axis, while achieving the same results (and also avoid breaking the IK system!)
            plrScale.y *= -1;           
            player.transform.localScale = plrScale;


            Vector3 tRotation = player.transform.rotation.eulerAngles;

            if (getAimingDirectionVec().x > -0.09f)
            {
                tRotation.z = 0.0f;
            }
            else if (getAimingDirectionVec().x < -0.1f)
            {
                tRotation.z = 180.0f;

            }
            player.transform.localEulerAngles = tRotation;

        }

    }
}
