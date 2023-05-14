using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doc : Monster
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
        card.attackBonus += 1;
        card.healthBonus += 1;
    }
    public override void effect(PlayerManager targetPlayer)
    {

    }
}
