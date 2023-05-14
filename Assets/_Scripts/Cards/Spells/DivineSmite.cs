using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivineSmite : Spell
{
    public override void playCard()
    {
        startSelect();
        base.playCard();
    }
    public override void effect(Monster card)
    {
        base.effect(card);
        card.attack += 2;
    }
    public override void effect(PlayerManager targetPlayer)
    {

    }
}
