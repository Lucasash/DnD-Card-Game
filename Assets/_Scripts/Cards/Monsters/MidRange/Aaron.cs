using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aaron : Monster
{
    public override void battlecryEffect()
    {
        base.battlecryEffect();
        startSelect();
    }
    public override void select(Monster card)
    {
        if (player.playArea.cardsList.Contains(gameManager.targetMonster))
        {
            effect(card);
        }
    }
    public override void effect(Monster card)
    {
        base.effect(card);
        card.barrier = true;
        card.barrierHit = true;
        if (card.keywords.text != "")
        {
            card.keywords.text += "; ";
        }
            card.keywords.text += "Barrier";
    }
    public override void effect(PlayerManager targetPlayer)
    {

    }
}
