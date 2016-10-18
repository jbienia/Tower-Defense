using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {

    public static Transform[] ground;

    void Awake()
    {
        // sets the size of the array by the amount of Waypoints children
        ground = new Transform[transform.childCount];

        // Loops throught the children and stores all of the transforms in an array
        for (int i = 0; i < ground.Length; i++)
        {
            ground[i] = transform.GetChild(i);
        }
    }
}
