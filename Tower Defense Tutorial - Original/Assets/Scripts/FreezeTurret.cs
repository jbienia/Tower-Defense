using UnityEngine;
using System.Collections;

public class FreezeTurret : Turret {

    Transform freezeLight;
    private GameObject enemy;
    private Enemy[] enemies;
    private Collider[] colliders;

    void Awake()
    {
        base.firePoint = null;
        base.bulletPrefab = null;

        freezeLight = gameObject.transform.GetChild(0);
        freezeLight.gameObject.SetActive(false);
    }

    public override void Shoot()
    {
        freezeLight.gameObject.SetActive(true);
        enemy = target.gameObject;

        colliders = Physics.OverlapSphere(transform.position, range);

        // Loops through the colliders and checks the tags
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy" || collider.tag == "FlyingEnemy" || collider.tag == "Tank")
            {
                collider.GetComponent<Enemy>().speed -= 3;
                //enemies += collider.GetComponent<Enemy>;
            }
        }

        StartCoroutine(TurnOffFreezeLight());
        


    }

    /// <summary>
    /// Used specifically to turn the freeze light off after 3 seconds
    /// </summary>
    /// <returns></returns>
    IEnumerator TurnOffFreezeLight()
    {
        yield return new WaitForSeconds(3f);
        freezeLight.gameObject.SetActive(false);

        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy" || collider.tag == "FlyingEnemy" || collider.tag == "Tank")
            {
                collider.gameObject.GetComponent<Enemy>().speed += 3;
            }
        }

        //enemy.GetComponent<Enemy>().speed += 3;

    }

    
}
