using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// Class used mainly to create turrets from turret menu
/// </summary>
public class TurretChooser : MonoBehaviour {

    public GameObject arrowTurret;
    public GameObject canonTurret;
    public GameObject artilleryTurret;
    public GameObject magicTurret;
    public GameObject mortarTurret;
    public GameObject electricTurret;
    public GameObject freezeTurret;
    private bool turretBeingBuilt = false;
    private bool helper = false;
    private int value = 1 ;
    private  bool isFirstFrame = true;

    public AudioClip turretChosen;

    // Value is set in the BuildTurret script
    public Transform buildHere;

    // Holds a reference to the spawnpoint related to this turret menu
    public BuildTurret spawnPoint;

    // Holds a reference to the turret menu game object
    public GameObject turretMenu;

    private void Start()
    {
        DestroyMenuOnClick menuDestroy = gameObject.GetComponent<DestroyMenuOnClick>();
        Debug.Log(menuDestroy);
        Debug.Log(turretMenu);
        menuDestroy.setTurretMenu(turretMenu);
        menuDestroy.setBuildTurret(spawnPoint);
    }
    //// Starts a co routine
    //public void Update()
    //{
    //    StartCoroutine(findButtonClick());
    //}

    ///// <summary>
    ///// Co routine is mainly used to determine if the menu is on the first frame of its life
    ///// If it is then we wait one second for that frame to be done before testing the mouse button down value
    ///// </summary>
    ///// <returns></returns>
    //public IEnumerator findButtonClick()
    //{
    //    // Checks if it is the first frame
    //    if (isFirstFrame == true)
    //    {

    //        isFirstFrame = false;
    //        yield return new WaitForSeconds(1);

    //        DestroyTurretMenuIfMouseClicked();
    //    }

    //    else
    //    {
    //        DestroyTurretMenuIfMouseClicked();
    //    }
    //}

    //private void DestroyTurretMenuIfMouseClicked()
    //{
    //    if (Input.GetMouseButtonDown(0) == true)
    //    {
    //        //  Debug.Log(EventSystem.current.currentSelectedGameObject);
    //        if (EventSystem.current.currentSelectedGameObject == null)
    //        {
    //            Destroy(turretMenu, 0.2f);
    //            spawnPoint.ReEnableSpawnPointLayer(spawnPoint.gameObject);
    //        }
    //    }
    //}

    //public IEnumerator waitForFrame()
    //{
    //    yield return new WaitForEndOfFrame();
    //}

    //public IEnumerator closeMenu()
    //{
    //    yield return new WaitForSeconds(1);

    //    if (turretMenu != null)
    //    {
    //          Destroy(turretMenu);
    //        spawnPoint.ReEnableSpawnPointLayer(spawnPoint.gameObject);
    //    }

    //}

    public void CreateArrowTurret()
    {
        turretBeingBuilt = true;
        AudioManager.audioManager.playTurretChoiceBloop(turretChosen);

        Instantiate(arrowTurret, buildHere.position,buildHere.rotation);
        
        Destroy(turretMenu,0.5f);
        spawnPoint.ReEnableSpawnPointLayer(spawnPoint.gameObject);
    }

    public void CreateCanonTurret()
    {
        turretBeingBuilt = true;
        AudioManager.audioManager.playTurretChoiceBloop(turretChosen);
        Instantiate(canonTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu, 0.5f);
        spawnPoint.ReEnableSpawnPointLayer(spawnPoint.gameObject);
    }

    public void CreateMagicTurret()
    {
        turretBeingBuilt = true;
        AudioManager.audioManager.playTurretChoiceBloop(turretChosen);
        Instantiate(magicTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu, 0.5f);
        spawnPoint.ReEnableSpawnPointLayer(spawnPoint.gameObject);
    }

    public void CreateArtilleryTurret()
    {
        turretBeingBuilt = true;
        Instantiate(artilleryTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu, 0.5f);
        spawnPoint.ReEnableSpawnPointLayer(spawnPoint.gameObject);
    }

    public void CreateMortarTurret()
    {
        turretBeingBuilt = true;
        Instantiate(mortarTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu, 0.5f);
        spawnPoint.ReEnableSpawnPointLayer(spawnPoint.gameObject);
    }

    public void CreateElectricTurret()
    {
        turretBeingBuilt = true;
        Instantiate(electricTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu, 0.5f);
        spawnPoint.ReEnableSpawnPointLayer(spawnPoint.gameObject);
    }

    public void CreateFreezeTurret()
    {
        turretBeingBuilt = true;
        Instantiate(freezeTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu, 0.5f);
        spawnPoint.ReEnableSpawnPointLayer(spawnPoint.gameObject);
    }

   public void CancelMenu()
    {
        turretBeingBuilt = true;
        Destroy(gameObject);
   
    }
}
