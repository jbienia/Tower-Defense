using UnityEngine;
using System.Collections;

public class Gizmo : MonoBehaviour {

	void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(transform.position, transform.forward * 9);
    }
}
