using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mystery : MonoBehaviour
{
    public GameObject canvas;
    public TextMeshProUGUI field;
    public int cost;
    public bool active, ableToBuy;
    public Manager man;
    GameObject player;
    //public GameObject /*gunpoint, */chosenGun;

    private void Start()
    {
        resetActive();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }

    public int SpinTheBox(Player playa)
    {
        return Random.Range(0, playa.weaponList.Count);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && ableToBuy)
        {
            Debug.Log("Ping");
            player = other.gameObject;
            canvas.gameObject.SetActive(true);
            field.text = "Buy a random weapon for " + cost.ToString() + "?";
            active = true;
        }
    }

    private void resetActive()
    {
        ableToBuy = true;
    }    
    public void PurchaseButton()
    {
        if (man.points >= cost)
        {
            man.points -= cost;
            canvas.gameObject.SetActive(false);
            active = false;
            ableToBuy = false;
            Player playersGun = player.GetComponent<Player>();
            playersGun.NewGun(SpinTheBox(playersGun));
            Invoke("resetActive", 2);
        }
    }
}
