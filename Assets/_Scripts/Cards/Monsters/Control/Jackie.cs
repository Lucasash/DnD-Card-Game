using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jackie : Monster
{
    public override void death()
    {
        base.death();
        player.spellRefund -= 1;
    }

    public override void playCard()
    {
        base.playCard();
        player.spellRefund += 1;
    }
}
