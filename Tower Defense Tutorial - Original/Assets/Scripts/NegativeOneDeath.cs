using UnityEngine;
using System.Collections;

public class NegativeOneDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 1.5f);
	
	}
	
}
