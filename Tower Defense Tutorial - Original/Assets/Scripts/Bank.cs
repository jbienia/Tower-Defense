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

        bank.playerBalanceTextComponent = bank.playerMoney.GetComponentInChildren<Text>();
        bank.playerBalanceTextComponent.text = bank.playerBank.ToString("C0");

        // Sets the values of the bank singleton object
       // bank.magicPrice = this.magicPrice;
        //bank.canonPrice = this.canonPrice;
        //bank.arrowPrice = this.arrowPrice;
        Debug.Log(bank.playerBank);
        //Debug.Log(bank.);
            
    }

    /// <summary>
    /// Displays the starting balance of the bank
    /// </summary>
    public void Update()
    {
       //if(bank.playerBank < 175)
        //{

//        }
    }

    /// <summary>
    /// Purchase a canon from the bank
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
