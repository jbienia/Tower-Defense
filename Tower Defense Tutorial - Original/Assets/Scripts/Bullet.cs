using UnityEngine;
using UnityEngine.UI;


public class Bullet : MonoBehaviour {

    private Transform target;

    public float speed = 70f;
    public GameObject impactEffect;
    public float explosionRadius = 0f;

    public Slider healthBar;
    private int startingHealth = 100;
    private int currentHealth;
    

    
    
    
    void Awake()
    {
        currentHealth = startingHealth;
        healthBar.value = currentHealth;

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
            Destroy(gameObject);
            return;
        }

        // direction to move the bullet from itself to the enemy
        Vector3 dir = target.position - transform.position;

        // The speed of the bullet relative to time
        float distanceThisFrame = speed * Time.deltaTime;

        // Checks if the bullet has hit the enemy
        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame,Space.World);
        
        // Causes the missile to point towards its target 
        transform.LookAt(target);
	}

    /// <summary>
    /// 
    /// </summary>
    void HitTarget()
    {
       GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

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

    void Damage(Transform enemy)
    {
      // Reference to the enemy script
      Enemy enemyScript = enemy.gameObject.GetComponent<Enemy>();

        //enemyScript.HealthMeter();

        Debug.Log(healthBar.value);
        
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    
}
