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
    private float countDown = 10;
    private int countdownChecker;

    // Variable used to check against the timer
    // Used to make 3...2...1 happen with a beep
    private int countdownHelper = 4;

    private int waveIndex = 5;
    public static bool startCountdown = true;
    public static int enemiesOnScreen;
    // text displayed to the user for a countdown
    public Text waveCountdownText;
    private EnemyManager enemyManager;
    private int level = 1;
    public static int waveCounter = 1;


    private bool noBeep = true;

    public AudioClip basicEnemySteps;
    public AudioClip tankEnemySteps;
    public AudioClip fastEnemySteps;
    public AudioClip flyingEnemySteps;
    public AudioClip countdownBleeps;
    public AudioClip releaseBleep;

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
        // A singleton that has access to each wave as a list of Game Objects
        enemyManager = EnemyManager.enemyManagerInstance;

        // Component used for Audio
        audioManager = GetComponent<AudioManager>();
       
        // This is used especially for when the player resets the level. 
        // If this is not set to true then the countdown will not start
        startCountdown = true;

        // Used mainly becuase of the reset button
        // Reset button causes many static varibables to have to be reset manually
        Time.timeScale = 1;

        // Resets the Wave Counter after a reset
        waveCounter = 1;

        // Resets the enemies on Screen value to zero.
        // Used primarily so the countdown timer will start when the game is reset with the reset button
        WaveSpawner.enemiesOnScreen = 0;
        
        // Code used to mute the volume
        AudioListener.volume = 0;
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
            // Subtracts time from the countdown variable
            countDown -= Time.deltaTime;

            // Stores a reference to the current time on the countdown timer
            countdownChecker = int.Parse(countDown.ToString("N0"));
           

            if(noBeep)
            {
                // Checks if the current countdown is less than 4(countdownHelper)
                if (countdownChecker < countdownHelper)
                {
                    // Plays the countdown blips
                    audioManager.PlayCountdownBlips(countdownBleeps);

                    // Subtracts the countdown helper
                    countdownHelper--;

                    // if the countdown timer is 1 set a boolean to false
                    if (countdownHelper == 1)
                    {
                        noBeep = false;
                    }
                }
            }
            
            // Displays the countdown to the UI as long as countdown in greater than 1
            if(countDown > 1)
            {
                GameplayUI.inGameUserInterface.countdown.text = countDown.ToString("N0");
            }

            // Starts a countdown animation 
            if(countDown < 4 && !(countDown <= 0))
            {
                GameplayUI.inGameUserInterface.countBouncer.enabled = true;
            }
            
            // Checks if the countdown timer is 0
            if(countdownChecker == 0)
            {
                // Displays Text to the UI
                GameplayUI.inGameUserInterface.countdown.text = "Defend Yourself!";

                // Stops the bounce of the timer
                GameplayUI.inGameUserInterface.countBouncer.enabled = false;
                
                // Plays the final beep before a wave is released
                audioManager.PlayFinalBleepOfCountdown(releaseBleep);

                // Resets the helper variables
                countdownHelper = 4;
                countDown = 0;
                noBeep = true;
                startCountdown = false;
            }
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
                // Plays sounds for enemy footsteps. Will probably change
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
                
                // Sets the Sprite to displayed on the user interface
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

                // Sets the fast enemy sprite to the user interface
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
            }

            // Checks which wave should spawn
            if (waveCounter == 4)
            {
                // Sets the a bool to false to stop the countdown timer
                startCountdown = false;

                // Sets the flying sprite image to the user interface
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

                // Set the Fast Enemy Sprite to the user interface
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

                // Set the Basic Enemy Sprite to the user interface
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

                // Set the Fast Enemy Sprite to the user interface
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
