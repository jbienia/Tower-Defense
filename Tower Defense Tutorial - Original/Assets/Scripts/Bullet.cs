using UnityEngine;
using UnityEngine.UI;


public class Bullet : MonoBehaviour {

    public Transform target;

    public float speed = 70f;
    public GameObject impactEffect;
    public float explosionRadius = 0f;

    public Slider healthBar;
    private int startingHealth = 100;
    private int currentHealth;
    private Quaternion lookRotation;
    private Vector3 adjust;
    bool isFirstShot = true;
    private bool stopFollowingEnemy = true;
    
    
    void Awake()
    {
        currentHealth = startingHealth;
        //healthBar.value = currentHealth;

        //Debug.Log("It works!");
        
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }
	
	// Update is called once per frame
	void Update () {

        if(target == null)
        {
            //Destroy(gameObject);
            return;
        }

        // direction to move the bullet from itself to the enemy
        Vector3 dir = target.position + Vector3.up * 2 - transform.position;

        // The speed of the bullet relative to time
        float distanceThisFrame = speed * Time.deltaTime;

        // Checks if the bullet has hit the enemy
        if(isFirstShot)
        {
            if (dir.magnitude <= distanceThisFrame)
            {
                
                HitTarget();
                stopFollowingEnemy = false;
                return;
            }
        }

        // stopFollowingEnemy will be false if the bullet has reached the object
        if(stopFollowingEnemy)
        {
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
        
        lookRotation = Quaternion.LookRotation(dir);
        //lookRotation.x = 1f;
        transform.rotation = Quaternion.Lerp(target.rotation,lookRotation,Time.deltaTime * 50);
        
	}

    /// <summary>
    /// 
    /// </summary>
    void HitTarget()
    {
       //GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        //Destroy(effectIns, 5f);

        if(explosionRadius > 0f)
        {
            //Debug.Log("Dead");
            Explode();
        }
        else
        {
            Damage(target);
        }

        //Destroy(effectIns,2f);
        // Destroy(target.gameObject);

        // Used to make sure that the enemy only gets hit once with one bullet
        isFirstShot = false;
        Destroy(gameObject,1f);
    }


    /// <summary>
    /// Gets all the colliders in a specific radius
    /// Checks colliders for the enemy tag
    /// Runs the Damage method and passes the transform of the damaged object
    /// </summary>
    void Explode()
    {
        // Gets an array of colliders in a certain radius around the transform
       Collider[] colliders = Physics.OverlapSphere(transform.position,explosionRadius);

        // Loops through the colliders and checks the tags
        foreach(Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }

        }
    }

    public virtual void Damage(Transform enemy)
    {
      // Reference to the enemy script
      Enemy enemyScript = enemy.gameObject.GetComponent<Enemy>();

        switch (enemy.tag)
        {
            case "Enemy":
               
                enemyScript.HealthMeter("arrow");
                break;

            case "FlyingEnemy":
                enemyScript = target.gameObject.GetComponent<FlyingEnemy>();
                enemyScript.HealthMeter("arrow");
                break;

            case "Tank":
                enemyScript = target.gameObject.GetComponent<TankEnemy>();
                enemyScript.HealthMeter("arrow");
                break;
        }


        //enemyScript.HealthMeter();

        Debug.Log("Jason");
        
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    
}
