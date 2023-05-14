using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artemis : Monster
{
    public override void battlecryEffect()
    {
        base.battlecryEffect();
        searchForRandomSpell();
    }
    void searchForRandomSpell()
    {
        List<GameObject> spells= player.deck.getListSpells();
        if (spells.Count > 0)
        {
            int rand = Random.Range(0, spells.Count);
            GameObject card = Instantiate(spells[rand]);
            player.deck.deckList.Remove(spells[rand]);
            card.GetComponent<Spell>().player = player;
            hand.addCard(card.GetComponent<Spell>());
            Debug.Log("Added " + card.GetComponent<Card>().cardName + " to hand");
        }
        else
        {
            Debug.Log("No spells in deck");
        }
    }
}
