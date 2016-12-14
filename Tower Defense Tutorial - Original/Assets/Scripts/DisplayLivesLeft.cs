using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayLivesLeft : MonoBehaviour {

    private static float livesLeft = 10;
    private static  Text livesOnScreen;
    public GameObject resetButton;

    //private void Start()
    //{
    //    livesLeft = 10;
    //}

    public void GetReferenceToPanelInUi()
    {
        Transform panel;
        
          panel = GameplayUI.inGameUserInterface.transform.GetChild(0);

        Transform[] children = new Transform[panel.childCount];

        for (int i = 0; i < panel.childCount; i++)
        {
            children[i] = panel.GetChild(i);

            if (children[i].name == "Lives")
            {
                livesOnScreen = children[i].GetComponent<Text>();
                livesOnScreen.text = "Lives " + livesLeft;
            }
        }
    }

    public void DecreaseLivesLeftOnUi()
    {
        livesLeft--;

        livesOnScreen.text = "Lives " + livesLeft;

        if(livesLeft == 0)
        {
            Instantiate(resetButton);
            //RestartLevel restartLevel = GetComponent<RestartLevel>();
            //restartLevel.reLoadLevel();
        }
    }

    public void setLivesLeft()
    {
        livesLeft = 10;
    }
}
