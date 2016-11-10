using UnityEngine;
using System.Collections;

public class FreezeTurret : Turret {

    Transform freezeLight;

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

    }

    
}
