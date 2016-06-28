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
        FlipSpriteOnAimingVec();
    }

    /*##########################################
     *  PUBLICS
     * 
     *##########################################
     */

    public Vector2 getAimingDirectionVec() { return aJoy.getDirectionVector(aJoy.gameObject.transform.position); }
    public Vector2 getMovementDirectionVec() { return mJoy.getDirectionVector(mJoy.gameObject.transform.position); }
    public Quaternion GetAimingAngle() { return aJoy.GetDirectionAngle(); }
    public Quaternion GetMovementAngle() { return mJoy.GetDirectionAngle(); }
    public bool IsAimingJoyActive() { return aJoy.GetIsActive(); }
    public bool IsMovementJoyActive() { return mJoy.GetIsActive(); }

    void UpdateAnimatorParameters()
    {
        am.isShooting = IsAimingJoyActive();
    }

    void FlipSpriteOnAimingVec()
    {
        GameObject player = GameObject.Find("PlayerAnimBodyGroup");
        Vector3 plrScale = player.transform.localScale;
        if ((getAimingDirectionVec().x < -0.1f && plrScale.x > 0.0f) || getAimingDirectionVec().x > -0.10f && plrScale.x < 0.0f)
        {
            plrScale.x *= -1;
            player.transform.localScale = plrScale;

        }

    }
}
