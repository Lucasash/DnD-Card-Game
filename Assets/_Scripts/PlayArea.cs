using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{
    public List<Monster> cardsList;
    public int maxCards = 7;
    public bool hover;

    public bool addCard(Monster card)
    {
        if (cardsList.Count >= maxCards)
        {
            if (card.inHand)
            {
                card.gameObject.transform.position = card.origin;
            }
            else
            {
                Destroy(card.gameObject);
            }
            return false;
        }
        else
        {
            cardsList.Add(card);
            displayCards();
            return true;
        }
    }

    public void displayCards()
    {
        Vector3 spawn = new Vector3(-5.4f,gameObject.transform.position.y);
        for (int i = 0; i < cardsList.Count;i++)
        {
            cardsList[i].gameObject.transform.position = spawn;
            spawn += new Vector3(1.8f, 0);
        }
    }

    void OnMouseEnter()
    {
        hover = true;
    }

    void OnMouseExit()
    {
        hover = false;
    }
    public bool hasTaunt()
    {
        for (int i = 0; i < cardsList.Count;i++)
        {
            if (cardsList[i].taunt)
            {
                return true;
            }
        }
        return false;
    }
}
