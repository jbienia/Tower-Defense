using UnityEngine;
using System.Collections;

public class TurretChooser : MonoBehaviour {

    public GameObject arrowTurret;
    public GameObject canonTurret;
    public GameObject artilleryTurret;
    public GameObject magicTurret;
    public Transform buildHere;
    public GameObject turretMenu;

	

   public void CreateArrowTurret()
    {
        Debug.Log(buildHere);
        Instantiate(arrowTurret, buildHere.position,buildHere.rotation);
        Destroy(turretMenu);
    }

    public void CreateCanonTurret()
    {
        Instantiate(canonTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu);
    }

    public void CreateMagicTurret()
    {
        Instantiate(magicTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu);
    }

    public void CreateArtilleryTurret()
    {
        Instantiate(artilleryTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu);
    }
}
