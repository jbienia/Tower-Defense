using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour {

    public static GameplayUI inGameUserInterface = null;
    public Transform[] userComponents;
    private int childCount;
    public Text bank;
    public Text lives;
   public  Image enemyImage;
    public Transform panel;
    public Text countdown;
    

	// Use this for initialization
	void Start () {
        
        if(inGameUserInterface == null)
        {
            inGameUserInterface = this;
        }

       // inGameUserInterface.
         panel = inGameUserInterface.transform.GetChild(0);
        

       childCount = panel.childCount;
       
        Debug.Log(childCount);

        for(int i = 0; i < childCount;i++)
        {
            userComponents = new Transform[childCount];

            userComponents[i] = panel.transform.GetChild(i);

            if (userComponents[i].name == "Bank")
            {
                bank = userComponents[i].GetComponent<Text>();
            }

            else if (userComponents[i].name == "Lives")
            {
                lives = userComponents[i].GetComponent<Text>();
            }

           if (userComponents[i].name == "Enemy")
            {
                enemyImage = userComponents[i].GetComponent<Image>();
                
            }

           if(userComponents[i].name == "Countdown")
            {
                countdown = userComponents[i].GetComponent<Text>();
            }
        }

        
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
