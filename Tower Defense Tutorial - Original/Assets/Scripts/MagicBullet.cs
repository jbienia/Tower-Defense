using UnityEngine;
using System.Collections;

public class MagicBullet : Bullet {

	// Use this for initialization
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
