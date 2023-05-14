using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hand : MonoBehaviour
{
    public List<Card> cardsList;
    public int maxCards = 8;
    public PlayerManager playerManager;
    private void Awake()
    {
        //gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    public void addCard(Card card)
    {
        cardsList.Add(card);
        card.inHand = true;
        displayCards();
    }

    public void displayCards()
    {
        Vector3 spawn = new Vector3(-6.4f, gameObject.transform.position.y);
        //Vector3 spawn = new Vector3(-5.4f, -1.7f);
        for (int i = 0; i < cardsList.Count; i++)
        {
            cardsList[i].gameObject.transform.position = spawn;
            spawn += new Vector3(1.6f, 0);
        }
    }
    public void returnCardToHand(Monster card)
    {
        addCard(card);
        card.player.playArea.cardsList.Remove(card);
        card.canAttack = false;
        card.attackBonus = 0;
        card.healthBonus = 0;
        card.damage = 0;
    }
}
