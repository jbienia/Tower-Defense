using UnityEngine;
// uses this to access the IsPointerOverGameObject ()
using UnityEngine.EventSystems;


public class Node : MonoBehaviour {

    public Color hoverColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;
    public Color notEnoughMoneyColor;
    BuildManager buildManager;

    void Start()
    {
        // A reference to the renderer component
        rend = GetComponent<Renderer>();

        // A reference to the color of the material on the nodes
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    /// <summary>
    /// Returns the transform of the desired place to build the turret
    /// </summary>
    /// <returns></returns>
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    /// <summary>
    /// Method checks if we can build a turret on the specific node
    /// </summary>
    void OnMouseDown()
    {

        // Checks if the mouse is over a game object
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        // IF the user clicks on the nodes but has not chosen a turret
        if(!buildManager.CanBuild)
        {
            Debug.Log("TESTING!!//");
            return;
        }

        // Checks if node already has a turret
        if (turret != null)
        {
            Debug.Log("Can't build here! To do Display on Screen");
            return;
        }

        // builds a turret
        buildManager.BuildTurretOn(this);
    }

    /// <summary>
    /// Sets a specific color when a mouse hovers over a node
    /// </summary>
	void OnMouseEnter ()
    {
        // Checks if the mouse is over a game object
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    /// <summary>
    /// Sets a specific color when the mouse exists the node
    /// </summary>
    void OnMouseExit ()
    {
        rend.material.color = startColor;
    }
}
