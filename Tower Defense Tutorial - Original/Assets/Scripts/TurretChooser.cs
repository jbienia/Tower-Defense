using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    public  bool isFirstFrame = true;

    public AudioClip turretChosen;

    // Value is set in the BuildTurret script
    public Transform buildHere;

    //

    public GameObject turretMenu;

    /// <summary>
    /// This update is a complicated way that does something that is not really necessary.
    /// </summary>
    //public void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {

    //        PointerEventData pointer = new PointerEventData(EventSystem.current);

    //        pointer.position = Input.mousePosition;

    //       // Debug.Log(pointer.position);
    //        List<RaycastResult> raycastResults = new List<RaycastResult>();

    //        EventSystem.current.RaycastAll(pointer, raycastResults);

    //        if(raycastResults.Count > 0)
    //        {

    //            for (int i = 0; i < raycastResults[0].gameObject.transform.childCount - 1; i++)
    //            {
    //                if (raycastResults[0].gameObject.transform.GetChild(i).tag == "arrow")
    //                {
    //                    Debug.Log("i clicked arrow!");
    //                    // return;
    //                }

    //                else
    //                {
    //                    Debug.Log("not an icon click");
    //                    Destroy(turretMenu);
    //                }
    //            }


    //        }

    //        /*THIS IS COMMENTED OUT!!!!
    //        RaycastHit hit;

    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //        Physics.Raycast(ray, out hit, 100);

    //        //  EventSystem.current.IsPointerOverGameObject()
    //        if (hit.transform.tag =="Arrow" || hit.transform.tag == "SpawnPoint")
    //        {
    //            Debug.Log("Hitting the Event System");
    //            return;
    //        }

    //        else
    //        {

    //            Destroy(turretMenu);
    //        }

    //        */
    //    }
    //}


    //public void Update()
    //{

    //    Debug.Log(Input.GetMouseButtonDown(0));
    //   // StartCoroutine(wait());
    //    if (Input.GetMouseButton(0))
    //    {
    //       //Debug.Log( EventSystem.current.currentSelectedGameObject);

    //        StartCoroutine(wait());

    //    }

    //}

    public void Update()
    {
        //StartCoroutine(newThang());
        StartCoroutine(findButtonClick());
    }

    public IEnumerator newThang()
    {
        if(isFirstFrame == true)
        {
           yield return new WaitForSeconds(1);

            isFirstFrame = false;


            if (Input.GetMouseButton(0) == true)
            {
                Destroy(turretMenu, 1f);

            }
        }

       

       else if (isFirstFrame == false)
        {
            

            if (Input.GetMouseButton(0) == true)
            {
             

                if (turretMenu != null)
                {
                    Destroy(turretMenu,1f);
                }

            }

        }
    }

    

    public IEnumerator findButtonClick()
    {
        if (isFirstFrame == true)
        {
            //Debug.Log("osue isd soen");
            isFirstFrame = false;
            yield return new WaitForSeconds(1);
            

            if (Input.GetMouseButtonDown(0) == true)
            {
                
                //Debug.Log(EventSystem.current.currentSelectedGameObject);
                if (EventSystem.current.currentSelectedGameObject==null)
                {

                    Destroy(turretMenu, 1f);
                }
            }
       }

        else if (isFirstFrame == false)
        {
           // Debug.Log("it's false");
            if (Input.GetMouseButtonDown(0) == true)
            {
              //  Debug.Log(EventSystem.current.currentSelectedGameObject);
                if (EventSystem.current.currentSelectedGameObject == null)
                {
                    
                    Destroy(turretMenu, 1f);
                }


            }
        }
    }

    //public IEnumerator Start()
    //{
    //    helper = true;
    //    yield return new WaitForSeconds(5);

    //    InvokeRepeating("UpdateTarget", 0f, 0.06f);
    //}

    //public void UpdateTarget()
    //{

    //    Debug.Log(Input.GetMouseButtonDown(0));

    //    // StartCoroutine(wait());
    //    if (Input.GetMouseButton(0) == true)
    //    {
    //        Debug.Log( EventSystem.current.currentSelectedGameObject);

    //        StartCoroutine(wait());

    //    }
    //}

    public IEnumerator waitForFrame()
    {
        yield return new WaitForEndOfFrame();
    }

    public IEnumerator closeMenu()
    {
        yield return new WaitForSeconds(1);

        if (turretMenu != null)
        {
              Destroy(turretMenu);
        }
      
    }
    
    public void CreateArrowTurret()
    {
        turretBeingBuilt = true;
        AudioManager.audioManager.playTurretChoiceBloop(turretChosen);

        Instantiate(arrowTurret, buildHere.position,buildHere.rotation);
        
        Destroy(turretMenu,0.5f);
    }

    public void CreateCanonTurret()
    {
        turretBeingBuilt = true;
        AudioManager.audioManager.playTurretChoiceBloop(turretChosen);
        Instantiate(canonTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu, 0.5f);
    }

    public void CreateMagicTurret()
    {
        turretBeingBuilt = true;
        AudioManager.audioManager.playTurretChoiceBloop(turretChosen);
        Instantiate(magicTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu, 0.5f);
    }

    public void CreateArtilleryTurret()
    {
        turretBeingBuilt = true;
        Instantiate(artilleryTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu, 0.5f);
    }

    public void CreateMortarTurret()
    {
        turretBeingBuilt = true;
        Instantiate(mortarTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu, 0.5f);
    }

    public void CreateElectricTurret()
    {
        turretBeingBuilt = true;
        Instantiate(electricTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu, 0.5f);
    }

    public void CreateFreezeTurret()
    {
        turretBeingBuilt = true;
        Instantiate(freezeTurret, buildHere.position, buildHere.rotation);
        Destroy(turretMenu, 0.5f);
    }

   public void CancelMenu()
    {
        turretBeingBuilt = true;
        Destroy(gameObject);
    }
}
