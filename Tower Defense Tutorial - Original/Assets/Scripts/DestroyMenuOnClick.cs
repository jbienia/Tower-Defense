using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DestroyMenuOnClick : MonoBehaviour {

    private bool isFirstFrame = true;
    private GameObject turretMenu;
    private BuildTurret buildTurretScript;

    private void Start()
    {
        
    }

    public void Update()
    {
        StartCoroutine(findButtonClick());
    }

    /// <summary>
    /// Co routine is mainly used to determine if the menu is on the first frame of its life
    /// If it is then we wait one second for that frame to be done before testing the mouse button down value
    /// </summary>
    /// <returns></returns>
    public IEnumerator findButtonClick()
    {
        // Checks if it is the first frame
        if (isFirstFrame == true)
        {

            isFirstFrame = false;
            yield return new WaitForSeconds(1);

            DestroyTurretMenuIfMouseClicked(buildTurretScript,turretMenu);
        }

        else
        {
            DestroyTurretMenuIfMouseClicked(buildTurretScript, turretMenu);
        }
    }

    private void DestroyTurretMenuIfMouseClicked(BuildTurret spawnPoint,GameObject turretMenu)
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            //  Debug.Log(EventSystem.current.currentSelectedGameObject);
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                Destroy(turretMenu, 0.2f);
                spawnPoint.ReEnableSpawnPointLayer(spawnPoint.gameObject);
            }
        }
    }

    public void setTurretMenu(GameObject turretMenu)
    {
       this.turretMenu = turretMenu;
    }

    public void setBuildTurret(BuildTurret spawnPoint)
    {
        this.buildTurretScript = spawnPoint;
    }
}
