using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDE : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Zombie>())
        {
            other.GetComponent<Zombie>().TakeDamage(9999999);
        }
    }
}
