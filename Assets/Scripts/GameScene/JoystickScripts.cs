using UnityEngine;
using System.Collections;

public class JoystickScripts : MonoBehaviour
{

    /* Simple Joystick Script
     * Written by Kevin Pang
     * 
     * This is a script that adds joystick control functionality to games. Its aim is to be lightweight and easy to use.
     * 
     * To setup:
     * 1) Create a gameobject (preferably something that resembles a joystick)
     * 2) Attach this script to the gameobject
     * 3) Use the getters to get the joysticks to control your game!
     * 
     * */


    GameObject visualJoystickObject;

    // Maximum distance the joystick will move while tracking user input so it doesn't go all over the screen
    public float boundaryRadius;
    public bool isActive = false;

    private Vector2 resetPosition;
    private Touch stickTouch;
    private float sizeMult;

    // Time between detecting doubletaps (in ms)
    private int tapTime;
    private bool firstTap;
    private bool secondTap;
    public bool SecondTap
    {
        get;set;
    }


    // Use this for initialization
    void Start()
    {
        InitializeJoystick();
    }

    // Initialize the joystick
    private void InitializeJoystick()
    {
        visualJoystickObject = gameObject;
        resetPosition = visualJoystickObject.transform.position;
        CircleCollider2D t = gameObject.AddComponent<CircleCollider2D>();
        t.radius = boundaryRadius;
        sizeMult = 450.0f;
        tapTime = 400;
        firstTap = secondTap = false;
    }


    // Update is called once per frame
    void Update()
    {
        checkInputMobile();
        //    getDirectionVector(visualJoystickObject.transform.position);
    }

    private void CheckDoubleTap()
    {
        if (firstTap)
        {
            Debug.Log("Double tap!");
            CancelInvoke();
            FirstTapExpired();
        }
    }

    private void checkInputMobile()
    {
        UpdateJoyPosition();
       // CheckDoubleTap();
    }


    private bool SetTouchToStick()
    {
        foreach (Touch t in Input.touches)
        {
            //          Vector3 wp = Camera.main.ScreenToWorldPoint(t.position);
            //          Vector2 tPos = new Vector2(wp.x, wp.y);
            Collider2D hit = Physics2D.OverlapPoint(t.position);
            if (hit && hit.gameObject.name == this.gameObject.name)
            {
                CheckDoubleTap();
                GetComponent<CircleCollider2D>().radius = sizeMult;
                stickTouch = t;
                isActive = true;
                // Since is Active is already true, we can leverage this instead of implicitly declaring another bool
                return isActive;
            }
        }
        return false;
    }

    private void FirstTapExpired()
    {
        firstTap = false;
    }


    // Check if the user has held onto the joystick and update the joystick's position accordingly, limiting the
    // maximum movement as necessary
    private void UpdateJoyPosition()
    {
        if (SetTouchToStick())
            if (stickTouch.phase != TouchPhase.Ended)
            {
                float tfloat = boundaryRadius / 4.0f;
                if (Vector2.Distance(stickTouch.position, resetPosition) > tfloat)
                {
                    Vector2 t = stickTouch.position - (GetDirectionVector(stickTouch.position) * tfloat);
                    visualJoystickObject.transform.position = resetPosition + (stickTouch.position - t);
                }
                else { visualJoystickObject.transform.position = stickTouch.position; }
            }
            else if (stickTouch.phase == TouchPhase.Ended)
            {
                ResetJoystick();
                CheckFirstTap();
            }
    }

    private void CheckFirstTap()
    {
        if (!firstTap)
        {
            Debug.Log("First tap for: " + gameObject.name);
            firstTap = true;
            Invoke("FirstTapExpired", 0.400f);
        }
    }

    // Returns the angle based on the direction vector between the current and default position of the joystick
    public Quaternion GetDirectionAngle()
    {
        Vector2 joydir = GetDirectionVector(this.transform.position);
        Quaternion q = new Quaternion(0, 0, 0, 0);
        if (isActive)
        {
            float atan = Mathf.Atan2(joydir.x, joydir.y);
            q = Quaternion.AngleAxis(atan * -180 / Mathf.PI, new Vector3(0, 0, 1));
        }

        return q;

    }

    // Returns the direction vector between the joystick's default position and where it currently is
    public Vector2 GetDirectionVector(Vector2 a_pos)
    {
        Vector2 t = new Vector2(visualJoystickObject.transform.position.x, visualJoystickObject.transform.position.y);
        if (t == resetPosition) { return Vector2.zero; }
        Vector2 retVec = a_pos - resetPosition;
        retVec.Normalize();
        return retVec;
    }

    private void ResetJoystick()
    {
        visualJoystickObject.transform.position = resetPosition;
        GetComponent<CircleCollider2D>().radius = boundaryRadius;
        // If joystick is being reset, it's safe to assume that it isn't active
        isActive = false;
    }

}
