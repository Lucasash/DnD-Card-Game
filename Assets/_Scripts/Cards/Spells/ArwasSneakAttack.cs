using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArwasSneakAttack : Spell
{
    public override void playCard()
    {
        base.playCard();
        player.enemyPlayer.health -= 4 + player.spellDamageBonus;
    }
}
