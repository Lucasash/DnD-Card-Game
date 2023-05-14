using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillYouself : Spell
{ 
    public override void playCard()
    {
        startSelect();
        base.playCard();
    }
    public override void effect(Monster card)
    {
        if (player.enemyPlayer.playArea.cardsList.Contains(card))
        {
            base.effect(card);
            card.health = 0;
        }
    }
    public override void effect(PlayerManager targetPlayer)
    {

    }
}
