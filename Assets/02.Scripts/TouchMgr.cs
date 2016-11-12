using UnityEngine;
using System.Collections;

public class TouchMgr : MonoBehaviour {

    private Ray ray;
    private RaycastHit hit;
	
	// Update is called once per frame
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.green);

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 8))
        {
            Destroy(hit.collider.gameObject);
            ExpBox(hit.point);
        }
	}

    void ExpBox(Vector3 pos) {
        Collider[] max = Physics.OverlapSphere(pos, 10.0f, 1 << 9);
        for (int i = 0; i < max.Length; i++)
        {
            max[i].GetComponent<Rigidbody>().AddExplosionForce(1500.0f, pos, 10.0f, 1000.0f);
        }
    }
}
