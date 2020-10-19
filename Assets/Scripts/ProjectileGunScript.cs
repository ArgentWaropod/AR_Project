using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGunScript : GunScript
{
    public float projectileSpeed, projectileLife;
    public GameObject projectilePrefab;
    public override void Shoot()
    {
        ready = false;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);
        Vector3 Direcction = fpsCam.transform.forward + new Vector3(x, y, 0);

        GameObject projectile = Instantiate(projectilePrefab, attackpoint.position, attackpoint.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(attackpoint.forward * projectileSpeed, ForceMode.Impulse);
        Destroy(projectile, projectileLife);
        left--;
        shot--;

        Invoke("resetShot", time);
        if (shot > 0 && left > 0)
        {
            Invoke("Shoot", tbs);
        }
    }

    public override void PackAPunch()
    {
        magSize *= 4;
        reserveAmmo *= 4;
        gameObject.GetComponent<MeshRenderer>().material = papCamo;

    }
}
