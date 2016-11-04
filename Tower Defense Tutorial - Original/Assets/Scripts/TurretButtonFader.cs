using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurretButtonFader : MonoBehaviour {

    public Button canonButton;
    public Button arrowButton;
    public Button magicButton;
    public Button artilleryButton;
    private bool towerChosen = false;
    Button[] towerButtons;

    /*
    public void Update()
        
    {
        
        if(towerChosen)
        {
           towerButtons = gameObject.GetComponentsInChildren<Button>();
           
            foreach (Button button in towerButtons)
            {
                button.interactable = false;
            }
            towerChosen = false;
        }
    }
    
    */
    public void FadeCanonIcon()
    {
        canonButton.interactable = false;
        canonButton.transition = 0;
        // Causes a fade on the canon button
        canonButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 2.0f, false);
    }

    public void FadeMagicIcon()
    {
        magicButton.interactable = false;
        magicButton.transition = 0;
        // Causes a fade on the canon button
        magicButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 2.0f, false);
    }

    public void FadeArtilleryIcon()
    {
        artilleryButton.interactable = false;
        artilleryButton.transition = 0;
        // Causes a fade on the canon button
        artilleryButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 2.0f, false);
    }

    public void FadeArrowIcon()
    {
        arrowButton.interactable = false;
        arrowButton.transition = 0;
        // Causes a fade on the canon button
        arrowButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 2.0f, false);
    }

    public void arrowChosen()
    {
        //towerChosen = true;
        arrowButton.interactable = false;
        arrowButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 3.0f, false);
    }

    public void magicChosen()
    {
        //towerChosen = true;
        magicButton.interactable = false;
        magicButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 3.0f, false);
    }

    public void artilleryChosen()
    {
       // towerChosen = true;
        artilleryButton.interactable = false;
        artilleryButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 3.0f, false);
    }
    public void canonChosen()
    {
        //towerChosen = true;
        canonButton.interactable = false;
        canonButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 3.0f, false);
    }

    public void fadeIcons()
    {
        towerChosen = true;
    }
}
