using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class represents a Bullet
/// </summary>
public class Bullet : MonoBehaviour
{
    // A reference to the target that the bullet will hit
    public Transform target;

    // Variable used control the speed along with Time.DeltaTime
    public float speed = 70f;

    // Effect used to once the bullet has hit
    public GameObject impactEffect;

    // Explosion radius set in the inspector
    public float explosionRadius = 0f;

    // Slider used to set the Health bar. Set in the inspector
    public Slider healthBar;

    // Used to set the inital health value
    public int startingHealth = 100;

    // Holds the current value of health. i.e. after it decreases
    public int currentHealth;

    // Quaternion used to tell a transform where to rotate to
    public Quaternion lookRotation;

    /// <summary>
    /// Sets the starting health
    /// </summary>
    public virtual void Awake()
    {
        currentHealth = startingHealth;
    }

    /// <summary>
    /// Holds a reference to the target the bullet will hit
    /// </summary>
    /// <param name="_target"></param>
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    public virtual void  Update()
    {
        if (target == null)
        {
            return;
        }

        // direction to move the bullet from itself to the enemy
        Vector3 dir = target.position + Vector3.up * 2 - transform.position;

        // The speed of the bullet relative to time
        float distanceThisFrame = speed * Time.deltaTime;
       
        // Checks if the bullet is close enough to cause a hit    
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            GameObject bulletImpact =  (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(bulletImpact, 2f);
            return;
        }

        // Moves the bullet in the correct direction
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    /// <summary>
    /// Used to cause damage to an enemy when hit
    /// </summary>
   public virtual void HitTarget()
    {
        // I'm not sure if this code does anything ???????????
        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
         
        // Destroys the Bullet Object      
        Destroy(gameObject);
    }


    /// <summary>
    /// Gets all the colliders in a specific radius
    /// Checks colliders for the enemy tag
    /// Runs the Damage method and passes the transform of the damaged object
    /// </summary>
   public void Explode()
    {
        // Gets an array of colliders in a certain radius around the transform
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        // Loops through the colliders and checks the tags
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
         }
    }

    /// <summary>
    /// Method used to Damage an enemy. Uses the tag from the enemy to tell which enemy type was hit
    /// </summary>
    /// <param name="enemy"></param>
    public virtual void Damage(Transform enemy)
    {
        Enemy enemyScript;
        switch (enemy.tag)
        {
            case "Enemy":
                 enemyScript = enemy.gameObject.GetComponent<Enemy>();
                enemyScript.DecreaseHealthMeter("arrow");
                break;

            case "FlyingEnemy":
                enemyScript = target.gameObject.GetComponent<FlyingEnemy>();
                enemyScript.DecreaseHealthMeter("arrow");
                break;

            case "Tank":
                enemyScript = target.gameObject.GetComponent<TankEnemy>();
                Debug.Log("HIT THE BIG GUY!");
                enemyScript.DecreaseHealthMeter("arrow");
                break;
        }
    }

    /// <summary>
    /// Draws a circle around the Game object. This lets us visualize the explosionRadius.
    /// </summary>
   public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
