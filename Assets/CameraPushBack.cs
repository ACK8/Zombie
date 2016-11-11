using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class CameraPushBack : MonoBehaviour
{
    public Transform pos;
    public Transform target;

    void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}

    void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision.transform.tag);

        // VR.InputTracking から hmd の位置を取得
        Vector3 trackingPos = InputTracking.GetLocalPosition(VRNode.CenterEye);
        target.position = pos.position - trackingPos;
    }
}
