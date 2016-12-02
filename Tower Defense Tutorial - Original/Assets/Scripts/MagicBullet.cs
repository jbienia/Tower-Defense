using UnityEngine;
using System.Collections;

public class MagicBullet : Bullet {

    // Used to make sure that the enemy only gets hit once per magic bullet
    private bool isFirstShot = true;

     
    private bool stopFollowingEnemy = true;
    private Transform[] magicBulletChildren;
    public GameObject fireObject;

    public override void Update()
    {
        if (target == null)
        {
            Destroy(gameObject, 1f);
            return;
        }

        // direction to move the bullet from itself to the enemy
        Vector3 dir = target.position + Vector3.up * 2 - transform.position;

        // The speed of the bullet relative to time
        float distanceThisFrame = speed * Time.deltaTime;

        // Checks if the bullet has hit the enemy
        if (isFirstShot)
        {
            if (dir.magnitude < 0.5f)
            {
                Debug.Log(dir.magnitude);
                Destroy(gameObject, 1f);
                HitTarget();
                stopFollowingEnemy = false;
                return;
            }
        }

        // Moves the bullet towards the enemy
         transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        
        // I'm not sure why I had this rotation set for the bullet. I'm going to leave it here for now and decide later if it's not necessary
        //lookRotation = Quaternion.LookRotation(dir);
        //transform.rotation = Quaternion.Lerp(target.rotation, lookRotation, Time.deltaTime * 50);
    }

    /// <summary>
    /// Deals damage to the enemy
    /// </summary>
    public override void HitTarget()
    {
        if (explosionRadius > 0f)
        {
           Explode();
        }
        else
        {
            Debug.Log("Take Magic Damage!");
            Damage(target,damageValue);
        }

        // Used to make sure that the enemy only gets hit once with one bullet
        isFirstShot = false;
     }

    /// <summary>
    /// Overrides the Damage() from the Base Class
    /// Gets a reference to the enemies Enemy script and removes value from the health meter
    /// </summary>
    /// <param name="enemy">The switch statement uses the transfrom to access the tag parameter</param>
    public override void  Damage (Transform enemy, int damage)
    {
        AudioManager.audioManager.PlayEnemyHurtSound(enemy.tag);
        // Reference to the enemy script
        Enemy enemyScript = enemy.gameObject.GetComponent<Enemy>();

        switch (enemy.tag)
        {
            case "Enemy":
                enemyScript.DecreaseHealthMeter("magic",damage);
                break;

            case "FlyingEnemy":
                enemyScript = target.gameObject.GetComponent<FlyingEnemy>();
                enemyScript.DecreaseHealthMeter("magic",damage);
                break;

            case "Tank":
                enemyScript = target.gameObject.GetComponent<TankEnemy>();
                enemyScript.DecreaseHealthMeter("magic",damage);
                break;

            case "FastEnemy":
                 enemyScript = target.gameObject.GetComponent<Enemy>();
                enemyScript.DecreaseHealthMeter("magic", damage);
                break;
        }
    }
}
