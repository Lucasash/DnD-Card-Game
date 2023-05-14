using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ozwin : Monster
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
        card.health += 2;
    }
    public override void effect(PlayerManager targetPlayer)
    {

    }
}
