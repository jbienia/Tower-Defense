using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Class used for the Hammer Turret
/// </summary>
public class HammerDown : MonoBehaviour
{
    
    private Transform target;

    [Header("Attributes")]
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public float range = 15f;
    public string enemyTag = "Enemy";
    public string tankEnemyTag = "Tank";
    public string flyingEnemyTag = "FlyingEnemy";

    public float attackValue = 0f;
    public AnimationCurve attackCurve;
    public ParticleSystem dust;

    [Header("Unity Setup Fields")]

    public Transform partToRotate;
    public float turnSpeed = 10f;

    [Header("Damage Values")]
    public int damageToBasic;
    public int damageToTank;
    public int damageToFlying;
    public int damageToFast;


    public List<GameObject> enemyList = new List<GameObject>();
    EnemyManager instance;
    public GameObject hammerPoint;

    // Used in the update so that the large collider on the hammer doesn't collide too many times. The collider can only hit the enemy
    // once it has returned to it's 0 x rotation
    private bool preventMultipleCollisions = true;



    // Use this for initialization
    void Start()
    {
        instance = EnemyManager.enemyManagerInstance;
        // Invokes a method name every couple seconds
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    /// <summary>
    /// Checks for the targets in range, 
    /// </summary>
    void UpdateTarget()
    {
        enemyList = EnemiesInGame.allEnemiesInGame;


        // Here we use infinity so that it is true;
        float shortestDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;

        // Finds the distance betweent the turret and the enemy 
        foreach (GameObject enemy in enemyList)
        {
            // Gets the distance from our turret to the enemy
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            // Tests for the enemy that is closest to the turret
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        // Sets the target transform if the target is in range
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // IF there is no target, because one is not in range, the rest of the code does not run.
        if (target == null)
        {
            return;
        }

        // The direction from the turret to the enemy
        Vector3 dir = target.position - transform.position;

        // Sets the rotation with the specified dir
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        // Sets the rotation to a Vector 3 user the eulerAngles method.
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;

        attackValue = Mathf.MoveTowards(attackValue, 0f, Time.deltaTime * 2f);

        // Rotates our x value. Swings the hammer down
        partToRotate.rotation = Quaternion.Euler(attackCurve.Evaluate(attackValue) * 90f, rotation.y, 0f);

        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

        if(transform.rotation.eulerAngles.x < 1)
        {
            preventMultipleCollisions = true;
        }
   }

    /// <summary>
    /// Trigger used to damage the enemy
    /// </summary>
    /// <param name="collider"></param>
    void OnTriggerEnter(Collider collider)
    {
       // Co routine creates some dust particles from the hammer hitting the ground
        StartCoroutine(Dust(collider));
        
        // Makes sure that the hammer only hits an enemy once once the way down
        if(preventMultipleCollisions == true)
        {
            preventMultipleCollisions = false;
            
            DamageEnemy(collider);
        }
     }

    /// <summary>
    /// Removes damage from the enemy health
    /// </summary>
    /// <param name="collider"></param>
    void DamageEnemy(Collider collider)
    {
        string enemyTag = collider.tag;
        Enemy enemyScript;

        switch (enemyTag)
        {
            case "Enemy":
                enemyScript = collider.GetComponent < Enemy>();
                enemyScript.DecreaseHealthMeter("melee",damageToBasic);
                break;

            case "FlyingEnemy":
                 enemyScript = collider.GetComponent<FlyingEnemy>();
                enemyScript.DecreaseHealthMeter("melee",damageToFlying);
                break;

            case "Tank":
                 enemyScript = collider.GetComponent<TankEnemy>();
                enemyScript.DecreaseHealthMeter("melee",damageToTank);
                break;

            case "FastEnemy":
                enemyScript = target.gameObject.GetComponent<Enemy>();
                enemyScript.DecreaseHealthMeter("magic", damageToFast);
                break;
        }
    }

    /// <summary>
    /// Creates a dust particle effect and destroys itself after two seconds
    /// </summary>
    /// <param name="collider"></param>
    /// <returns></returns>
    IEnumerator Dust(Collider collider)
    {
        ParticleSystem dustparticle = (ParticleSystem)Instantiate(dust, hammerPoint.transform.position, hammerPoint.transform.rotation);
        yield return new WaitForSeconds(2);
        Destroy(dustparticle);
    }

    /// <summary>
    /// Not sure how this is being used or if it is.....Hammer Down turret is on hold for now
    /// </summary>
    void Shoot()
    {
        attackValue = 1f;
    }

    /// <summary>
    /// Draws the range of the turret to the screen so that we can see it in the scene view
    /// </summary>
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
