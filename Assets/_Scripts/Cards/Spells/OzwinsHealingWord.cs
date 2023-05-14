using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OzwinsHealingWord : Spell
{
    public override void playCard()
    {
        base.playCard();
        for (int i = 0; i < player.playArea.cardsList.Count;i++)
        {
            player.playArea.cardsList[i].attack += 1;
            player.playArea.cardsList[i].health += 1;
        }
    }
}
