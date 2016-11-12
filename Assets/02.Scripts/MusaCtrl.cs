using UnityEngine;
using System.Collections;

public class MusaCtrl : MonoBehaviour {

    private Transform tr;
    private Animator anim;
    private NavMeshAgent nv;

    private Ray ray;
    private RaycastHit hit;

    private int floorLayer;
    private Vector3 movePos;

    public float speed = 5.0f;
    public float damping = 5.0f;

	// Use this for initialization
	void Start () {
        tr = transform;
        anim = GetComponent<Animator>();
        nv = GetComponent<NavMeshAgent>();
        floorLayer = 1 << LayerMask.NameToLayer("FLOOR");

        movePos = tr.position;

	}
	
	// Update is called once per frame
	void Update () {
        #if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if(Physics.Raycast(ray, out hit, 100.0f, floorLayer))
            {
                movePos = hit.point;
                nv.SetDestination(movePos);
                nv.Resume();
                anim.SetBool("isRun", true);
            }

            if (nv.velocity.magnitude > 0.2f && nv.remainingDistance <= 0.1f)
            {
                anim.SetBool("isRun", false);
            }
        }
        #endif

        #if UNITY_EDITOR
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 100.0f, floorLayer))
        {
            movePos = hit.point;
            nv.SetDestination(movePos);
            nv.Resume();
            anim.SetBool("isRun", true);
        }

        if (nv.velocity.magnitude > 0.2f && nv.remainingDistance <= 0.1f)
        {
            anim.SetBool("isRun", false);
        }
        #endif

//        if ((movePos - tr.position).sqrMagnitude >= 0.1f)
//        {
//            Quaternion rot = Quaternion.LookRotation(movePos - tr.position);
//            tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);
//            tr.Translate(Vector3.forward * Time.deltaTime * speed);
//        }
    }

}
