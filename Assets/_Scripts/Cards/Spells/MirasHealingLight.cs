using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirasHealingLight : Spell
{
    public override void playCard()
    {
        startSelect();
        base.playCard();
    }
    public override void effect(Monster card)
    {
        base.effect(card);
        card.damage -= 3;
        if (card.damage < 0)
        {
            card.damage = 0;
        }
    }
    public override void effect(PlayerManager targetPlayer)
    {
        base.effect(targetPlayer);
        targetPlayer.health += 3;
    }
}
