using UnityEngine;
using System.Collections;

/// <summary> 
/// Simple Joystick Script
/// Written by Kevin Pang
/// 
/// This is a script that adds joystick control functionality to games. Its aim is to be lightweight and easy to use.
/// 
/// <para>To setup:</para>
/// <para>1) Create a gameobject (preferably something that resembles a joystick)</para>
/// <para>2) Attach this script to the gameobject</para>
/// 3) Use the getters to get the joysticks to control your game!
/// </summary>
public class JoystickScripts : MonoBehaviour
{

    GameObject visualJoystickObject;


    /// <summary>
    /// Maximum distance the joystick will move while tracking user input so it doesn't go all over the screen
    /// </summary>
    public float boundaryRadius;
    public bool isActive = false;

    private Vector2 resetPosition;
    private Touch stickTouch;
    private float sizeMult;

    public float maxDistance;

    // Time between detecting doubletaps (in ms)
    private int tapTime;
    private bool firstTap;
    private bool secondTap;
    public bool SecondTap
    {
        get; set;
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
        UpdateJoyPosition();
      //  CheckDoubleTap();
    }

    private void CheckDoubleTap()
    {
        if (firstTap)
        {
            Debug.Log(gameObject.name + " Double tap!");
            CancelInvoke();
            FirstTapExpired();
        }
    }

    private bool SetTouchToStick()
    {
        foreach (Touch t in Input.touches)
        {
            // Vector3 wp = Camera.main.ScreenToWorldPoint(t.position);
            // Vector2 tPos = new Vector2(wp.x, wp.y);
            Collider2D hit = Physics2D.OverlapPoint(t.position);
            if (hit && hit.gameObject.name == this.gameObject.name)
            {
                CheckDoubleTap();
                GetComponent<CircleCollider2D>().radius = sizeMult;
                stickTouch = t;
                isActive = true;
                return isActive;
            }
        }
        return false;
    }

    private void FirstTapExpired()
    {
        firstTap = false;
    }

    private void UpdateJoyPosition()
    {
        if (SetTouchToStick())
            if (stickTouch.phase != TouchPhase.Ended)
            {
                float maxDistanceFromDefaultPosition = boundaryRadius / 2.0f;
                //if (Vector2.Distance(stickTouch.position, resetPosition) > maxDistanceFromDefaultPosition)
                if(Vector2.Distance(stickTouch.position, resetPosition) > maxDistance)
                {

                    if(gameObject.name == "AimingJoy")
                    {
                        Debug.Log("Aiming direction vector: " + GetDirectionVector());
                        Debug.Log("Touch position: " + stickTouch.position);
                    }
                    visualJoystickObject.transform.position = (resetPosition + (GetDirectionVector() * maxDistance));

                }
                else { visualJoystickObject.transform.position = stickTouch.position; }
            }
            else if (stickTouch.phase == TouchPhase.Ended )
            {
                ResetJoystick();
                CheckFirstTap();
            }
    }

    private void CheckFirstTap()
    {
        if (!firstTap)
        {
            firstTap = true;
            Invoke("FirstTapExpired", 0.400f);
        }
    }


    /// <summary>
    /// Returns the Quaternion that the joystick is pointed at
    /// </summary>
    /// <returns></returns>
    public Quaternion GetDirectionQuaternion()
    {
        Quaternion q = new Quaternion(0, 0, 0, 0);
        if (isActive)
        {
            Vector2 joydir = GetDirectionVector();
            float atan = Mathf.Atan2(joydir.x, joydir.y);
            q = Quaternion.AngleAxis(atan * -180 / Mathf.PI, new Vector3(0, 0, 1));
        }
        return q;
    }


    /// <summary>
    /// Returns the Angle that the joystick is pointed at
    /// </summary>
    /// <returns></returns>
    public float GetDirectionAngle()
    {
        Vector2 tVec = GetDirectionVector();
        float tAngle = Mathf.Atan2(tVec.y, tVec.x) * Mathf.Rad2Deg;
        return tAngle;
    }

    /// <summary>
    /// Get the vector that represents the direction the joystick is pointed at
    /// </summary>
    /// <returns>Direction vector representing the direction the joystick is pointed at</returns>
    public Vector2 GetDirectionVector()
    {
        //Vector2 t = new Vector2(visualJoystickObject.transform.position.x, visualJoystickObject.transform.position.y);
        Vector2 t = new Vector2(stickTouch.position.x, stickTouch.position.y);

        if (!isActive) { return Vector2.zero; }
        Vector2 retVec = (Vector2)stickTouch.position - resetPosition;
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
