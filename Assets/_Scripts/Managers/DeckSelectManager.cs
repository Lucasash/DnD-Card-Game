using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeckSelectManager : MonoBehaviour
{
    public TextMeshProUGUI fText, eText;
    public GameObject fDeck, eDeck;
    public List<GameObject> friendlyList, enemyList;
    private void Awake()
    {
        DeckSelectManager manager = GameObject.FindGameObjectWithTag("Deck Select Manager").GetComponent<DeckSelectManager>();
    }
    public void aggro(bool friendly){
       if (friendly)
        {
            fDeck=friendlyList[0];
            fText.text = "Player 1: Aggro";
        }
        else
        {
            eDeck=enemyList[0];
            eText.text = "Player 2: Aggro";
        }
    }
    public void midRange(bool friendly)
    {
        if (friendly)
        {
            fDeck = friendlyList[1];
            fText.text = "Player 1: Midrange";
        }
        else
        {
            eDeck = enemyList[1];
            eText.text = "Player 2: Midrange";
        }
    }
    public void control(bool friendly)
    {
        if (friendly)
        {
            fDeck = friendlyList[2];
            fText.text = "Player 1: Control";
        }
        else
        {
            eDeck = enemyList[2];
            eText.text = "Player 2: Control";
        }
    }
    public void startGame()
    {
        GameObject friendlyDeck = spawnDeck(fDeck, "FriendlyDeck");
        GameObject enemyDeck = spawnDeck(eDeck, "EnemyDeck");
        SceneManager.LoadScene("GameBoard");
    }
    GameObject spawnDeck(GameObject deckPrefab, string deckTag)
    {
        GameObject deck = Instantiate(deckPrefab);
        deck.tag = deckTag;
        return deck;
    }
}
