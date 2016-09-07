using UnityEngine;
using System.Collections;


public enum IKHANDLES
{
    rightArm,
    leftArm,
    rightLeg,
    leftLeg
}


/// <summary>
/// Script used to move the character's ik handles to different places
/// </summary>
public class IKMovementScript : MonoBehaviour {

    private GameObject[] IKTargets = new GameObject[4];

	// Use this for initialization
	void Start () {
        InitIKTargetObjects();
	}


    /// <summary>
    /// Move an ik handle to the position of the target by finding it via its index in the ik handle array
    /// </summary>
    /// <param name="target">The target gameobject that the ik handle will move to.</param>
    /// <param name="ikhandle">The ik handle that will be moved</param>
    public void MoveIKTarget(GameObject target, int ikhandle)
    {
        IKTargets[ikhandle].transform.parent = target.transform;
        IKTargets[ikhandle].transform.position = target.transform.position;
    }


    /// <summary>
    /// Move an ik handle to the position of the target by finding it via its name.
    /// </summary>
    /// <param name="target">The target gameobject that the ik handle will move to.</param>
    /// <param name="ikhandle">The ik handle that will be moved</param>
    public void MoveIKTarget(GameObject target, string ikhandle)
    {
        string s = ikhandle.ToLower();
        
        if(s.Contains("right") && s.Contains("arm"))
        {
            MoveIKTarget(target, 0);
        }
        else if(s.Contains("left") && s.Contains("arm"))
        {
            MoveIKTarget(target, 1);
        }
        else if (s.Contains("right") && s.Contains("leg"))
        {
            MoveIKTarget(target, 2);
        }
        else if(s.Contains("left") && s.Contains("leg"))
        {
            MoveIKTarget(target, 3);
        }
    }

    private void InitIKTargetObjects()
    {
        IKTargets[(int)IKHANDLES.rightArm] = GameObject.Find("R_ArmTarget");
        IKTargets[(int)IKHANDLES.leftArm] = GameObject.Find("L_ArmTarget");
        IKTargets[(int)IKHANDLES.rightLeg] = GameObject.Find("R_LegTarget");
        IKTargets[(int)IKHANDLES.leftLeg] = GameObject.Find("L_LegTarget");
    }


}
