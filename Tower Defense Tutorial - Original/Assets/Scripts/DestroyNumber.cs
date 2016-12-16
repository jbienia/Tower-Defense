using UnityEngine;
using System.Collections;

public class DestroyNumber : MonoBehaviour {

	public void EraseThisNumber()
    {
        Debug.Log("Destroy");
        Destroy(this.gameObject);
    }
}
