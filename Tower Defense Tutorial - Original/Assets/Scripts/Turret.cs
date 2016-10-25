using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : MonoBehaviour {

    public Transform target;

    [Header("Attributes")]
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public float range = 15f;
    public string enemyTag = "Enemy";
    public string tankEnemyTag = "Tank";
    public string flyingEnemyTag = "FlyingEnemy";

    [Header("Unity Setup Fields")]
        
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public List<GameObject> enemyList = new List<GameObject>();
    EnemyManager instance;

   


	// Use this for initialization
	void Start () {
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
        foreach(GameObject enemy in enemyList)
        {
            // Gets the distance from our turret to the enemy
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            // Tests for the enemy that is closest to the turret
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        // Sets the target transform if the target is in range
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(target == null)
        {
            return;
        }

        // The direction from the turret to the enemy
        Vector3 dir = target.position - transform.position;

        // Sets the rotation with the specified dir
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        // Sets the rotation to a Vector 3 user the eulerAngles method.
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime * turnSpeed).eulerAngles;

        partToRotate.rotation =Quaternion.Euler(0f,rotation.y,0f);

        if(fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;


	}

    public virtual void  Shoot()
    {
        Debug.Log("SHOT");
       // Creates the Bullet game object in the scene
      GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
       // bulletGO.transform.rotation = Quaternion.Euler(90,0,0);
        
        // A reference to the Bullet script/Component
         Bullet bullet = bulletGO.GetComponent<Bullet>();
        //CanonBullet bullet = bulletGO.GetComponent<CanonBullet>();


        // passes the target/enemt to the bullet class
        if(bullet != null)
        {
            bullet.Seek(target);
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
