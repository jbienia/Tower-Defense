using UnityEngine;
using System.Collections;

public class MagicBullet : Bullet {

    private bool isFirstShot = true;
    private bool stopFollowingEnemy = true;

    public override void Update()
    {
        if (target == null)
        {
            return;
        }

        // direction to move the bullet from itself to the enemy
        Vector3 dir = target.position + Vector3.up * 2 - transform.position;

        // The speed of the bullet relative to time
        float distanceThisFrame = speed * Time.deltaTime;

        // Checks if the bullet has hit the enemy
         if (isFirstShot)
        {
            if (dir.magnitude <= distanceThisFrame)
            {

                HitTarget();
                stopFollowingEnemy = false;
                return;
            }
        }

        // stopFollowingEnemy will be false if the bullet has reached the object
        if (stopFollowingEnemy)
        {
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }

        lookRotation = Quaternion.LookRotation(dir);

        transform.rotation = Quaternion.Lerp(target.rotation, lookRotation, Time.deltaTime * 50);

    }

    public override void HitTarget()
    {
        if (explosionRadius > 0f)
        {
            //Debug.Log("Dead");
            Explode();
        }
        else
        {
            Damage(target);
        }

        // Used to make sure that the enemy only gets hit once with one bullet
        isFirstShot = false;
        Destroy(gameObject, 1f);
        
    }

    public override void  Damage (Transform enemy)
    {
        
        // Reference to the enemy script
        Enemy enemyScript = enemy.gameObject.GetComponent<Enemy>();

        switch (enemy.tag)
        {
            case "Enemy":
                enemyScript.HealthMeter("magic");
                break;

            case "FlyingEnemy":
                enemyScript = target.gameObject.GetComponent<FlyingEnemy>();
                enemyScript.HealthMeter("magic");
                break;

            case "Tank":
                enemyScript = target.gameObject.GetComponent<TankEnemy>();
                enemyScript.HealthMeter("magic");
                break;
        }
    }
}
