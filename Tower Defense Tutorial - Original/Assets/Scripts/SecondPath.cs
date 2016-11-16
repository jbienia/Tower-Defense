using UnityEngine;
using System.Collections;

public class SecondPath : MonoBehaviour {

    public static Transform[] secondPath;

    // Use this for initialization
    void Awake ()
    {
        secondPath = new Transform[transform.childCount];   

        for(int i = 0; i < secondPath.Length; i++)
        {
            secondPath[i] = transform.GetChild(i);
        }
	}
}
