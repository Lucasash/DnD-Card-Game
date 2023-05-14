using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElesisBolt : Spell
{
    public override void playCard()
    {
        startSelect();
        base.playCard();
    }
    public override void effect(Monster card)
    {
        base.effect(card);
        card.damage += 2;
    }
    public override void effect(PlayerManager targetPlayer)
    {
        base.effect(targetPlayer);
        targetPlayer.health -= 2 + player.spellDamageBonus;
    }
}
