using UnityEngine;


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
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
        
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected");
        buildManager.SelectTurretToBuild(missleLauncher);
    }

    public void SelectHorseTurret()
    {
        buildManager.SelectTurretToBuild(horseTurret);
        
    }
        
}
