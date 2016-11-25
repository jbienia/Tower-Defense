using UnityEngine;
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

    /*
    public void Update()
    {
        if (Bank.bank.playerBank < Bank.bank.magicPrice)
        {

            magicButton.interactable = false;
        }

        else
        {
            magicButton.interactable = true;
        }

        if (Bank.bank.playerBank < Bank.bank.canonPrice)
        {
            canonButton.interactable = false;
        }

        else
        {
            canonButton.interactable = true;
        }

        if (Bank.bank.playerBank < Bank.bank.arrowPrice)
        {
            arrowButton.interactable = false;
        }

        else
        {
            arrowButton.interactable = true;
        }


    }

    */

    public void CreateArrowTurret()
    {
       
        Instantiate(arrowTurret, buildHere.position,buildHere.rotation);
        
        Destroy(turretMenu,0.5f);
    }

    public void CreateCanonTurret()
    {
        Instantiate(canonTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu, 0.5f);
    }

    public void CreateMagicTurret()
    {
        Instantiate(magicTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu, 0.5f);
    }

    public void CreateArtilleryTurret()
    {
        Instantiate(artilleryTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu, 0.5f);
    }

    public void CreateMortarTurret()
    {
        Instantiate(mortarTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu, 0.5f);
    }

    public void CreateElectricTurret()
    {
        Instantiate(electricTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu, 0.5f);
    }

    public void CreateFreezeTurret()
    {
        Instantiate(freezeTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu, 0.5f);
    }

   public void CancelMenu()
    {
        Destroy(gameObject);
    }
}
