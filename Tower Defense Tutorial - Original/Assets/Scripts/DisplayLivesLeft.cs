using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

    private static int livesLeft = 10;
    private Text livesOnScreen;

    private void Start()
    {
        Transform panel = GameplayUI.inGameUserInterface.transform.GetChild(0);


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
    }
}
