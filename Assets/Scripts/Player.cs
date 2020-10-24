using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<GameObject> weaponList;
    public GameObject weapon1, weapon2;
    public bool weapon1Equiped;
    int counterOne, counterTwo;
    private void Start()
    {
        counterOne = 0;
        foreach (GameObject gun in weaponList)
        {
            gun.gameObject.SetActive(false);
        }
        weapon1Equiped = true;
        weapon1 = weaponList[counterOne];
        weapon1.gameObject.SetActive(true);
        if (weapon2)
        {
            weapon2.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !weapon1Equiped && weapon1 != null)
        {
            weapon1.gameObject.SetActive(true);
            weapon2.gameObject.SetActive(false);
            weapon1Equiped = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && weapon1Equiped && weapon2 != null)
        {
            weapon2.gameObject.SetActive(true);
            weapon1.gameObject.SetActive(false);
            weapon1Equiped = false;
        }
    }

    public void NewGun(int tracker)
    {
        if (weapon1Equiped && weapon2)
        {
            weaponList[counterOne].SetActive(false);
            weaponList[tracker].SetActive(true);
            weapon1 = weaponList[tracker];
            counterOne = tracker;
        }
        else
        {
            weaponList[counterTwo].SetActive(false);
            weaponList[tracker].SetActive(true);
            weapon2 = weaponList[tracker];
            counterTwo = tracker;
        }
    }

    public void Switch()
    {
        if (!weapon1Equiped && weapon1 != null)
        {
            weapon1.gameObject.SetActive(true);
            weapon2.gameObject.SetActive(false);
            weapon1Equiped = true;
        }
        if (weapon1Equiped && weapon2 != null)
        {
            weapon2.gameObject.SetActive(true);
            weapon1.gameObject.SetActive(false);
            weapon1Equiped = false;
        }
    }

    public void Reload()
    {
        if (weapon1Equiped)
        {
            weapon1.GetComponent<GunScript>().ButtonFire();
        }
        else
        {
            weapon2.GetComponent<GunScript>().ButtonFire();
        }
    }

    public void RealReload()
    {
        if (weapon1Equiped)
        {
            weapon1.GetComponent<GunScript>().Reload();
        }
        else
        {
            weapon2.GetComponent<GunScript>().Reload();
        }
    }
}
