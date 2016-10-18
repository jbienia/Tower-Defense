using UnityEngine;


public class Waypoints : MonoBehaviour {

	public static Transform[] points;

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
