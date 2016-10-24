using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Spawns new set of waves every 
/// </summary>
public class WaveSpawner : MonoBehaviour {

    public Transform enemyGreenPrefab;

    public Transform enemyRedPrefab;

    public Transform spawnPoint;

    public Transform flyingEnemy;

    public Transform fastEnemy;

    public Transform tankEnemy;

    // the time between waves
    public float timeBetweenWaves = 5.5f;

    // The value used to count down till the next wave
    private float countDown = 2f;

    private int waveIndex = 5;
    private bool startCountdown = true;

    // text displayed to the user for a countdown
    public Text waveCountdownText;
    private EnemyManager enemyManager;
    private int level = 1;
    private int waveCounter = 1;
    private int helperVariable = 0;

    public List<GameObject> basicSpawnEnemies = new List<GameObject>();

    
      
    void Start()
    {
        enemyManager = EnemyManager.enemyManagerInstance;
        //basicSpawnEnemies = enemyManager.enemyToSpawn;
    }

    /// <etactiveummary>
    /// Spawns a new wave and decreases the countdown timer
    /// </summary>
    void Update()
    {
        
        if ( countDown <= 0)
        {
            countDown = timeBetweenWaves;
            StartCoroutine (SpawnWave () );

                     
        }

        if(startCountdown)
        {
            countDown -= Time.deltaTime;

            countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
           
           // waveCountdownText.text = string.Format("{0:00}", countDown);
        }
        
    }

    /// <summary>
    /// A Coroutine that Spawns a wave of enemies
    /// </summary>
    IEnumerator SpawnWave()
    {
        
        startCountdown = false;

        if(level == 1)
        {
            
            if (waveCounter == 1)
            {
                
                for (int i = 0; i <= enemyManager.firstBasicWaveToSpawn.Count-1; i++)
                {
                    
                    SpawnEnemy(enemyManager.firstBasicWaveToSpawn,i);
                    
                    yield return new WaitForSeconds(0.5f);
                   
                }
                
                
                startCountdown = true;
            }

            if(waveCounter == 2)
            {
                startCountdown = false;
                
                for (int i = 0; i <= enemyManager.secondTankWaveToSpawn.Count-1; i++)
                {

                    SpawnEnemy(enemyManager.secondTankWaveToSpawn, i);

                    yield return new WaitForSeconds(2.0f);
                    
                }
                

                startCountdown = true;
            }

            if(waveCounter == 3)
            {
                startCountdown = false;
                for (int i = 0; i <= enemyManager.thirdFastWaveToSpawn.Count-1; i++)
                {

                    SpawnEnemy(enemyManager.thirdFastWaveToSpawn, i);

                    yield return new WaitForSeconds(0.5f);
                    
                }
                

                startCountdown = true;
            }

            if(waveCounter == 4)
            {
                startCountdown = false;
                for (int i = 0; i <= enemyManager.flyingWaveToSpawn.Count-1; i++)
                {

                    SpawnEnemy(enemyManager.flyingWaveToSpawn, i);

                    yield return new WaitForSeconds(0.5f);
                    
                }
                

                startCountdown = true;
            }

            if(waveCounter == 5)
            {
                startCountdown = false;
                for (int i = 0; i <= enemyManager.fifthFastWaveToSpawn.Count-1; i++)
                {

                    SpawnEnemy(enemyManager.fifthFastWaveToSpawn, i);

                    yield return new WaitForSeconds(0.5f);
                   
                }
               

                startCountdown = true;
            }

            waveCounter++;
        }
    }
       
       
    /// <summary>
    /// Sets an enemy Game Object SetActive property to true. 
    /// Adds the Enemy Game Object to a list of all the enemy Game Objects in the scene
    /// </summary>
    /// <param name="spawn"></param>
    /// <param name="i"></param>
    void SpawnEnemy(List<GameObject> spawn ,int i)
    {
       
        {
            spawn[i].SetActive(true);

            // Adds all enemies
            EnemiesInGame.allEnemiesInGame.Add(spawn[i]);
            
            //Debug.Log(basicSpawnEnemies[i]);


        }

       
    }
}
