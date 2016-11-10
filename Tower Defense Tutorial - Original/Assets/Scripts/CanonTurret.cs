using UnityEngine;
using System.Collections;

/// <summary>
/// CanonTurret overrides the Shoot method from its base class
/// </summary>
public class CanonTurret : Turret {

    public override void Shoot()
    {
        // Creates the Bullet game object in the scene
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        // A reference to the CanonBullet script/Component
        CanonBullet bullet = bulletGO.GetComponent<CanonBullet>();

        // passes a reference to the target/enemy game obect to the bullet class
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
}

