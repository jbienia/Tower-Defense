using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public  class BuildTurret:MonoBehaviour  {

    private Color initialColor;
    public GameObject turretSelector;
    public RectTransform turretSelectorPanel;
    public GameObject box;
    public AudioClip click;
    //public static Vector2 WorldObject_ScreenPosition;


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
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //if(Physics.Raycast(ray, out hit))
        //    {
        //    Debug.Log(hit.transform.tag);
        //}
        
        //  EventSystem.current.IsPointerOverGameObject()
        //if (hit.transform.tag == "Arrow")
        //{
        //    Debug.Log("Hitting the Event System");
        //    return;
        //}

        //Debug.Log(EventSystem.current.currentSelectedGameObject);

        if(Input.GetMouseButtonDown(0) && EventSystem.current.currentSelectedGameObject != null)
        {
            //Debug.Log("yep");
            //Debug.Log(EventSystem.current.currentSelectedGameObject.tag);
        }
       
        Vector3 addY = this.transform.position;
        
        addY.y+= 4;

        AudioManager.audioManager.playBoxClick(click);
        

        GameObject turretSelectMenu = (GameObject)Instantiate(turretSelector,addY,transform.rotation);
        
        RectTransform CanvasRect = turretSelectMenu.GetComponent<RectTransform>();

       RectTransform panel = (RectTransform)turretSelectMenu.transform.GetChild(0);

        // Takes the the Spawnpoint position in world space and converts it to a Vector 2 in screen/viewport space.
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(gameObject.transform.position);

        Debug.Log(ViewportPosition.x * CanvasRect.sizeDelta.x);

        Debug.Log(CanvasRect.sizeDelta.x * 0.5f);

        //
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));

        // Debug.Log(WorldObject_ScreenPosition);

        //now you can set the position of the ui element
        panel.anchoredPosition = WorldObject_ScreenPosition;
        
        // Gets a reference to the turret chooser component which is the script for the Turret Select menu
        TurretChooser placeToBuild = turretSelectMenu.GetComponent<TurretChooser>();

        // Passes a reference to the turret menu to the Turret Chooser object
        placeToBuild.turretMenu = turretSelectMenu;

        // Passes a reference of the turret spawn point's, right now it's the box, transform to the Turret Chooser script
        placeToBuild.buildHere = gameObject.transform;
       // turretSelectMenu.transform.GetChild(0).GetChild(0).SetParent(null);
       
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 10f);
        
    }
}
