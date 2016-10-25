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
         canonballRigid = GetComponent<Rigidbody>();
        // healthBar.value = currentHealth;
        //Debug.Log(healthBar.value);
        //Debug.Log("It works!");
       // stableTarget = target.transform;
        

    }

    void Start()
    {
        stableTarget = target.transform.position;
        canonballRigid.AddForce(BallisticVel(stableTarget), ForceMode.VelocityChange);
    }

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

        // direction to move the bullet from itself to the enemy
        //Vector3 dir = target.position - transform.position;

        // The speed of the bullet relative to time
        float distanceThisFrame = speed * Time.deltaTime;

      //  for(int i = 0; i < Ground.ground.Length; i++)
       // {
            
        //    Vector3 dir = Ground.ground[i].position - transform.position;
          //  if (transform.position.y < 2)
           // {
                //Debug.Log("HIT TARGET!");
             //   HitTarget();
               // return;
           // }

        //}
    }

    void OnTriggerEnter(Collider collision)
    {
       
        if (collision.gameObject.tag == "Terrain")
        {
           
                Debug.Log("DEStroy myBOMB!!");
                Destroy(gameObject);

            
        }
    }

    // Returns the velocity needed to hit the target
    Vector3 BallisticVel(Vector3 target)
    {
        //Debug.Log("Velocity!");
        var dir = target - transform.position; // get target direction
        
        var h = dir.y;  // get height difference
        dir.y = 0;  // retain only the horizontal direction
        var dist = dir.magnitude;  // get horizontal distance
        
        dir.y = dist * 1f;  // set elevation to 45 degrees
        dist += h;  // correct for different heights
        
        float vel = Mathf.Sqrt(dist * Physics.gravity.magnitude);
        //vel -= 2f;
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
        switch (enemyTag)
        {
            case "Enemy":
                Enemy enemyScript = enemy.gameObject.GetComponent<Enemy>();
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

