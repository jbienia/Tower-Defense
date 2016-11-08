using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class used for the shop. 
/// Money is subtracted by the purchase of turrets
/// </summary>
public class Shop : MonoBehaviour {

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
    public  Canvas playerMoney;

    // Static object used to represent our one shop
    public static Shop shop;
    
    /// <summary>
    /// Creates a static instance of the shop
    /// Instanciates the Bank
    /// </summary>
    public void Awake()
    {

        if(shop != null)
        {
            return;
        }

      
        shop = this;

        shop.playerMoney = Instantiate(currencyDisplay);

    }

    public void Start()
    {
        shop.playerMoney.GetComponentInChildren<Text>().text = playerBank.ToString();
        
    }

  public void buyCanon()
    {
       
       
        shop.playerMoney.GetComponentInChildren<Text>().text = (playerBank - 100).ToString();
    }
  

    /*
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
       buildManager.SelectTurretToBuild(standardTurret);
        
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missleLauncher);
    }

    public void SelectHorseTurret()
    {
        buildManager.SelectTurretToBuild(horseTurret);
    }

    */
    
    
}
