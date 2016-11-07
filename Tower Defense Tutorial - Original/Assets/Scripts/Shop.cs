using UnityEngine;

/// <summary>
/// Class used in the prototype to select a turret from the shop. This class is currently not in use
/// </summary>
public class Shop : MonoBehaviour {

    // References to the TurretBlueprint class has a Game Object and Cost 
    public TurretBlueprint standardTurret;
    public TurretBlueprint missleLauncher;
    public TurretBlueprint horseTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
       buildManager.SelectTurretToBuild(standardTurret);
        
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missleLauncher);
    }

    public void SelectHorseTurret()
    {
        buildManager.SelectTurretToBuild(horseTurret);
    }
}
