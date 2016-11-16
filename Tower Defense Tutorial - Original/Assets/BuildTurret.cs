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
        addY.y+= 5;

        // Instanciates the Turret Chooser menu
        GameObject turretSelectMenu = (GameObject)Instantiate(turretSelector, addY, transform.rotation);

        // Gets a reference to the turret chooser component which is the script for the Turret Select menu
        TurretChooser placeToBuild = turretSelectMenu.GetComponent<TurretChooser>();

        // Passes a reference to the turret menu to the Turret Chooser object
        placeToBuild.turretMenu = turretSelectMenu;

        // Passes a reference of the turret spawn point's, right now it's the box, transform to the Turret Chooser script
        placeToBuild.buildHere = gameObject.transform;
       
    }
}
