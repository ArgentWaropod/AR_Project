using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juggernaught : PerkMachine
{
    public void Start()
    {
        cost = 2500;
        perkName = "Juggernaught";
        purchased = false;
        active = false;
        canvas.gameObject.SetActive(false);
    }

    public override void OnPurchase(Manager thePlayer)
    {
        thePlayer.playerHealth = 5;
    }
}
