using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A class that contains one static method which holds a list of all the Enemies in the Game.
/// </summary>
public class EnemiesInGame : MonoBehaviour
{
    // A static reference to all the enemies in the game
    public static List<GameObject> allEnemiesInGame = new List<GameObject>();
}
