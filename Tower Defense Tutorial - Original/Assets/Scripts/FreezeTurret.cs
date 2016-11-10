using UnityEngine;
using System.Collections;

/// <summary>
/// Freeze turret will freeze or slow down the enemy
/// </summary>
public class FreezeTurret : Turret
{

    // Reference to the child of the freeze turret which is the light object
    Transform freezeLight;

    private Enemy[] enemies;
    private Collider[] colliders;

    /// <summary>
    /// Sets a couple inherited properties to null
    /// Gets a reference to the Light Game object connected to the Freeze Turret
    /// </summary>
    void Awake()
    {
        base.firePoint = null;
        base.bulletPrefab = null;

        // The child of the Freeze Turret
        freezeLight = gameObject.transform.GetChild(0);

        // Setting to false turns the light off
        freezeLight.gameObject.SetActive(false);
    }

    /// <summary>
    /// The Freeze Turret will halt or slow down enemies as opposed to firing a projectile at the enemy
    /// </summary>
    public override void Shoot()
    {
        // Turns the light on
        freezeLight.gameObject.SetActive(true);

        // An array of colliders all within a specific range
        colliders = Physics.OverlapSphere(transform.position, range);

        // Loops through the colliders and checks the tags
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy" || collider.tag == "FlyingEnemy" || collider.tag == "Tank")
            {
                // Reduces the speed of the enemy by three
                collider.GetComponent<Enemy>().speed -= 3;

            }
        }

        // Used specifically to turn the freeze light off after 3 seconds and to increase of the enemy back up
        StartCoroutine(TurnOffFreezeLight());
    }

    /// <summary>
    /// Used specifically to turn the freeze light off after 3 seconds
    /// </summary>
    /// <returns></returns>
    IEnumerator TurnOffFreezeLight()
    {
        // Waits for 3 seconds
        yield return new WaitForSeconds(3f);

        // Turns the light off on the Freeze turret
        freezeLight.gameObject.SetActive(false);

        // Loops through the colliders array and adds the speed back to the enemy that was previously turned off
        foreach (Collider collider in colliders)
        {
            if(collider != null)
            {
                if (collider.tag == "Enemy" || collider.tag == "FlyingEnemy" || collider.tag == "Tank")
                {
                    collider.gameObject.GetComponent<Enemy>().speed += 3;
                }
            }
           
        }
    }
}
