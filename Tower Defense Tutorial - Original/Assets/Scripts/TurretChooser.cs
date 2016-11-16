﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurretChooser : MonoBehaviour {

    public GameObject arrowTurret;
    public GameObject canonTurret;
    public GameObject artilleryTurret;
    public GameObject magicTurret;
    public GameObject mortarTurret;
    public GameObject electricTurret;
    public GameObject freezeTurret;

    // Value is set in the BuildTurret script
    public Transform buildHere;

    //
    public GameObject turretMenu;
    
	

    public void CreateArrowTurret()
    {
       
        Instantiate(arrowTurret, buildHere.position,buildHere.rotation);
        
        Destroy(turretMenu,4f);
    }

    public void CreateCanonTurret()
    {
        Instantiate(canonTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu,4f);
    }

    public void CreateMagicTurret()
    {
        Instantiate(magicTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu, 4f);
    }

    public void CreateArtilleryTurret()
    {
        Instantiate(artilleryTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu, 4f);
    }

    public void CreateMortarTurret()
    {
        Instantiate(mortarTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu,4f);
    }

    public void CreateElectricTurret()
    {
        Instantiate(electricTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu, 4f);
    }

    public void CreateFreezeTurret()
    {
        Instantiate(freezeTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu, 4f);
    }
}
