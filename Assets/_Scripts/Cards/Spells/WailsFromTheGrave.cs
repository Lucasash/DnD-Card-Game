using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WailsFromTheGrave : Spell
{
    public override void playCard()
    {
        if ((checkIfHealth(player.playArea.cardsList,3)) ||(checkIfHealth(player.enemyPlayer.playArea.cardsList, 3)))
        {
            startSelect();
            base.playCard();
        }
    }
    public override void effect(Monster card)
    {
        if (card.health - card.damage + card.healthBonus <= 3)
        {
            card.health = 0;
            base.effect(card);
        }

    }
    bool checkIfHealth(List<Monster> cardList,int health)
    {
        for (int i = 0; i < cardList.Count;i++)
        {
            if (cardList[i].health - cardList[i].damage + cardList[i].healthBonus <= health)
            {
                return true;
            }
        }
        return false;
    }
    public override void effect(PlayerManager targetPlayer)
    {

    }
}
