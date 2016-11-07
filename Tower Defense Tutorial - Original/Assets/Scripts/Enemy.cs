using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Script used to to control various parameters of the enemies in the game
/// </summary>
public class Enemy : MonoBehaviour {

    // Speed value used along wiht Time.deltaTime
    public float speed = 10f;

    // Holds a reference to a waypoint
    public Transform wayPoint;

    // Value used while looping throught the waypoint game objects
    public int wavepointIndex = 0;

    // A vector3 represent a direction
    public Vector3 dir;

    // The enemy health slider
    public Slider healthSlider;

    // The canvas that the health slider is on top of
    public Canvas healthSliderCanvas;

    // Currrent health of the enemy
    public int currentHealth;

    // Starting health of the enemy
    public int starterHealth;

    // The Transform of the Enemy
    public Transform enemy;

    // Direction to be rotated
    private Quaternion lookDirection;


    private GameObject sliderCanvas;

    /// <summary>
    /// On start a reference to the first waypoint is stored, and the enemy is rotated towards it. 
    /// Health Bars are placed above the enemies heads and their parent is set to null
    /// Setting the parent to null insures that they are always facing the camera....This is not the best way of doing this...?????
    /// </summary>
    public void Start()
    {
        // Sets the target to the first waypoint
        wayPoint = Waypoints.points[0];

        // Method that rotates the character to the Waypoint
        RotateCharacter();

        // Sets the health slider value to a starter value
        healthSlider.value = starterHealth;

        // Sets a variable to the value desired as a starter health.
        currentHealth = starterHealth;
        
        // Removes the healthslider from being a child of the enemy gameobject        
        healthSliderCanvas.transform.parent = null;

        // Holds a reference to the Game Object
        sliderCanvas = healthSliderCanvas.gameObject;
    }

    /// <summary>
    /// Runs Every Frame
    /// </summary>
   public virtual void Update()
    {
        // Stores the direction of the waypoint from the Enemy
        dir = wayPoint.position - transform.position;
        
        // Moves the enemy toward the waypoint 
        transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);

        // Checks the distance between the enemy and the way point
        // Determines whether to advance to the next way point
        if(Vector3.Distance(transform.position, wayPoint.position) <= 0.4f)
        {
            GetNextWayPoint();
            RotateCharacter();
        }
        
        // Sets the health bar above the enemy
        sliderCanvas.transform.position = DisplayHealthBarAboveEnemy(4.88f);

        // Rotates the enemy towards the waypoint
        RotateHealthBar();
    }

    /// <summary>
    /// Stores a reference to the next waypoint the enemy should move towards
    /// </summary>
   public virtual void GetNextWayPoint()
    {
        // Once the enemy has no more waypoints to go to, destroy the enemy and its health bar
        if(wavepointIndex >= Waypoints.points.Length -1)
        {
            // Destroys the Enemy
            DestroyObject(gameObject);

            // Destroys the health slider canvas
            Destroy(sliderCanvas.gameObject);

            // Destroys the health slider game object
            Destroy(healthSlider.gameObject);

            // Removes the Enemy from the list of enemy game objects in the game
            EnemiesInGame.allEnemiesInGame.Remove(gameObject);

            return;
        }

        // Increments the wave point index
        wavepointIndex++;

        // Sets a reference to the new waypoint
        wayPoint = Waypoints.points[wavepointIndex];
    }

    /// <summary>
    /// Rotates the character to the next way point
    /// </summary>
    public void RotateCharacter()
    {
        // A Vector3 value that represents the direction from the enemy to the waypoint
        dir = wayPoint.position - transform.position;

        // Value used to set the rotation of the enemy
        lookDirection = Quaternion.LookRotation(dir);

        // Sets the rotation towards a waypoint
        transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, 90f * Time.deltaTime);
     }

    /// <summary>
    /// Decreases health from the enemy health bar
    /// </summary>
    /// <param name="turret">String value that represents the different type of turret that is doing damage</param>
    public void DecreaseHealthMeter (string turret)
    {
        if(turret == "melee")
        {
            currentHealth -= 15;
            healthSlider.value = currentHealth;
        }

        if(turret == "canon")
        {
            currentHealth -= 20;
            healthSlider.value = currentHealth;
        }

        if(turret == "arrow")
        {
            currentHealth -= 10;
            healthSlider.value = currentHealth;
        }

        if(turret == "magic")
        {
            currentHealth -= 12;
            healthSlider.value = currentHealth;
        }
     }

    /// <summary>
    /// Displays the health bar above the enemy
    /// Is used to place the health bar the with the same transform as the enemy but with a higher Y axis
    /// </summary>
    /// <returns></returns>
    public Vector3 DisplayHealthBarAboveEnemy(float enemyHeight)
    {
        Vector3 healthBarTransform;
        healthBarTransform.x = enemy.transform.position.x;
        healthBarTransform.y =enemy.transform.position.y + enemyHeight;
        healthBarTransform.z = enemy.transform.position.z;

        return healthBarTransform;
     }

    /// <summary>
    /// Used to make sure that the health bar is rotated towards the camera
    /// </summary>
    public void RotateHealthBar()
    {
        // reference to the main camera
        Camera camera = Camera.main;

        // Direction from the health bar slider to the main camera
        Vector3 dir = camera.transform.position - healthSliderCanvas.transform.position;

        // Holds the rotation that the slider needs in order to set its rotation towards the camera
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        // Stores the rotation as euler angles in a Vector3 refernce
        Vector3 rotation = Quaternion.Lerp(healthSliderCanvas.transform.rotation,lookRotation,Time.deltaTime).eulerAngles;

        // Sets the rotation of the health slider canvas using the Euler method 
        healthSliderCanvas.transform.rotation = Quaternion.Euler(rotation);
    }
}
