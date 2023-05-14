using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocsMedicine : Spell
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
            card.health += 2;
            player.deck.drawCard(player.hand, player);
        }
    }
    public override void effect(PlayerManager targetPlayer)
    {

    }
}
