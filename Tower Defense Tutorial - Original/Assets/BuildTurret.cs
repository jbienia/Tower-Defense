using UnityEngine;
using System.Collections;

public class BuildTurret : MonoBehaviour {

    private Color initialColor;
    
    void OnMouseOver()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
       
        Debug.Log("change to red");
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.color = initialColor;
    }
	// Use this for initialization
	void Start ()
    {
        initialColor = gameObject.GetComponent<Renderer>().material.color;
	}

    void OnMouseDown()
    {
        Debug.Log("Build that  trret!!");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
