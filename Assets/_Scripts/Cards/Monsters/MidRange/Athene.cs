using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Athene : Monster
{
    public override void battlecryEffect()
    {
        base.battlecryEffect();
        for (int i = 0; i < player.playArea.cardsList.Count; i++)
        {
            player.playArea.cardsList[i].attackBonus += 1;
        }
        //attackBonus -= 1;
    }
}
