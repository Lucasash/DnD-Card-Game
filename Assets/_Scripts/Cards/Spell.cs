using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : Card
{
    public override void playCard()
    {
        base.playCard();
        Debug.Log("Cast spell");
        inHand = false;
        if (manaCost - gameManager.activePlayer.storedMana < 0)
        {
            gameManager.activePlayer.storedMana -= manaCost;
        }
        else
        {
            gameManager.activePlayer.mana -= (manaCost - gameManager.activePlayer.storedMana);
            gameManager.activePlayer.storedMana = 0;
        }
        spellRefund();
        destroy();
    }
    void spellRefund()
    {
        if (manaCost > 0)
        {
            if (manaCost < player.spellRefund)
            {
                player.mana += player.spellRefund;
            }
            else
            {
                player.mana += player.spellRefund;
            }
        }
    }
    public override void startSelect()
    {
        arrow.SetupAndActivate(player.healthDisplay.gameObject.transform);
        gameManager.selecting = true;
        gameManager.selectingCard = this;
    }
    public virtual void destroy()
    {
        player.deck.discardedCards += 1;
        player.hand.cardsList.Remove(this);
        Destroy(this.gameObject);
    }
    public override bool enoughMana(int mana, int manaCost, int storedMana)
    {
        if (mana + storedMana >= manaCost)
        {
            return true;
        }
        return false;
    }
}
