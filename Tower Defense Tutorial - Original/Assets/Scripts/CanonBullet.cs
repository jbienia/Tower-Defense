using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class used to represent the Canon Ball in the game
/// </summary>
public class CanonBullet : MonoBehaviour
{
    // The target the canon ball is heading towards
    private Transform target;

    // Variable used to regulate speed
    public float speed = 70f;

    // Little effect of the exploded canon ball
    public GameObject impactEffect;

    // Explosion Radius set in the Inspector
    public float explosionRadius = 0f;

    // Health Slider. Value set in the inspector
    public Slider healthBar;

    // Reference to the canon ball game object
    public GameObject canonBall;

    // Reference to the canonball rigid body
    Rigidbody canonballRigid;

    // A Vector3 of the target transform
    private Vector3 stableTarget;

    public int canonDamage;

    /// <summary>
    /// Gets a reference to the Rigid Body of the Canon Ball
    /// Gets a reference to the target
    /// </summary>
    void Start()
    {
        canonballRigid = GetComponent<Rigidbody>();
        stableTarget = target.transform.position;

        // Sets the Velocity of all canonballs shots at the start. 
        // Might be better to have this in a fixed update at some point
        if (stableTarget != null)
        {
            canonballRigid.AddForce(BallisticVel(stableTarget), ForceMode.VelocityChange);
        }
     }

    // stores a reference to the target
    public void Seek(Transform _target, int _damage)
    {
        target = _target;
        canonDamage = _damage;
    }

    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        
        // The speed of the bullet relative to time
        float distanceThisFrame = speed * Time.deltaTime;
     }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerEnter(Collider collision)
    {
        // Checks if the canon ball collider has collided with the terrin so that it can be destroyed if it has
        if (collision.gameObject.tag == "Terrain")
        {
            HitTarget();
            Destroy(gameObject);
        }
     }

    /// <summary>
    ///  Returns the velocity needed to hit the target
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    Vector3 BallisticVel(Vector3 target)
    {
        //Debug.Log("Velocity!");
        var dir = target - transform.position; // get target direction

        var h = dir.y;  // get height difference
        
       // dir.y = 0;  // retain only the horizontal direction
        var dist = dir.magnitude;  // get horizontal distance
       
        dir.y = dist * 1.5f;  // set elevation to 45 degrees
        dist += h;  // correct for different heights
        
        float vel = Mathf.Sqrt(dist * Physics.gravity.magnitude * 1.5f);
        //vel -= 2f;
        
        return vel * dir.normalized;  // returns Vector3 velocity
     }
    
    /// <summary>
    /// Damages the enemy and destroys the canon ball game object
    /// </summary>
    void HitTarget()
    {
        // Displays an impact effect
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);

        // Destroys the impact effect after 5 seconds
        Destroy(effectIns, .9f);

        if (explosionRadius > 0f)
        {
            Explode();
        }

        Destroy(gameObject);
    }
    
    /// <summary>
    /// Gets all the colliders in a specific radius
    /// Checks colliders for the enemy tag
    /// Runs the Damage method and passes the transform of the damaged object
    /// </summary>
    void Explode()
    {
        // Gets an array of colliders in a certain radius around the transform
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        // Loops through the colliders and checks the tags
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy" || collider.tag == "FlyingEnemy" || collider.tag == "Tank" || collider.tag == "FastEnemy")
            {
                Damage(collider.transform,collider.tag);
            }
         }
    }

    /// <summary>
    /// Method used to return a reference to the correct script in order to take damage from the enemy
    /// </summary>
    /// <param name="enemy"></param>
    /// <param name="tag"></param>
    void Damage(Transform enemy,string tag)
    {
        GetCorrectScript(enemy,tag);
    }

    /// <summary>
    /// Method decreases health from the correct enemy script/object
    /// </summary>
    /// <param name="enemy"></param>
    /// <param name="enemyTag"></param>
    void GetCorrectScript(Transform enemy,string enemyTag)
    {
        string canon = "canon";
        Enemy enemyScript;

        // Uses the enemy tag to reference the correct enemy script component
        switch (enemyTag)
        {
            case "Enemy":
                 enemyScript = enemy.gameObject.GetComponent<Enemy>();
                enemyScript.DecreaseHealthMeter(canon,canonDamage);
                break;

            case "FlyingEnemy":
                enemyScript = enemy.gameObject.GetComponent<FlyingEnemy>();
                enemyScript.DecreaseHealthMeter(canon,canonDamage);
                break;

            case "Tank":
                enemyScript = enemy.gameObject.GetComponent<TankEnemy>();
                enemyScript.DecreaseHealthMeter(canon,canonDamage);
                break;

            case "FastEnemy":
                enemyScript = enemy.gameObject.GetComponent<Enemy>();
                enemyScript.DecreaseHealthMeter(canon, canonDamage);
                break;
        }
     }
        
    /// <summary>
    /// Draws a circle around the canon ball displaying the explosion radius
    /// </summary>
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }




}

