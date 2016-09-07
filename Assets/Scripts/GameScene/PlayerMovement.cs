using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeedMult = 10.0f;
    public float maxSpeed;
    private Rigidbody2D rb;
    private JoystickScripts movementJoy;

    private GameObject playerSpriteObject;
    public GameObject PlayerSpriteObject
    {
        get; set;
    }

    // Use this for initialization
    void Start()
    {
        Init();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 joyVec = movementJoy.GetDirectionVector();
        if (movementJoy.isActive && joyVec != Vector2.zero)
        {
            if (rb.velocity.magnitude < maxSpeed)
            {
                rb.velocity = movementJoy.GetDirectionVector() * moveSpeedMult;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

    }

    private void SetPlayerSpriteObject(GameObject go)
    {
        playerSpriteObject = go;
    }

    private void Init()
    {
        SetPlayerSpriteObject(this.gameObject);
        movementJoy = GameObject.Find("MovementJoy").GetComponent<JoystickScripts>();
        rb = GetComponent<Rigidbody2D>();
    }
}
