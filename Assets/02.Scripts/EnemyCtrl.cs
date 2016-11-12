using UnityEngine;
using System.Collections;

public class EnemyCtrl : MonoBehaviour {
    [SerializeField]
    private Transform[] wayPoints;

    [SerializeField]
    private int nextIdx = 4;
    private Transform playerTr;

    private Transform tr;
    public float speed = 3.0f;
    public float damping = 3.0f;
    public float traceDist = 3.0f;
    private Vector3 target;

	void Start () {
        tr = GetComponent<Transform>();
        wayPoints = GameObject.Find("WayPointGroup").GetComponentsInChildren<Transform>();
        playerTr = GameObject.FindGameObjectWithTag("PLAYER").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(playerTr.position, tr.position) <= traceDist)
        {
            target = playerTr.position;
        }
        else
        {
            target = wayPoints[nextIdx].position;
        }
        Quaternion rot = Quaternion.LookRotation(target - tr.position);
        tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);
        tr.Translate(Vector3.forward * Time.deltaTime * speed);
	}

    void OnTriggerEnter(Collider coll) {
        if (coll.CompareTag("WAY_POINT"))
        {
            if (++nextIdx >= wayPoints.Length)
            {
                nextIdx = 1;
            }
        }
    }
}
