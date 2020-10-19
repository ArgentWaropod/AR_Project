using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class rocket : MonoBehaviour
{
    public float radius;
    public int damage;
    public GameObject explosion;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        Explode(collision.contacts[0].point);
        Destroy(gameObject);
    }
    void Explode(Vector3 point)
    {
        GameObject boom = Instantiate(explosion, point, Quaternion.identity);
        Destroy(boom, 2f);
        Collider[] hitColliders = Physics.OverlapSphere(point, radius);
        foreach (Collider hit in hitColliders)
        {
            if (hit.GetComponent<Zombie>())
            {
                Debug.Log("Rocket Damage: " + damage);
                hit.GetComponent<Zombie>().TakeDamage(damage);
            }
        }
    }
}
