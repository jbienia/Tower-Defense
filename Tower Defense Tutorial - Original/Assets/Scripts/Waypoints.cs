using UnityEngine;

/// <summary>
/// Class that contains a static array of waypoints
/// </summary>
public class Waypoints : MonoBehaviour {

    // A static array of Transfrom type
	public static Transform[] points;

    /// <summary>
    /// Stores all Childen of the Waypoint gameobject in an array
    /// </summary>
    void Awake()
    {
        // sets the size of the array by the amount of Waypoints children
        points = new Transform[transform.childCount];

        // Loops throught the children and stores all of the transforms in an array
        for(int i = 0; i < points.Length;i++)
        {
           points[i] = transform.GetChild(i);
        }
    }
}
