using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elesis : Monster
{
    public override void battlecryEffect()
    {
        base.battlecryEffect();
        startSelect();
    }
    public override void effect(Monster card)
    {
        base.effect(card);
        card.damage += 2;
    }
    public override void effect(PlayerManager targetPlayer)
    {
        base.effect(targetPlayer);
        targetPlayer.health -= 2;
    }
}
