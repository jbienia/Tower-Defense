using UnityEngine;
using System.Collections;

/// <summary>
/// Class used to override the Shoot() from the base class
/// </summary>
public class MagicTurret : Turret {

    // Instanciates a magic bullet and passes a reference to the target
	public override void Shoot()
    {
        // Creates the Bullet game object in the scene
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // bulletGO.transform.rotation = Quaternion.Euler(90,0,0);

        // A reference to the Bullet script/Component
        MagicBullet bullet = bulletGO.GetComponent<MagicBullet>();
       
        // passes the target/enemt to the bullet class
        if (bullet != null)
        {
            switch(target.tag)
            {
                case "Enemy":
                    bullet.Seek(target,damageToBasic);
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
}

