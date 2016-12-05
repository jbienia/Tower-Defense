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
    private float countDown = 10f;

    private int waveIndex = 5;
    public static bool startCountdown = true;
    public static int enemiesOnScreen;
    // text displayed to the user for a countdown
    public Text waveCountdownText;
    private EnemyManager enemyManager;
    private int level = 1;
    public static int waveCounter = 1;

    public AudioClip basicEnemySteps;
    public AudioClip tankEnemySteps;
    public AudioClip fastEnemySteps;
    public AudioClip flyingEnemySteps;

    public Sprite basicEnemySprite;
    public Sprite fastEnemySprite;
    public Sprite tankEnemySprite;
    public Sprite flyingEnemySprite;

    private AudioManager audioManager;

    // A list of GameObject type
    public List<GameObject> basicSpawnEnemies = new List<GameObject>();

    /// <summary>
    /// Gets a referenece to the singleton enemy manager
    /// </summary>
    void Start()
    {
        enemyManager = EnemyManager.enemyManagerInstance;
        audioManager = GetComponent<AudioManager>();
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
            GameplayUI.inGameUserInterface.countdown.text = countDown.ToString();
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
                audioManager.PlayBasicEnemyFootsteps(basicEnemySteps);

                StartCoroutine(audioManager.PlayBasicEnemyFootsteps(basicEnemySteps));

                // Display the current Image for the Enemy Wave to the user
                GameplayUI.inGameUserInterface.enemyImage.sprite = fastEnemySprite;
                 
                // loops through a list of enemy game objects
                for (int i = 0; i <= enemyManager.basicWaveToSpawn.Count-1; i++)
                {
                    enemiesOnScreen++;
                    
                    // Sets the already instanciated game object SetActive property to True 
                    SpawnEnemy(enemyManager.basicWaveToSpawn,i);

                    // Waits a few seconds before the next one
                    yield return new WaitForSeconds(0.5f);
                 }
                
                
            }

            // Checks which wave should spawn
            if (waveCounter == 2)
            {
                // Sets the a bool to false to stop the countdown timer
                startCountdown = false;

                GameplayUI.inGameUserInterface.enemyImage.sprite = tankEnemySprite;

                // loops through a list of enemy game objects
                for (int i = 0; i <= enemyManager.fastWaveToSpawn.Count-1; i++)
                {
                    enemiesOnScreen++;

                    // Sets the already instanciated game object SetActive property to True
                    SpawnEnemy(enemyManager.fastWaveToSpawn, i);

                    // Waits a few seconds before the next one
                    yield return new WaitForSeconds(0.4f);
                 }

             
            }

            // Checks which wave should spawn
            if (waveCounter == 3)
            {
                // Sets a value to stop the countdown timer
                startCountdown = false;


                GameplayUI.inGameUserInterface.enemyImage.sprite = fastEnemySprite;

                // loops through a list of enemy game objects
                for (int i = 0; i <= enemyManager.tankWaveToSpawn.Count-1; i++)
                {
                    enemiesOnScreen++;
                    // Sets the already instanciated game object SetActive property to True
                    SpawnEnemy(enemyManager.tankWaveToSpawn, i);

                    // Waits a few seconds before the next one
                    yield return new WaitForSeconds(1.5f);
                 }

                // Set the boolean to start the countdown
                //startCountdown = true;
            }

            // Checks which wave should spawn
            if (waveCounter == 4)
            {
                // Sets the a bool to false to stop the countdown timer
                startCountdown = false;


                GameplayUI.inGameUserInterface.enemyImage.sprite = flyingEnemySprite;

                // loops through a list of enemy game objects
                for (int i = 0; i <= enemyManager.nextFastWaveToSpawn.Count-1; i++)
                {
                    enemiesOnScreen++;
                    // Sets the already instanciated game object SetActive property to True
                    SpawnEnemy(enemyManager.nextFastWaveToSpawn, i);

                    // Waits a few seconds before the next one
                    yield return new WaitForSeconds(0.2f);
                 }

               
            }

            // Checks which wave should spawn
            if (waveCounter == 5)
            {
                // Sets the a bool to false to stop the countdown timer
                startCountdown = false;

                GameplayUI.inGameUserInterface.enemyImage.sprite = fastEnemySprite;

                // loops through a list of enemy game objects
                for (int i = 0; i <= enemyManager.flyingWaveToSpawn.Count-1; i++)
                {
                    enemiesOnScreen++;
                    // Sets the already instanciated game object SetActive property to True
                    SpawnEnemy(enemyManager.flyingWaveToSpawn, i);

                    // Waits a few seconds before the next one
                    yield return new WaitForSeconds(0.5f);
                 }
               
            }

            // Checks which wave should spawn
            if (waveCounter == 6)
            {
                // Sets the a bool to false to stop the countdown timer
                startCountdown = false;

                GameplayUI.inGameUserInterface.enemyImage.sprite = basicEnemySprite;

                // loops through a list of enemy game objects
                for (int i = 0; i <= enemyManager.thirdFastWaveToSpawn.Count - 1; i++)
                {
                    enemiesOnScreen++;
                    // Sets the already instanciated game object SetActive property to True
                    SpawnEnemy(enemyManager.thirdFastWaveToSpawn, i);

                    // Waits a few seconds before the next one
                    yield return new WaitForSeconds(0.2f);
                }

            }

            // Checks which wave should spawn
            if (waveCounter == 7)
            {
                // Sets the a bool to false to stop the countdown timer
                startCountdown = false;

                GameplayUI.inGameUserInterface.enemyImage.sprite = basicEnemySprite;

                // loops through a list of enemy game objects
                for (int i = 0; i <= enemyManager.nextBasicWaveToSpawn.Count - 1; i++)
                {
                    enemiesOnScreen++;
                    // Sets the already instanciated game object SetActive property to True
                    SpawnEnemy(enemyManager.nextBasicWaveToSpawn, i);

                    // Waits a few seconds before the next one
                    yield return new WaitForSeconds(0.2f);
                }

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
        if(spawn[i] != null) 
        {
            // Adds all enemies
            EnemiesInGame.allEnemiesInGame.Add(spawn[i]);

            // Sets the Game object to true
            spawn[i].SetActive(true);
        }
        

        
    }
}
