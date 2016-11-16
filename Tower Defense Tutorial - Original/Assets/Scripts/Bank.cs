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
    public int canonPrice = 100;
    public int playerBank = 500;
    public Text playerBalance;
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

    }

    /// <summary>
    /// Displays the starting balance of the bank
    /// </summary>
    public void Start()
    {
       bank.playerMoney.GetComponentInChildren<Text>().text = playerBank.ToString("C0");
    }

    /// <summary>
    /// Purchase a canon from the bank
    /// </summary>
    public void buyCanonTurret()
    {
       bank.playerMoney.GetComponentInChildren<Text>().text = (playerBank - 100).ToString("C0");
    }

    public void buyArrowTurret()
    {
        bank.playerMoney.GetComponentInChildren<Text>().text = (playerBank - 120).ToString("C0");
    }

    public void buyMagicTurret()
    {
        bank.playerMoney.GetComponentInChildren<Text>().text = (playerBank - 175).ToString("C0");
    }

    public void buyArtilleryTurret()
    {
        bank.playerMoney.GetComponentInChildren<Text>().text = (playerBank - 200).ToString("C0");
    }

    public void buyMortarTurret()
    {
        bank.playerMoney.GetComponentInChildren<Text>().text = (playerBank - 250).ToString("C0");
    }

    public void buyElectricityTurret()
    {
        bank.playerMoney.GetComponentInChildren<Text>().text = (playerBank - 275).ToString("C0");
    }

    public void buyFreezeTurret()
    {
        bank.playerMoney.GetComponentInChildren<Text>().text = (playerBank - 300).ToString("C0");
    }

    
}
