using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerysIounStone : Spell
{
    public override void playCard()
    {
        base.playCard();
        player.maxMana += 1;
    }
}
