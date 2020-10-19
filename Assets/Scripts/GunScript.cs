using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunScript : MonoBehaviour
{
    public int damage;
    public float time, spread, range, reload, tbs;
    public int magSize, bulletsPerTap, reserveAmmo;
    public bool allowButtonHold, isPacked, ready;
    public string regName, PAPName;
    public Material papCamo;
    public int left, shot;

    bool shooting, reloading;

    public Camera fpsCam;
    public Transform attackpoint;
    public RaycastHit ray;
    public LayerMask zombie;
    public TextMeshProUGUI text;

    private void Start()
    {
        left = magSize;
        ready = true;
    }

    private void Update()
    {
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        if (Input.GetKeyDown(KeyCode.R) && left < magSize && !reloading && reserveAmmo > 0)
        {
            Reload();
        }

        if (ready && shooting && !reloading && left > 0)
        {
            shot = bulletsPerTap;
            Shoot();
        }
        text.text = left + " / " + reserveAmmo;
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!isPacked)
            {
                Debug.Log("PACK A PUNCH");
                PackAPunch();
                isPacked = true;
            }
        }
    }

    public void Reload()
    {
        reloading = true;
        Invoke("Reloaded", reload);
    }

    public void Reloaded()
    {
        int spentAmmo = magSize - left;
        if (reserveAmmo > magSize)
        {
            left = magSize;
        }
        else
        {
            left = reserveAmmo;
        }
        reserveAmmo -= spentAmmo;
        if (reserveAmmo < 0)
        {
            reserveAmmo = 0;
        }
        reloading = false;
    }
    public virtual void Shoot()
    {
        ready = false;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);
        Vector3 Direcction = fpsCam.transform.forward + new Vector3(x, y, 0);

        if (Physics.Raycast(fpsCam.transform.position, Direcction, out ray, range, zombie))
        {
            if (ray.collider.GetComponent<Zombie>())
            {
                ray.collider.GetComponent<Zombie>().TakeDamage(damage);
            }
        }

        left--;
        shot--;

        Invoke("resetShot", time);
        if (shot > 0 && left > 0)
        {
            Invoke("Shoot", tbs);
        }
    }
    private void resetShot()
    {
        ready = true;
    }

    public virtual void PackAPunch()
    {
        damage *= 2;
        reserveAmmo *= 2;
        gameObject.GetComponent<MeshRenderer>().material = papCamo;

    }
}
