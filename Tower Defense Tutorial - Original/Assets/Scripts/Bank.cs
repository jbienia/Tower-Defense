using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class used in the prototype to select a turret from the shop. This class is currently not in use
/// </summary>
public class Bank : MonoBehaviour {

    // References to the TurretBlueprint class has a Game Object and Cost 
    // public TurretBlueprint standardTurret;
    //public TurretBlueprint missleLauncher;
    //public TurretBlueprint horseTurret;

    BuildManager buildManager;
    public Canvas turretSelector;
    private int canonPrice = 100;
    public int playerBank = 520;
    public Text playerBalanceTextComponent;
    public Canvas currencyDisplay;
    private  Canvas playerMoney;

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

        Debug.Log("Only once!");
        bank.playerBalanceTextComponent = bank.playerMoney.GetComponentInChildren<Text>();
        bank.playerBalanceTextComponent.text = bank.playerBank.ToString("C0");
    }

    /// <summary>
    /// Displays the starting balance of the bank
    /// </summary>
    public void Start()
    {
       
    }

    /// <summary>
    /// Purchase a canon from the bank
    /// </summary>
    public void buyCanonTurret()
    {
       bank.playerBalanceTextComponent.text = (bank.playerBank - 140).ToString("C0");
        bank.playerBank = bank.playerBank - 140;
        Debug.Log("Buy that canon");
    }

    public void buyArrowTurret()
    {
        bank.playerBalanceTextComponent.text = (bank.playerBank - 120).ToString("C0");
        bank.playerBank = bank.playerBank - 120;
    }

    public void buyMagicTurret()
    {
        bank.playerBalanceTextComponent.text = (bank.playerBank - 175).ToString("C0");
        bank.playerBank = bank.playerBank - 175;
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
