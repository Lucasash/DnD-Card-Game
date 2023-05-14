using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysticShot : Spell
{
    public override void playCard()
    {
        startSelect();
        base.playCard();
    }
    public override void effect(Monster card)
    {
        base.effect(card);
        card.damage += 1 + player.spellDamageBonus;
    }
    public override void effect(PlayerManager targetPlayer)
    {
        base.effect(targetPlayer);
        targetPlayer.health -= 1 + player.spellDamageBonus;
    }
}
