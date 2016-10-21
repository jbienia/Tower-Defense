using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This class manages the turrets
/// It is a static singleton class
/// It collects an array of all the game objects and provides them to the turrets
/// </summary>
public class EnemyManager : MonoBehaviour {

    //private float fireCountdown = 0f;
    //public float range = 15f;
    //public float hp = 35f;
    public string enemyTag = "Enemy";
    public string tankEnemyTag = "Tank";
    public string flyingEnemyTag = "FlyingEnemy";

    public GameObject enemy;
    public GameObject flyingEnemy;
    public GameObject tank;
    public GameObject fastEnemy;
    public Transform spawnPoint;

    public GameObject[] enemies;

    //Level one Lists of Waves
    public  List<GameObject> firstBasicWaveToSpawn = new List<GameObject>();
    public List<GameObject> secondTankWaveToSpawn = new List<GameObject>();
    public List<GameObject> thirdFastWaveToSpawn = new List<GameObject>();
    public List<GameObject> fourthBasicWaveToSpawn = new List<GameObject>();
    public List<GameObject> fifthFastWaveToSpawn = new List<GameObject>();
    public List<GameObject> flyingWaveToSpawn = new List<GameObject>();

    private int level = 1;

    // Waiting to see if I can adjust the enemy volume in the inspector
    [Header("LevelOne")]
    public int basic;
    public int fast;
    public int tanks;
    public int flying;
    /// <summary>
    /// A static singleton object
    /// Only one object of this class can exist in the game
    /// </summary>
    public static EnemyManager enemyManagerInstance;
    //Dictionary<float,>
    

    public enum LevelOne
    {
        Basic = 15,
        Fast = 8,
        Tank = 4,
        Flying = 6,
        secondBasicWave = 10,
        secondFlyingWave = 7
    }

    /// <summary>
    /// Singleton instance of the turret manager
    /// </summary>
    void Awake()
    {
        // Prevents me from building two turrets on the same spot
        if (enemyManagerInstance != null)
        {
            Debug.LogError("Too many instances");
            return;
        }
        enemyManagerInstance = this;
    }


    // Use this for initialization
    IEnumerator Start() {
        // Invokes a method name every couple seconds
        // InvokeRepeating("UpdateTarget", 0f, 0.5f);


        //CreateEnemy();

        // Level one lists of the enemy waves
        if(level == 1 )
        {
            int i = 0;
            int basic = (int)LevelOne.Basic;
            int tank = (int)LevelOne.Tank;
            int fast = (int)LevelOne.Fast;
            int flying = (int)LevelOne.Flying;
            int secondBasicWave = (int)LevelOne.secondBasicWave;
            int secondFastWave = (int)LevelOne.secondFlyingWave;


            while (i< basic)
            {
                firstBasicWaveToSpawn.Add((GameObject)Instantiate(CreateEnemy().enemy, spawnPoint.position, spawnPoint.rotation));
                //Debug.Log(enemyToSpawn[i]);
                i++;
            }

            int j = 0;
            while(j < tank)
            {
                secondTankWaveToSpawn.Add((GameObject)Instantiate(CreateTank().enemy, spawnPoint.position, spawnPoint.rotation));
                j++;
            }

            int l = 0;

            while(l < flying)
            {
                flyingWaveToSpawn.Add((GameObject)Instantiate(CreateFlyingEnemy().enemy, spawnPoint.position, spawnPoint.rotation));
                l++;
            }

            int z = 0;
            while(z < fast)
            {
                thirdFastWaveToSpawn.Add((GameObject)Instantiate(CreateFastEnemy().enemy, spawnPoint.position, spawnPoint.rotation));
                z++;
            }

            int b = 0;
            while (b < secondBasicWave)
            {
                fourthBasicWaveToSpawn.Add((GameObject)Instantiate(CreateEnemy().enemy, spawnPoint.position, spawnPoint.rotation));
                b++;
            }

            int c = 0;
            while (c < secondFastWave)
            {
                fifthFastWaveToSpawn.Add((GameObject)Instantiate(CreateFastEnemy().enemy, spawnPoint.position, spawnPoint.rotation));
                c++;
            }

        }
         

        yield return null;
    }

   public EnemyWrapper CreateEnemy()
    {
        EnemyWrapper wrapper = new EnemyWrapper();
        wrapper.type = EnemyWrapper.EnemyType.Basic;
        wrapper.enemy = enemy;
        wrapper.SetActive(false);
        return wrapper;
    }
       
    
    
   public EnemyWrapper  CreateFlyingEnemy()
    {
        EnemyWrapper wrapper = new EnemyWrapper();
        wrapper.type = EnemyWrapper.EnemyType.Flying;
        wrapper.enemy = flyingEnemy;
        wrapper.SetActive(false);
        return wrapper;
    }
      
    public EnemyWrapper CreateTank()
    {
        EnemyWrapper wrapper = new EnemyWrapper();
        wrapper.type = EnemyWrapper.EnemyType.Tank;
        wrapper.enemy = tank;
        wrapper.SetActive(false);
        return wrapper;
    }
       
    public EnemyWrapper CreateFastEnemy()
    {
        EnemyWrapper wrapper = new EnemyWrapper();
        wrapper.type = EnemyWrapper.EnemyType.Fast;
        wrapper.enemy = fastEnemy;
        wrapper.SetActive(false);
        return wrapper;
    }



    public void UpdateTarget()
    {
        // An array of all the enemies
        // enemies = GameObject.FindGameObjectsWithTag(enemyTag);

    }

   
    // This will be a list of EnemyWrapper type. These will be the objects to display in the scene
    //public EnemyWrapper[] enemyList;

    // Update is called once per frame
    void Update () {
	
	}
      
}
