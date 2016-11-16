using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Spawns new set of waves every 
/// </summary>
public class WaveSpawner : MonoBehaviour {

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
   
    // A list of GameObject type
    public List<GameObject> basicSpawnEnemies = new List<GameObject>();

    /// <summary>
    /// Gets a referenece to the singleton enemy manager
    /// </summary>
    void Start()
    {
        enemyManager = EnemyManager.enemyManagerInstance;
    }

    /// <etactiveummary>
    /// Spawns a new wave and decreases the countdown timer
    /// </summary>
    void Update()
    {
        // Checks the countDown timer
        if ( countDown <= 0)
        {
            // Resets the Countdown Timer
            countDown = timeBetweenWaves;

            // Co Routine that spawns the enemies
            StartCoroutine (SpawnWave () );
        }

        // Countdown starts once a wave of enemies has finished spawning
        if(startCountdown)
        {
            countDown -= Time.deltaTime;
            countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        }
    }

    /// <summary>
    /// A Coroutine that Spawns a wave of enemies
    /// </summary>
    IEnumerator SpawnWave()
    {
        // Sets the a bool to false to stop the countdown timer
        startCountdown = false;

        // Checks the level
        if(level == 1)
        {
            // Checks which wave should spawn
            if (waveCounter == 1)
            {
                // loops through a list of enemy game objects
                for (int i = 0; i <= enemyManager.firstBasicWaveToSpawn.Count-1; i++)
                {
                    // Sets the already instanciated game object SetActive property to True 
                    SpawnEnemy(enemyManager.firstBasicWaveToSpawn,i);

                    // Waits a few seconds before the next one
                    yield return new WaitForSeconds(1.5f);
                 }
                
                // Set the boolean to start the countdown
                startCountdown = true;
            }

            // Checks which wave should spawn
            if (waveCounter == 2)
            {
                // Sets the a bool to false to stop the countdown timer
                startCountdown = false;

                // loops through a list of enemy game objects
                for (int i = 0; i <= enemyManager.secondTankWaveToSpawn.Count-1; i++)
                {
                    // Sets the already instanciated game object SetActive property to True
                    SpawnEnemy(enemyManager.secondTankWaveToSpawn, i);

                    // Waits a few seconds before the next one
                    yield return new WaitForSeconds(2.0f);
                 }

                // Set the boolean to start the countdown
                startCountdown = true;
            }

            // Checks which wave should spawn
            if (waveCounter == 3)
            {
                // Sets a value to stop the countdown timer
                startCountdown = false;

                // loops through a list of enemy game objects
                for (int i = 0; i <= enemyManager.thirdFastWaveToSpawn.Count-1; i++)
                {
                    // Sets the already instanciated game object SetActive property to True
                    SpawnEnemy(enemyManager.thirdFastWaveToSpawn, i);

                    // Waits a few seconds before the next one
                    yield return new WaitForSeconds(0.5f);
                 }

                // Set the boolean to start the countdown
                startCountdown = true;
            }

            // Checks which wave should spawn
            if (waveCounter == 4)
            {
                // Sets the a bool to false to stop the countdown timer
                startCountdown = false;

                // loops through a list of enemy game objects
                for (int i = 0; i <= enemyManager.flyingWaveToSpawn.Count-1; i++)
                {
                    // Sets the already instanciated game object SetActive property to True
                    SpawnEnemy(enemyManager.flyingWaveToSpawn, i);

                    // Waits a few seconds before the next one
                    yield return new WaitForSeconds(0.5f);
                 }

                // Set the boolean to start the countdown
                startCountdown = true;
            }

            // Checks which wave should spawn
            if (waveCounter == 5)
            {
                // Sets the a bool to false to stop the countdown timer
                startCountdown = false;

                // loops through a list of enemy game objects
                for (int i = 0; i <= enemyManager.fifthFastWaveToSpawn.Count-1; i++)
                {
                    // Sets the already instanciated game object SetActive property to True
                    SpawnEnemy(enemyManager.fifthFastWaveToSpawn, i);

                    // Waits a few seconds before the next one
                    yield return new WaitForSeconds(0.5f);
                 }
                // Set the boolean to start the countdown
                startCountdown = true;
            }

            // Increments the the value that represents which wave we are on
            waveCounter++;
        }
    }
       
    /// <summary>
    /// Sets an enemy Game Object SetActive property to true. 
    /// Adds the Enemy Game Object to a list of all the enemy Game Objects in the scene
    /// </summary>
    /// <param name="spawn">A Game Object from a list</param>
    /// <param name="i">parameter that is which place in the array holds the object we want to spawn</param>
    void SpawnEnemy(List<GameObject> spawn ,int i)
    {
        // Sets the Game object to true
        spawn[i].SetActive(true);

        // Adds all enemies
        EnemiesInGame.allEnemiesInGame.Add(spawn[i]);
    }
}
