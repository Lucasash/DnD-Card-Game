using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Deck : MonoBehaviour
{
    public List<GameObject> deckList;
    public int discardedCards = 0;

    [SerializeField] private TextMeshPro numCards;
    private TextMeshProUGUI numDiscard;

    public void assignDiscardPile(bool friendly)
    {
        if (friendly)
        {
            numDiscard = GameObject.FindGameObjectWithTag("FriendlyDiscardPile").transform.Find("CountText").GetComponent<TextMeshProUGUI>();
        }
        else
        {
            numDiscard = GameObject.FindGameObjectWithTag("EnemyDiscardPile").transform.Find("CountText").GetComponent<TextMeshProUGUI>();
        }
    }
    private void Update()
    {
        updateDeckCount();
        updateDiscardCount();
    }

    private void updateDiscardCount()
    {
        if (numDiscard.text != discardedCards.ToString())
        {
            numDiscard.text = discardedCards.ToString();
        }
    }

    private void updateDeckCount()
    {
        if (numCards.text != deckList.Count.ToString())
        {
            numCards.text = deckList.Count.ToString();
        }
    }

    public GameObject drawCard(Hand hand, PlayerManager player)
    {
        if (deckList.Count != 0 && hand.cardsList.Count <= hand.maxCards)
        {
            int rand = Random.Range(0, deckList.Count);
            GameObject card = Instantiate(deckList[rand]);
            deckList.RemoveAt(rand);
            card.GetComponent<Card>().player = player;
            hand.addCard(card.GetComponent<Card>());
            return card;
        }
        else
        {
            Debug.Log("Deck Empty or Hand Full");
            return null;
        }
    }
    public List<GameObject> getListSpells()
    {
        List<GameObject> output = new List<GameObject>();
        for (int i = 0; i < deckList.Count;i++)
        {
            if (deckList[i].GetComponent<Card>() is Spell)
            {
                output.Add(deckList[i]);
            }
        }
        return output;
    }
}
