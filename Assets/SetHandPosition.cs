using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SetHandPosition : MonoBehaviour {
    GameObject leftHand, rightHand, leftHandTarget, rightHandTarget;
	// Use this for initialization
	void Start () {
        leftHand = GameObject.Find("L_ArmTarget");
        rightHand = GameObject.Find("R_ArmTarget");
        leftHandTarget = GameObject.Find("L_HandPosition");
        rightHandTarget = GameObject.Find("R_HandPosition");
	}
	
	// Update is called once per frame
	void Update () {
        leftHand.transform.position = leftHandTarget.transform.position;
        rightHand.transform.position = rightHandTarget.transform.position;
	}
}
