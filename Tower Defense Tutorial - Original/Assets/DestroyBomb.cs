using UnityEngine;
using System.Collections;

public class DestroyBomb : MonoBehaviour {

    
	void OnCollisionEnter(Collision collision)
    {
        
        Debug.Log("DEStroy myBOMB!!");
        if (collision.gameObject.tag == "CanonBomb")
        {
            Debug.Log("DEStroy myBOMB!!");
            Vector3 dir = transform.position - collision.gameObject.transform.position;
            if(dir.magnitude < 2)
            {
                Debug.Log("DEStroy myBOMB!!");
                Destroy(collision.gameObject);
                
            }
        }
    }
}
