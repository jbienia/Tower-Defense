using UnityEngine;
using UnityEngine.UI;


public class Bullet : MonoBehaviour
{

    public Transform target;

    public float speed = 70f;
    public GameObject impactEffect;
    public float explosionRadius = 0f;

    public Slider healthBar;
    public int startingHealth = 100;
    public int currentHealth;
    public Quaternion lookRotation;
    public Vector3 adjust;
   


    public virtual void Awake()
    {
        currentHealth = startingHealth;


    }

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
       
       
            if (dir.magnitude <= distanceThisFrame)
            {
            
                HitTarget();
           GameObject bulletImpact =  (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);

            Destroy(bulletImpact, 2f);
                //stopFollowingEnemy = false;
                return;
            }
       
            
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        
        //lookRotation = Quaternion.LookRotation(dir);

        //transform.rotation = Quaternion.Lerp(target.rotation, lookRotation, Time.deltaTime * 50);

    }

    /// <summary>
    /// Used to cause damage to an enemy when hit
    /// </summary>
   public virtual void HitTarget()
    {
        if (explosionRadius > 0f)
        {
            Debug.Log("Dead");
            Explode();
        }
        else
        {
            Damage(target);
        }

        // Used to make sure that the enemy only gets hit once with one bullet
        //isFirstShot = false;
        
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

    public virtual void Damage(Transform enemy)
    {
        Enemy enemyScript;
        switch (enemy.tag)
        {
            case "Enemy":
                 enemyScript = enemy.gameObject.GetComponent<Enemy>();
                enemyScript.HealthMeter("arrow");
                break;

            case "FlyingEnemy":
                enemyScript = target.gameObject.GetComponent<FlyingEnemy>();
                enemyScript.HealthMeter("arrow");
                break;

            case "Tank":
                enemyScript = target.gameObject.GetComponent<TankEnemy>();
                Debug.Log("HIT THE BIG GUY!");
                enemyScript.HealthMeter("arrow");
                break;
        }
    }

   public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
