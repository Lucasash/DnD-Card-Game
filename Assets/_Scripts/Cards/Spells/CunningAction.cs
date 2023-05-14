


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CunningAction : Spell
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
            card.player.hand.returnCardToHand(card);
            base.effect(card);
        }
        
    }
    public override void effect(PlayerManager targetPlayer)
    {

    }
}
