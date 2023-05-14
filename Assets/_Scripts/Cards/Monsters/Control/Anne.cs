using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anne : Monster
{
    public override void deathrattleEffect()
    {
        base.battlecryEffect();
        searchFerbs(player.deck);
    }

    bool searchFerbs(Deck deck)
    {
        for (int i = 0; i < deck.deckList.Count;i++)
        {
            if (player.deck.deckList[i].GetComponent<Ferbs>().cardName == "Ferbs")
            {
                Card card = Instantiate(player.deck.deckList[i]).GetComponent<Card>();
                player.hand.addCard(card);
                card.GetComponent<Card>().player = player;
                player.deck.deckList.RemoveAt(i);
                return true;
            }
        }
        return false;
    }
}
