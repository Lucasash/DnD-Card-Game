using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruka : Monster
{
    public override void death()
    {
        base.death();
        player.spellDamageBonus -= 1;
    }

    public override void playCard()
    {
        base.playCard();
        player.spellDamageBonus += 1;
    }
}
