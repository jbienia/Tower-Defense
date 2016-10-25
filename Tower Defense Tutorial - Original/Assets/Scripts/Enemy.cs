using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float speed = 10f;

    public Transform wayPoint;
    public int wavepointIndex = 0;
    public Vector3 dir;
    public Slider healthSlider;
    public Canvas healthSliderCanvas;
    public int currentHealth;
    public int starterHealth;
    public Transform enemy;
    private Quaternion lookDirection;
    

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

       // healthSliderCanvas.transform.parent.SetParent(null, false);
        //healthSliderCanvas.transform.SetParent();
    }

   public virtual void Update()
    {
        
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
        

        //healthSliderCanvas.transform.position = DisplayHealthBarAboveEnemy();

    }

    // Advances the to the next way point
   public virtual void GetNextWayPoint()
    {
        // Once the enemy has no more waypoints to go to, destroy the enemy and its health bar
        if(wavepointIndex >= Waypoints.points.Length -1)
        {
            DestroyObject(gameObject);
            Destroy(healthSliderCanvas.gameObject);
            Destroy(healthSlider.gameObject);
            EnemiesInGame.allEnemiesInGame.Remove(gameObject);
            return;
        }

        wavepointIndex++;
        wayPoint = Waypoints.points[wavepointIndex];
    }

    /// <summary>
    /// Rotates the charater to the next way point
    /// </summary>
    public void RotateCharacter()
    {
        
        dir = wayPoint.position - transform.position;

        lookDirection = Quaternion.LookRotation(dir);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, 20f * Time.deltaTime * speed);

                  
    }

    // turrets can be "canon","melee","Regular"
    public void HealthMeter (string turret)
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
     }

    /// <summary>
    /// Displays the health bar above the enemy
    /// Is used to place the health bar the with the same transform as the enemy but with a higher Y axis
    /// </summary>
    /// <returns></returns>
    public Vector3 DisplayHealthBarAboveEnemy()
    {
        Vector3 healthBarTransform;
        healthBarTransform.x = enemy.transform.position.x;
        healthBarTransform.y = 4.88f;
        healthBarTransform.z = enemy.transform.position.z;

        return healthBarTransform;


    }

}
