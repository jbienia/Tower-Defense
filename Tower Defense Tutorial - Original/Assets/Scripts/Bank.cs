using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class used in the prototype to select a turret from the shop. This class is currently not in use
/// </summary>
public class Bank : MonoBehaviour {

    

    BuildManager buildManager;
    public Canvas turretSelector;
   
    public int playerBank;
    public Text playerBalanceTextComponent;
    public Canvas currencyDisplay;
    private  Canvas playerMoney;
    public int arrowPrice;
     public int canonPrice;
    public int magicPrice;

    // Static object used to represent our one bank
    public static Bank bank;

    /// <summary>
    /// Creates a static instance of the bank
    /// Instanciates the Bank
    /// </summary>
    public void Awake()
    {
        if(bank != null)
        {
            return;
        }

        // stores an instance of hte bank
        bank = this;

        // Instanciates the bank canvas and stores a refernce to it
        bank.playerMoney = Instantiate(currencyDisplay);

        // Gets a reference to the Text component of the canvas
        bank.playerBalanceTextComponent = bank.playerMoney.GetComponentInChildren<Text>();

        // Sets the Value in the player bank to the Bank Canvas on the users screen
        bank.playerBalanceTextComponent.text = bank.playerBank.ToString("C0");

        
                   
    }

    /// <summary>
    /// Purchase a canon from the bank
    /// These methods are all used with the onClick() methods connected to the buttons in the inspector
    /// </summary>
    public void buyCanonTurret()
    {
       bank.playerBalanceTextComponent.text = (bank.playerBank - canonPrice).ToString("C0");
       bank.playerBank = bank.playerBank - canonPrice;
       
    }

    public void buyArrowTurret()
    {
        bank.playerBalanceTextComponent.text = (bank.playerBank - arrowPrice).ToString("C0");
        bank.playerBank = bank.playerBank - arrowPrice;
    }

    public void buyMagicTurret()
    {
        bank.playerBalanceTextComponent.text = (bank.playerBank - magicPrice).ToString("C0");
        bank.playerBank = bank.playerBank - magicPrice;
    }

    public void buyArtilleryTurret()
    {
        bank.playerBalanceTextComponent.text = (bank.playerBank - 200).ToString("C0");
        bank.playerBank = bank.playerBank - 200;
    }

    public void buyMortarTurret()
    {
        bank.playerBalanceTextComponent.text = (bank.playerBank - 250).ToString("C0");
        bank.playerBank = bank.playerBank - 250;
    }

    public void buyElectricityTurret()
    {
        bank.playerBalanceTextComponent.text = (bank.playerBank - 275).ToString("C0");
        bank.playerBank = bank.playerBank - 275;
    }

    public void buyFreezeTurret()
    {
        bank.playerBalanceTextComponent.text = (bank.playerBank - 300).ToString("C0");
        bank.playerBank = bank.playerBank - 300;
    }

    
}
