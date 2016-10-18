using UnityEngine;
using System.Collections;

/// <summary>
/// An example of a singleton class
/// </summary>
public class BuildManager : MonoBehaviour {

    // reference used for the singleton 
    public static BuildManager instance;
    

    private TurretBlueprint turretToBuild;

    /// <summary>
    /// On Awake the an instance of building manager is created
    /// </summary>
    void Awake()
    {
        // Prevents me from building two turrets on the same spot
        if(instance != null)
        {
            Debug.LogError("Too many instances");
            return;
        }
        instance = this;
    }

    // Turret Prefab
    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;
    public GameObject buildEffect;


   // private TurretBlueprint turretToBuild;

    /// <summary>
    /// Checks if we can build a turret
    /// </summary>
    public bool CanBuild {
        get { return turretToBuild != null; } }

    public bool HasMoney
    {
        get { return PlayerStats.Money >= turretToBuild.cost; }
    }

    /// <summary>
    /// Builds turret on a specific node
    /// </summary>
    /// <param name="node"></param>
    public void BuildTurretOn(Node node)
    {
        // Checks if the player has enough money to build
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money");
            return;
        }

        // Subtracts the cost of the turret from the players current money
        PlayerStats.Money -= turretToBuild.cost;

        // Instantiates a game object with the rotation set to 0,0,0(Quaternion.identity)
      GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(),Quaternion.identity);
        
      GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        // Sets the referecne to the node turret for each node that is build on
        node.turret = turret;

        Debug.Log("Turret Built! Money left: " + PlayerStats.Money);
    }
    
    /// <summary>
    /// Selects a specifc turret to build
    /// </summary>
    /// <param name="turret"></param>
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
