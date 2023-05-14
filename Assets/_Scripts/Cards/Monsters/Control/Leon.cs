using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leon : Monster
{
    private int shots;
    public override void battlecryEffect()
    {
        base.battlecryEffect();
        if (player.enemyPlayer.playArea.cardsList.Count > 0)
        {
            startSelect();
        }
    }
    public override void effect(Monster card)
    {
        card.damage += 1;
        shots += 1;

        if (shots >= 2 || (player.enemyPlayer.playArea.cardsList.Count <= 1))
        {
            base.effect(card);
        }
    }
    public override void effect(PlayerManager targetPlayer)
    {
        
    }
}
