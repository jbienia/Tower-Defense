using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HorseRedTurret : MonoBehaviour {

    public float range = 15f;
    public float speed = 10f;
    private Transform target;
    public float attackCountdown = 0f;
    public float fireRate = 1f;
    GameObject[] enemiesInGame;
    private string enemyTag;
    Animator isAttacking;

    public string enemyEnemyTag = "Enemy";
    public string tankEnemyTag = "Tank";
    public string flyingEnemyTag = "FlyingEnemy";

    EnemyManager instance;

    public List<GameObject> enemyList = new List<GameObject>();
    




   // Use this for initialization
	void Start () {
        // Invokes a method name every couple seconds
        InvokeRepeating("UpdateTarget", 0f, 0.3f);
        isAttacking = GetComponent<Animator>();
        enemyEnemyTag = "Enemy";
        tankEnemyTag = "Tank";
        flyingEnemyTag = "FlyingEnemy";
        //enemyList = instance.firstBasicWaveToSpawn;
        //enemyList.Add(instance.secondTankWaveToSpawn);
        enemyList = EnemiesInGame.allEnemiesInGame;

    }

    void UpdateTarget()
    {
        // Gets an instance of Turrent Manager. Used to get an array of enemy Game objects in the scene
        instance = EnemyManager.enemyManagerInstance;

        // enemyList = instance.firstBasicWaveToSpawn;
        

        // Here we use infinity so that it is true;
        float shortestDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;

        // Finds the distance between the turret and the enemy 
        foreach (GameObject enemy in enemyList)
        {
            //Debug.Log("IM ATTAKCING");
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

            // Gets a reference to the enemy tag
            enemyTag = target.tag;
            Vector3 dir = target.position - transform.position;
            Quaternion lookDirection = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, 20f * Time.deltaTime * speed);

            
            Attack();
         }

        else
        {
            target = null;
            isAttacking.SetBool("isAttacking", false);
        }
    }
	
	// Update is called once per frame
	void Update () {

        // subtracts from the attack countdown timer
        attackCountdown -= Time.deltaTime;
        
    }

    /// <summary>
    /// un used method...Delete this????
    /// </summary>
    /// <param name="badGuys"></param>
    /// <returns></returns>
    public GameObject[] HorseRedTurretGetEnemies(GameObject[] badGuys)
    {
        return enemiesInGame = badGuys;
    }


    /// <summary>
    /// Sets the attack animation
    /// sets the attack countdown timer
    /// decreases the enemy health bar 
    /// </summary>
    void Attack()
    {
        // Write code to check for the e


        if (attackCountdown <= 0)
        {
            isAttacking.SetBool("isAttacking", true);
            attackCountdown = 1f / fireRate;

           GetCorrectScript(enemyTag);

            //TankEnemy enemyScript = target.gameObject.GetComponent<TankEnemy>();

            //FlyingEnemy enemyScript = target.gameObject.GetComponent<FlyingEnemy>();
            //enemyScript.HealthMeter();
            
        }
     }

    void GetCorrectScript(string enemyTag)
    {
        Debug.Log("SWITCH STATEMENT");
        string melee = "melee";
        switch(enemyTag)
        {
            case "Enemy":
                Enemy enemyScript = target.gameObject.GetComponent<Enemy>();
                enemyScript.HealthMeter(enemyTag,melee);
                break;

            case "FlyingEnemy":
                 enemyScript = target.gameObject.GetComponent<FlyingEnemy>();
                enemyScript.HealthMeter(enemyTag, melee);
                break;

            case "Tank":
                 enemyScript = target.gameObject.GetComponent<TankEnemy>();
                enemyScript.HealthMeter(enemyTag, melee);
                break;
        }

       // className enemyScript = target.gameObject.GetComponent<className>();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
