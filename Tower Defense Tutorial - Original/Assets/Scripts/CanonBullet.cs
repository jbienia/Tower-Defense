using UnityEngine;
using UnityEngine.UI;


public class CanonBullet : MonoBehaviour
{

    private Transform target;

    public float speed = 70f;
    public GameObject impactEffect;
    public float explosionRadius = 0f;

    public Slider healthBar;
   // private int startingHealth = 100;
    //private int currentHealth;
    public GameObject canonBall;
    Rigidbody canonballRigid;
    float shootAngle = 30;
    private Vector3 stableTarget;




    void Awake()
    {
       // currentHealth = startingHealth;
         //canonballRigid = GetComponent<Rigidbody>();
        //stableTarget = target.transform.position;
        // healthBar.value = currentHealth;
        //Debug.Log(healthBar.value);
        //Debug.Log("It works!");
        // stableTarget = target.transform;


    }

    void Start()
    {
        canonballRigid = GetComponent<Rigidbody>();
        stableTarget = target.transform.position;
        Debug.Log(stableTarget);
        Debug.Log(stableTarget);
        
        if (stableTarget != null)
        {
            canonballRigid.AddForce(BallisticVel(stableTarget), ForceMode.VelocityChange);
        }
        
       
    }

    /*
    void FixedUpdate()
    {
        if (stableTarget != null)
        {
            canonballRigid.AddForce(BallisticVel(stableTarget), ForceMode.VelocityChange);
        }
    }
    */

    public void Seek(Transform _target)
    {
        target = _target;
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

    void OnTriggerEnter(Collider collision)
    {
       
        if (collision.gameObject.tag == "Terrain")
        {
           
                Debug.Log("DEStroy myBOMB!!");
            HitTarget();
                Destroy(gameObject);

            
        }
    }

    // Returns the velocity needed to hit the target
    Vector3 BallisticVel(Vector3 target)
    {
        //Debug.Log("Velocity!");
        var dir = target - transform.position; // get target direction
        Debug.Log("Dir = " + dir);
        var h = dir.y;  // get height difference
        Debug.Log("h = " + h);
       // dir.y = 0;  // retain only the horizontal direction
        var dist = dir.magnitude;  // get horizontal distance
        Debug.Log("Dist = " + dist);
        dir.y = dist * 1.5f;  // set elevation to 45 degrees
        dist += h;  // correct for different heights
        
        float vel = Mathf.Sqrt(dist * Physics.gravity.magnitude * 1.5f);
        //vel -= 2f;
        Debug.Log("Final Vector 3 = " + vel * dir.normalized);
        return vel * dir.normalized;  // returns Vector3 velocity
       

    }

    

    /// <summary>
    /// 
    /// </summary>
    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (explosionRadius > 0f)
        {
            Debug.Log("Dead");
            Explode();
        }
        else
        {
            //Damage(target);
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
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        // Loops through the colliders and checks the tags
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy" || collider.tag == "FlyingEnemy" || collider.tag == "Tank")
            {
                Damage(collider.transform,collider.tag);
               
            }

        }
    }

    void Damage(Transform enemy,string tag)
    {
        

        GetCorrectScript(enemy,tag);
    

    }

    void GetCorrectScript(Transform enemy,string enemyTag)
    {
        string canon = "canon";
        Enemy enemyScript;

        switch (enemyTag)
        {
            case "Enemy":
                 enemyScript = enemy.gameObject.GetComponent<Enemy>();
                enemyScript.HealthMeter(canon);
                break;

            case "FlyingEnemy":
                enemyScript = enemy.gameObject.GetComponent<FlyingEnemy>();
                enemyScript.HealthMeter(canon);
                break;

            case "Tank":
                enemyScript = enemy.gameObject.GetComponent<TankEnemy>();
                enemyScript.HealthMeter(canon);
                break;
        }

    }

        void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }




}

