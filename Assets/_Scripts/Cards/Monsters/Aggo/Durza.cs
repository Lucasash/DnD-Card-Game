using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Durza : Monster
{
    public override void death()
    {
        player.playArea.cardsList.Remove(this);
        player.playArea.displayCards();
        damage = 0;
        attackBonus = 0;
        healthBonus = 0;
    }
    public override void deathrattleEffect()
    {
        base.deathrattleEffect();
        Debug.Log("Durza Deathrattle");
        player.hand.returnCardToHand(this);
    }
}
