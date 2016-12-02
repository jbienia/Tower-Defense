﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Class is a component of the turret Game object
/// </summary>
public class Turret : MonoBehaviour {

    // The transform of the target the turret is shooting at
    public Transform target;

    [Header("Attributes")]
    public float fireCountdown;
    public float range = 15f;
    public Vector3 inRange;

    // Strings that represent the different type of tanks
    public string enemyTag = "Enemy";
    public string tankEnemyTag = "Tank";
    public string flyingEnemyTag = "FlyingEnemy";

    [Header("Unity Setup Fields")]
    public Transform partToRotate;
    public float turnSpeed = 10f;

    [Header("Damage Values")]
    public int damageToBasic;
    public int damageToTank;
    public int damageToFlying;
    public int damageToFast;

    public AudioClip arrowSwoosh;
    

    // Prefab for the bullet
    public  GameObject bulletPrefab;

    float countdown;

    Vector3 arrowTurretRange = new Vector3(9,2,10);

    // The point in the game where turret fires from
    public Transform firePoint;

    // A list of enemy game objects
    public List<GameObject> enemyList = new List<GameObject>();

    // A static singleton instance of the EnemyManager
    EnemyManager instance;
    
	/// <summary>
    /// Gets a reference to EnemyManager Singleton, and Invokes a method every few seconds
    /// </summary>
	public void Start ()
    {
        // An instance of the enemy manager object 
        instance = EnemyManager.enemyManagerInstance;

        // Invokes a method named UpdateTarget every couple seconds
        InvokeRepeating("UpdateTarget", 0f, 0.1f);

        countdown = fireCountdown;
        fireCountdown = 0;

	}
    
    /// <summary>
    /// Checks for the targets in range, 
    /// </summary>
    void UpdateTarget()
    {
        // A lists of all the Enemies in the game
        enemyList = EnemiesInGame.allEnemiesInGame;
               
        // Here we use infinity so that it is true;
        float shortestDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;

        // Finds the distance betweent the turret and the enemy 
        foreach(GameObject enemy in enemyList)
        {
            // Gets the distance from our turret to the enemy
            float distanceToEnemy = Vector3.Distance(transform.position + transform.forward * 5 + Vector3.up, enemy.transform.position);
            

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
            //Rect rect = new Rect(0, 0, 10, 10);

           // Debug.Log(inRange.z/2);
            target = nearestEnemy.transform;

            Vector3 dir = target.position - transform.position;

            // Sets the rotation with the specified dir
            Quaternion lookRotation = Quaternion.LookRotation(dir);

            // Sets the rotation to a Vector 3 user the eulerAngles method.
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;

            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }

        else
        {
            target = null;
        }
    }
	
	/// <summary>
    /// Update called once per frame
    /// 
    /// </summary>
	void Update ()
    {
        // Checks if there is a target to shoot at and if the fireCountdown has reached zero
        if(target == null)
        {
            if(fireCountdown > 0)
            {
                fireCountdown -= Time.deltaTime;
            }
            
            return;
        }

        // Turret fires only if there is a target and the firecountdown had reached zero
        if(fireCountdown <= 0)
        {
            // This makes sure that Canons don't fire at the Flying Enemies and that magic towers only fire at flying enemeies.
            if(gameObject.tag == "Canon" && target.tag == "FlyingEnemy" || gameObject.tag == "AntiAir" && target.tag != "FlyingEnemy")
            {
                
                target = null;
            }
            else
            {
               
                Shoot();
                target = null;
            }
            
            fireCountdown = countdown;
        }

        
        fireCountdown -= Time.deltaTime;
     }

    /// <summary>
    /// Instanciates a bullet object and sends a message to the bullet script with information about the target and how much damage to do
    /// </summary>
    public virtual void  Shoot()
    {
        // Turret shoots at the enemy
        AudioManager.audioManager.ArrowSound(arrowSwoosh);

        // Creates the Bullet game object in the scene
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
     
        // A reference to the Bullet script/Component
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        // passes the target/enemy to the bullet class
        if (bullet != null)
        {
            switch (target.tag)
            {
                case "Enemy":
                    bullet.Seek(target, damageToBasic);
                    break;

                case "FlyingEnemy":
                    bullet.Seek(target, damageToFlying);
                    break;

                case "Tank":
                    bullet.Seek(target, damageToTank);
                    break;

                case "FastEnemy":
                    bullet.Seek(target, damageToFast);
                    break;
            }

        }
    }

    /// <summary>
    /// Draws a circle that represents the range of the turret
    /// </summary>
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position+ transform.forward * 5 + Vector3.up,range);
       // Gizmos.DrawCube(transform.position, inRange);
        //Gizmos.DrawWireCube(transform.position + transform.forward * 5, inRange);
       
        
    }
}
