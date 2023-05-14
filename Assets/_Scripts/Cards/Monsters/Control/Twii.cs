using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twii : Monster
{
    [SerializeField] private GameObject mysticShot;
    public override void battlecryEffect()
    {
        base.battlecryEffect();
        Card card = Instantiate(mysticShot).GetComponent<Card>();
        player.hand.addCard(card);
        card.GetComponent<Card>().player = player;
    }
}
