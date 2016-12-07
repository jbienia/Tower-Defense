using UnityEngine;
using System.Collections;

public class CoinBounceDeath : MonoBehaviour {
    

	// Use this for initialization
	void Start () {

        Destroy(this.gameObject, 1f);
	}
	
	
}
