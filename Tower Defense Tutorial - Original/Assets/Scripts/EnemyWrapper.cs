using UnityEngine;
using System.Collections;

/// <summary>
/// This class doesn't really make sense. I'm not sure why I chose this design decision
/// It's mainly used in the EnemyManager class. 
/// Each instanciated EnemyWrapper has it's properties set in EnemyManager
/// The main useful thing is that I can create an object while having it SetActive set to False.
/// </summary>
public class EnemyWrapper : MonoBehaviour {

    /// <summary>
    /// Enums of the four enemy types
    /// </summary>
    public enum EnemyType
    {
        Basic,
        Flying,
        Tank,
        Fast
    }

        public GameObject enemy;
        public EnemyType type;

    // Sets the Active property of the game object
    public void SetActive(bool isActive)
    {
        enemy.SetActive(isActive);
    }

   
    
}
