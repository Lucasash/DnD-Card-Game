using System.Collections.Generic;
using UnityEngine;

public class AnnesMagicMissile : Spell
{
    public override void playCard()
    {
        base.playCard();
        for (int i= 0; i < (3+player.spellDamageBonus);i++)
        {
            if (damageRandomEnemy()) {
                i -= 1;
            }
        }
    }

    private bool damageRandomEnemy()
    {
        int rand = Random.Range(0, player.enemyPlayer.playArea.cardsList.Count+1);
        if (rand == player.enemyPlayer.playArea.cardsList.Count)
        {
            player.enemyPlayer.health -= 1;
        }
        else
        {
            Monster card = player.enemyPlayer.playArea.cardsList[rand];
            if (card.health - card.damage <= 0)
            {
                return true;
            }
            card.damage += 1;
        }
        return false;
    }
}
