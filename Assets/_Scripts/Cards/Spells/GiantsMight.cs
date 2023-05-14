using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantsMight : Spell
{
    public override void playCard()
    {
        startSelect();
        base.playCard();
    }
    public override void effect(Monster card)
    {
        if (player.playArea.cardsList.Contains(card))
        {
            base.effect(card);
            card.health += (card.health - card.damage);
        }
    }
    public override void effect(PlayerManager targetPlayer)
    {

    }
}
