using UnityEngine;
using System.Collections;

/// <summary>
/// Handles the players currency. Currently not implemented
/// </summary>
public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int startMoney = 400;

    void Start()
    {
        Money = startMoney;
    }
}
