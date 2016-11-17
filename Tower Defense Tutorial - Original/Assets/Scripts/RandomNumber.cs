using UnityEngine;
using System.Collections;

public class RandomNumber : MonoBehaviour {

    public static int[] randomValue = new int [] { 1, 2 };
    public static int value;
	
	// Update is called once per frame
	public static  int randomNumber ()
    {
        
       
        
      value = Random.Range(0, randomValue.Length);
        
        return randomValue[value];
	}
}
