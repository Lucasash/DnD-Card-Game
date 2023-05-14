using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ferbs : Monster
{
    public override void battlecryEffect()
    {
        Debug.Log("Ferbs Battlecry");
        if (playArea.cardsList.Contains(this))
        {
            gameManager.inactivePlayer.health -= player.deck.discardedCards;
        }
    }
}
