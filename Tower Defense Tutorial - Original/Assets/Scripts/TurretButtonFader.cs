using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// This class is a component of Turret Selector
/// </summary>
public class TurretButtonFader : MonoBehaviour {

    // The Canon Button
    public Button canonButton;

    // The Arrow Button
    public Button arrowButton;

    // The Magic Button
    public Button magicButton;

    // The Artillery Button
    public Button artilleryButton;

    public Button mortarButton;

    public Button electricityButton;

    public Button freezeButton;

    public Button cancelButton;

    // Boolean used to check if a tower is chosen
    private bool towerChosen = false;

    // Array of buttons
    Button[] towerButtons;


    /*
     * Many of these methods are called using the on click events of the button in the inspector
     */


    public void Update()
    {
      
        if (Bank.bank.playerBank < Bank.bank.magicPrice)
        {
           
            magicButton.interactable = false;
        }

        else
        {
            magicButton.interactable = true;
        }

        if(Bank.bank.playerBank < Bank.bank.canonPrice)
        {
            canonButton.interactable = false;
        }

        else
        {
            canonButton.interactable = true;
        }

        if(Bank.bank.playerBank < Bank.bank.arrowPrice)
        {
            arrowButton.interactable = false;
        }

        else
        {
            arrowButton.interactable = true;
        }


    }

    

    /// <summary>
    /// Causes the Canon button to non interactable and fades it from view
    /// </summary>
    public void FadeCanonIcon()
    {
        // Causes the button to be non interactible
        canonButton.interactable = false;

        // Sets the type of transition to be applied when the state changes. I think that zero means there is no transition applied.
        canonButton.transition = 0;

        // Causes a fade on the canon button
        canonButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 0.5f, false);
    }

    /// <summary>
    /// Causes the Magic button to non interactable and fades it from view
    /// </summary>
    public void FadeMagicIcon()
    {
        // Causes the button to be non interactible
        magicButton.interactable = false;

        // Sets the type of transition to be applied when the state changes. I think that zero means there is no transition applied.
        magicButton.transition = 0;

        // Causes a fade on the canon button
        magicButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 0.5f, false);
    }

    /// <summary>
    /// Causes the Artillery button to non interactable and fades it from view
    /// </summary>
    public void FadeArtilleryIcon()
    {
        // Causes the button to be non interactible
        artilleryButton.interactable = false;

        // Sets the type of transition to be applied when the state changes. I think that zero means there is no transition applied.
        artilleryButton.transition = 0;

        // Causes a fade on the canon button
        artilleryButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 0.5f, false);
    }

    /// <summary>
    /// Causes the Arrow button to non interactable and fades it from view
    /// </summary>
    public void FadeArrowIcon()
    {
        // Causes the button to be non interactible
        arrowButton.interactable = false;

        // Sets the type of transition to be applied when the state changes. I think that zero means there is no transition applied.
        arrowButton.transition = 0;

        // Causes a fade on the canon button
        arrowButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 0.5f, false);
    }

    public void FadeMortarIcon()
    {
        // Causes the button to be non interactible
        mortarButton.interactable = false;

        // Sets the type of transition to be applied when the state changes. I think that zero means there is no transition applied.
        mortarButton.transition = 0;

        // Causes a fade on the canon button
        mortarButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 0.5f, false);
    }

    public void FadeElectricityIcon()
    {
        // Causes the button to be non interactible
        electricityButton.interactable = false;

        // Sets the type of transition to be applied when the state changes. I think that zero means there is no transition applied.
        electricityButton.transition = 0;

        // Causes a fade on the canon button
        electricityButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 0.5f, false);
    }

    public void FadeFreezeIcon()
    {
        // Causes the button to be non interactible
        freezeButton.interactable = false;

        // Sets the type of transition to be applied when the state changes. I think that zero means there is no transition applied.
        freezeButton.transition = 0;

        // Causes a fade on the canon button
        freezeButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 0.5f, false);
    }

    /// <summary>
    /// Sets the interactibilty to false and fades out the button visually
    /// </summary>
    public void arrowChosen()
    {
        arrowButton.interactable = false;
        arrowButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 0.5f, false);
    }

    /// <summary>
    /// Sets the interactibilty to false and fades out the button visually
    /// </summary>
    public void magicChosen()
    {
        magicButton.interactable = false;
        magicButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 0.5f, false);
    }

    /// <summary>
    /// Sets the interactibilty to false and fades out the button visually
    /// </summary>
    public void artilleryChosen()
    {
        artilleryButton.interactable = false;
        artilleryButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 0.5f, false);
    }

    /// <summary>
    /// Sets the interactibilty to false and fades out the button visually
    /// </summary>
    public void canonChosen()
    {
        canonButton.interactable = false;
        canonButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 0.5f, false);
    }

    public void mortarChosen()
    {
        mortarButton.interactable = false;
        canonButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 0.5f, false);
    }

    public void freezeChosen()
    {
        freezeButton.interactable = false;
        freezeButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 0.5f, false);
    }

    public void electricityChosen()
    {
        electricityButton.interactable = false;
        electricityButton.GetComponent<Image>().CrossFadeAlpha(0.1f, 0.5f, false);
    }

    /// <summary>
    /// Sets a parameter than lets us know if a tower has been chosen
    /// </summary>
    public void fadeIcons()
    {
        towerChosen = true;
    }
}
