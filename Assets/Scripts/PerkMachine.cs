using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PerkMachine : MonoBehaviour
{
    public GameObject canvas;
    public TextMeshProUGUI field;
    public int cost;
    public string perkName;
    public bool purchased;
    public bool active;
    public Manager man;
    GameObject player;
    // Start is called before the first frame update

    private void Start()
    {
        purchased = false;
        active = false;
        canvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (active && man.points >= cost)
            {
                man.points -= cost;
                canvas.gameObject.SetActive(false);
                active = false;
                purchased = true;
                OnPurchase(man);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player" && !purchased)
        {
            player = other.gameObject;
            canvas.gameObject.SetActive(true);
            field.text = "Buy " + perkName + " for " + cost.ToString() + "?";
            active = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canvas.gameObject.SetActive(false);
        active = false;
    }
    public virtual void OnPurchase(Manager thePlayer)
    {

    }
}
