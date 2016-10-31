using UnityEngine;
using System.Collections;

public class MagicTurret : Turret {

	public override void Shoot()
    {
        // Creates the Bullet game object in the scene
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // bulletGO.transform.rotation = Quaternion.Euler(90,0,0);

        // A reference to the Bullet script/Component
        MagicBullet bullet = bulletGO.GetComponent<MagicBullet>();
        //CanonBullet bullet = bulletGO.GetComponent<CanonBullet>();


        // passes the target/enemt to the bullet class
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
}

