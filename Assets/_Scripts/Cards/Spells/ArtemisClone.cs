using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtemisClone : Spell
{
    public override void playCard()
    {
        GameObject card = player.deck.drawCard(player.hand, player);
        player.hand.addCard(Instantiate(card).GetComponent<Card>());
        base.playCard();
    }
    
}
