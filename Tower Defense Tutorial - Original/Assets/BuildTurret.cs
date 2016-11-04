using UnityEngine;
using System.Collections;

public  class BuildTurret:MonoBehaviour  {

    private Color initialColor;
    public GameObject turretSelector;
    public GameObject box;
    
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
        Vector3 addY = transform.position;
        addY.y+= 10;

      GameObject turretSelectMenu = (GameObject)Instantiate(turretSelector, addY, transform.rotation);

        TurretChooser placeToBuild = turretSelectMenu.GetComponent<TurretChooser>();

        //Debug.Log(placeToBuild.buildHere);
        //Debug.Log(box.transform);
        placeToBuild.turretMenu = turretSelectMenu;
        placeToBuild.buildHere = gameObject.transform;

        //newTurret.transform.position = transform.position;
    }

    void buildCanon()
    {

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
