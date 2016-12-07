using UnityEngine;
using System.Collections;

public  class BuildTurret:MonoBehaviour  {

    private Color initialColor;
    public GameObject turretSelector;
    public GameObject box;
    public AudioClip click;
    
    void OnMouseOver()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
       
       
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
        
        Vector3 addY = transform.position;
      //  Vector3 pos = transform.localToWorldMatrix
        addY.y+= 4;

        AudioManager.audioManager.playBoxClick(click);

        // Instanciates the Turret Chooser menu
        GameObject turretSelectMenu = (GameObject)Instantiate(turretSelector, addY, transform.rotation);

        turretSelectMenu.transform.LookAt(Camera.main.transform);

        // Gets a reference to the turret chooser component which is the script for the Turret Select menu
        TurretChooser placeToBuild = turretSelectMenu.GetComponent<TurretChooser>();

        // Passes a reference to the turret menu to the Turret Chooser object
        placeToBuild.turretMenu = turretSelectMenu;

        // Passes a reference of the turret spawn point's, right now it's the box, transform to the Turret Chooser script
        placeToBuild.buildHere = gameObject.transform;
       
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 10f);
        
    }
}
