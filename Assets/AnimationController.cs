using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour
{

    JoystickScripts movementJoy;
    JoystickScripts aimingJoy;

    private bool isMoving;
    Animator animControl;

    private string animMoveForwardName = "movingForward";
    private string animMoveBackwardName = "movingBackward";

    // Use this for initialization
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovementJoyActive();
        CheckMovementJoyDirection();
    }

    private void Init()
    {
        movementJoy = GameObject.Find("MovementJoy").GetComponent<JoystickScripts>();
        aimingJoy = GameObject.Find("AimingJoy").GetComponent<JoystickScripts>();
        animControl = gameObject.GetComponent<Animator>();
        isMoving = false;
    }

    private void CheckMovementJoyDirection()
    {
        if (movementJoy.GetDirectionVector().x > 0)
        {
            animControl.SetBool(animMoveForwardName, true);
        }
        else if (movementJoy.GetDirectionVector().x < 0)
        {
            animControl.SetBool(animMoveBackwardName, true);
        }
    }

    private void CheckMovementJoyActive()
    {
        if (!movementJoy.isActive)
        {
            animControl.SetBool(animMoveForwardName, false);
            animControl.SetBool(animMoveBackwardName, false);
        }
    }
}
