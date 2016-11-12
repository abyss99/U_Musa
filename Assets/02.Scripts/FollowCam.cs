using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {
    public Transform target;
    public float distance = 5.0f;
    public float height = 4.0f;
    public float damping = 5.0f;

    private Transform camTr;

	// Use this for initialization
	void Start () {
        camTr = GetComponent<Transform>();
	}
	
	void LateUpdate () {
        Vector3 camPos = target.position + (Vector3.right * distance) + (Vector3.up * height);
        camTr.position = Vector3.Lerp(camTr.position, camPos, Time.deltaTime * damping);
        camTr.LookAt(target);
	}
}
