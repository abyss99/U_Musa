using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour {

    void OnDrawGizmos() {
        Gizmos.DrawIcon(transform.position + Vector3.up * 1.0f, "wayPoint");
    }
}
