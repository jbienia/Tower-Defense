using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This class manages the turrets
/// It is a static singleton class
/// It collects an array of all the game objects and provides them to the turrets
/// </summary>
public class EnemyManager : MonoBehaviour
{

    // Strings that represent the different enemies in the game. The 'Enemy' string is used for the regular and fast enemies
    public string enemyTag = "Enemy";
    public string tankEnemyTag = "Tank";
    public string flyingEnemyTag = "FlyingEnemy";

    //Game Objects that represent all the different enemies in the game
    public GameObject enemy;
    public GameObject flyingEnemy;
    public GameObject tank;
    public GameObject fastEnemy;

    // The Starting spawn point for the enemies
    public Transform spawnPoint;

    //Level one Lists of Waves
    public List<GameObject> BasicWaveToSpawn = new List<GameObject>();
    public List<GameObject> TankWaveToSpawn = new List<GameObject>();
    public List<GameObject> FastWaveToSpawn = new List<GameObject>();
    public List<GameObject> NextBasicWaveToSpawn = new List<GameObject>();
    public List<GameObject> NextFastWaveToSpawn = new List<GameObject>();
    public List<GameObject> flyingWaveToSpawn = new List<GameObject>();
    public List<GameObject> thirdFastWaveToSpawn = new List<GameObject>();

    // Value that represents the level
    private int level = 1;

    // Waiting to see if I can adjust the enemy volume in the inspector
    [Header("LevelOne")]
    public int basic;
    public int fast;
    public int tanks;
    public int secondFastWave;
    public int flying;
    public int thirdFastWave;
    public int secondBasicWave;

    /// <summary>
    /// A static singleton object
    /// Only one object of this class can exist in the game
    /// </summary>
    public static EnemyManager enemyManagerInstance;

    /// <summary>
    /// An enum that contains the amount of enemies and their type
    /// </summary>
     /*
    public enum LevelOne
    {
        Basic ,
        Fast,
        Tank,
        Flying,
        secondBasicWave,
        secondFlyingWave
    }
    */

    /// <summary>
    /// Singleton instance of the turret manager
    /// </summary>
    void Awake()
    {
        // Prevents me from building two turrets on the same spot
        if (enemyManagerInstance != null)
        {
            return;
        }

        // the singleton reference
        enemyManagerInstance = this;
    }


    // Fills the Lists of Game Objects with enemies for the specified level
    IEnumerator Start()
    {

        // Level one lists of the enemy waves
        if (level == 1)
        {
            // Gets the numerical value for the specified enum
          //  int basic = (int)LevelOne.Basic;
           // int tank = (int)LevelOne.Tank;
            //int fast = (int)LevelOne.Fast;
            //int flying = (int)LevelOne.Flying;
            //int secondBasicWave = (int)LevelOne.secondBasicWave;
            //int secondFastWave = (int)LevelOne.secondFlyingWave;

            // Creates and stores the basic enemy waves in a List. 
            int i = 0;
            while (i < basic)
            {
                BasicWaveToSpawn.Add((GameObject)Instantiate(CreateEnemy().enemy, spawnPoint.position, spawnPoint.rotation));
                i++;
            }

            // Creates and stores the Tank enemy waves in a List. 
            int j = 0;
            while (j < tanks)
            {
                TankWaveToSpawn.Add((GameObject)Instantiate(CreateTank().enemy, spawnPoint.position, spawnPoint.rotation));
                j++;
            }

            // Creates and stores the flying enemy waves in a List. 
            int l = 0;
            while (l < flying)
            {
                flyingWaveToSpawn.Add((GameObject)Instantiate(CreateFlyingEnemy().enemy, spawnPoint.position, spawnPoint.rotation));
                l++;
            }

            // Creates and stores the fast enemy waves in a List. 
            int z = 0;
            while (z < fast)
            {
                FastWaveToSpawn.Add((GameObject)Instantiate(CreateFastEnemy().enemy, spawnPoint.position, spawnPoint.rotation));
                z++;
            }

            // Creates and stores the basic enemy waves in a List. 
            int b = 0;
            while (b < secondBasicWave)
            {
                NextBasicWaveToSpawn.Add((GameObject)Instantiate(CreateEnemy().enemy, spawnPoint.position, spawnPoint.rotation));
                b++;
            }

            // Creates and stores the fast enemy waves in a List. 
            int c = 0;
            while (c < secondFastWave)
            {
                NextFastWaveToSpawn.Add((GameObject)Instantiate(CreateFastEnemy().enemy, spawnPoint.position, spawnPoint.rotation));
                c++;
            }

            int p = 0;
            while(p < thirdFastWave)
            {
                thirdFastWaveToSpawn.Add((GameObject)Instantiate(CreateFastEnemy().enemy, spawnPoint.position, spawnPoint.rotation));
            }
        }

        yield return null;
    }

    /*
     * All of the objects below are created with SetActive set to false
     * This enables the objects to all be created at the start of the game, but not displayed to the user.
     */

    /// <summary>
    /// Method used to return an object of EnemyWrapper type
    /// The enemy wrapper is an object that lets us set the type, gameobject, and whether it is active or not
    /// </summary>
    /// <returns>An object which gives us access to the specified enemy</returns>
    public EnemyWrapper CreateEnemy()
    {
        EnemyWrapper wrapper = new EnemyWrapper();
        wrapper.type = EnemyWrapper.EnemyType.Basic;
        wrapper.enemy = enemy;
        wrapper.SetActive(false);
        return wrapper;
    }

    /// <summary>
    /// Method used to return an object of EnemyWrapper type
    /// The enemy wrapper is an object that lets us set the type, gameobject, and whether it is active or not
    /// </summary>
    /// <returns>An object which gives us access to the specified enemy</returns>
    public EnemyWrapper CreateFlyingEnemy()
    {
        EnemyWrapper wrapper = new EnemyWrapper();
        wrapper.type = EnemyWrapper.EnemyType.Flying;
        wrapper.enemy = flyingEnemy;
        wrapper.SetActive(false);
        return wrapper;
    }

    /// <summary>
    /// Method used to return an object of EnemyWrapper type
    /// The enemy wrapper is an object that lets us set the type, gameobject, and whether it is active or not
    /// </summary>
    /// <returns>An object which gives us access to the specified enemy</returns>
    public EnemyWrapper CreateTank()
    {
        EnemyWrapper wrapper = new EnemyWrapper();
        wrapper.type = EnemyWrapper.EnemyType.Tank;
        wrapper.enemy = tank;
        wrapper.SetActive(false);
        return wrapper;
    }

    /// <summary>
    /// Method used to return an object of EnemyWrapper type
    /// The enemy wrapper is an object that lets us set the type, gameobject, and whether it is active or not
    /// </summary>
    /// <returns>An object which gives us access to the specified enemy</returns> 
    public EnemyWrapper CreateFastEnemy()
    {
        EnemyWrapper wrapper = new EnemyWrapper();
        wrapper.type = EnemyWrapper.EnemyType.Fast;
        wrapper.enemy = fastEnemy;
        wrapper.SetActive(false);
        return wrapper;
    }
}
