using UnityEngine;
using System.Collections;

public class TrackPlayer : MonoBehaviour {
    private Camera cam;
    public int xOffset;
    public int yOffset;
    public float lerpPadding;
    public float aimingVectorMult;

    private Vector3 defaultOffset;
    private Vector3 viewOffset;
    private GameObject playerObject;
    private Vector3 lerpTarget;
    private JoystickScripts aimingJoy;

	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        FollowPlayer();
        viewOffset = new Vector3(xOffset, yOffset, 0);
	}

    public void ChangeCameraOffset(int x, int y)
    {
        viewOffset.x = x;
        viewOffset.y = y;
        viewOffset.z = 0;
    }

    private void Init()
    {
        cam = gameObject.GetComponent<Camera>();
        defaultOffset = this.gameObject.transform.position;
        playerObject = GameObject.Find("PlayerObjectContainer");
        aimingJoy = GameObject.Find("AimingJoy").GetComponent<JoystickScripts>();
    }

    private void FollowPlayer()
    {
       // this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, (playerObject.transform.position + viewOffset + defaultOffset), lerpPadding);

        Vector3 t = Vector3.zero;
        lerpTarget = playerObject.transform.position + (viewOffset + ((Vector3)aimingJoy.GetDirectionVector() * aimingVectorMult)) + defaultOffset;
        this.gameObject.transform.position = Vector3.SmoothDamp(this.gameObject.transform.position, lerpTarget, ref t, lerpPadding);
     //   this.gameObject.transform.position = playerObject.transform.position + defaultOffset+ new Vector3(xOffset, yOffset);
    }
}
