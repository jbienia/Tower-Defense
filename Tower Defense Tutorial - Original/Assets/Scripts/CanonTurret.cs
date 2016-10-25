using UnityEngine;
using System.Collections;

public class CanonTurret : Turret {

    public GameObject groundTerrain;

    public override void Shoot()
    {
        // Creates the Bullet game object in the scene
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // bulletGO.transform.rotation = Quaternion.Euler(90,0,0);

        // A reference to the Bullet script/Component
        // Bullet bullet = bulletGO.GetComponent<Bullet>();
        CanonBullet bullet = bulletGO.GetComponent<CanonBullet>();


        // passes the target/enemt to the bullet class
        if (bullet != null)
        {
            bullet.Seek(target);
        }

    }
}

