using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject manaCard;
    public Vector3 friendlyDeckSpawn, enemyDeckSpawn;
    public Hand friendlyHand, enemyHand;
    private Deck friendlyDeck, enemyDeck;
    private PlayArea friendlyPlayArea, enemyPlayArea;
    public PlayerManager playerManager1, playerManager2, activePlayer,inactivePlayer;

    public Monster attackingMonster,targetMonster;
    public PlayerManager targetPlayer;
    [SerializeField] private int startingCardDraw;

    public Image crystal1, crystal2, crystal3, crystal4, crystal5, crystal6;
    [SerializeField] private HealthDisplay friendlyHealth, enemyHealth;

    public bool selecting;
    public Card selectingCard;

    private void Awake()
    {
        friendlyDeck = GameObject.FindGameObjectWithTag("FriendlyDeck").GetComponent<Deck>();
        enemyDeck = GameObject.FindGameObjectWithTag("EnemyDeck").GetComponent<Deck>();
        friendlyPlayArea = GameObject.FindGameObjectWithTag("FriendlyPlayArea").GetComponent<PlayArea>();
        enemyPlayArea = GameObject.FindGameObjectWithTag("EnemyPlayArea").GetComponent<PlayArea>();
        friendlyDeck.transform.position = friendlyDeckSpawn;
        friendlyDeck.assignDiscardPile(true);
        enemyDeck.transform.position = enemyDeckSpawn;
        enemyDeck.assignDiscardPile(false);
        playerManager1.deck = friendlyDeck;
        playerManager2.deck = enemyDeck;
    }
    void Start()
    {
        activePlayer = playerManager1;
        drawStartingHand();
        drawStartingHand();
        inactivePlayer.hand.addCard(Instantiate(manaCard).GetComponent<Card>());
        activePlayer.startTurn();
    }
    private void drawStartingHand()
    {
        for (int i = 0; i < startingCardDraw; i++)
        {
            activePlayer.deck.drawCard(activePlayer.hand,activePlayer);
        }
        switchSides();
    }
    public void nextTurn()
    {
        activePlayer.endTurn();
        switchSides();
        activePlayer.startTurn();
        for (int i = 0; i < friendlyPlayArea.cardsList.Count; i++)
        {
            activePlayer.playArea.cardsList[i].canAttack = true;
        }
    }
    public void switchSides()
    {
        Hand tempHand = new Hand();
        Deck tempDeck = new Deck();
        PlayArea tempPlayArea = new PlayArea();
        PlayerManager tempPlayerManager = new PlayerManager();

        //Hand
        tempHand.cardsList = friendlyHand.cardsList;
        friendlyHand.cardsList = enemyHand.cardsList;
        enemyHand.cardsList = tempHand.cardsList;

        tempPlayerManager.hand = playerManager1.hand;
        playerManager1.hand = playerManager2.hand;
        playerManager2.hand = tempPlayerManager.hand;

        friendlyHand.displayCards();
        enemyHand.displayCards();

        //Play Area
        tempPlayArea.cardsList = friendlyPlayArea.cardsList;
        friendlyPlayArea.cardsList = enemyPlayArea.cardsList;
        enemyPlayArea.cardsList = tempPlayArea.cardsList;

        tempPlayerManager.playArea = playerManager1.playArea;
        playerManager1.playArea = playerManager2.playArea;
        playerManager2.playArea = tempPlayerManager.playArea;

        friendlyPlayArea.displayCards();
        enemyPlayArea.displayCards();

        //Deck
        tempDeck.discardedCards = friendlyDeck.discardedCards;
        friendlyDeck.discardedCards = enemyDeck.discardedCards;
        enemyDeck.discardedCards = tempDeck.discardedCards;

        tempDeck.deckList = friendlyDeck.deckList;
        friendlyDeck.deckList = enemyDeck.deckList;
        enemyDeck.deckList = tempDeck.deckList;

        tempPlayerManager.deck = playerManager1.deck;
        playerManager1.deck = playerManager2.deck;
        playerManager2.deck = tempPlayerManager.deck;

        //Health Display
        if (activePlayer == playerManager1)
        {
            activePlayer = playerManager2;
            inactivePlayer = playerManager1;
        }
        else
        {
            activePlayer = playerManager1;
            inactivePlayer = playerManager2;
        }
        activePlayer.healthDisplay = friendlyHealth;
        inactivePlayer.healthDisplay = enemyHealth;
        /*
        tempHand.cardsList = friendlyHand.cardsList;
        tempPlayArea.cardsList = friendlyPlayArea.cardsList;
        tempDeck.deckList = friendlyDeck.deckList;
        tempPlayerManager = friendlyPlayerManager;

        friendlyHand.cardsList = enemyHand.cardsList;
        friendlyHand.displayCards();
        friendlyPlayArea.cardsList = enemyPlayArea.cardsList;
        friendlyPlayArea.displayCards();
        friendlyDeck.deckList = enemyDeck.deckList;
        friendlyPlayerManager = enemyPlayerManager;

        enemyHand.cardsList = tempHand.cardsList;
        enemyHand.displayCards();
        enemyPlayArea.cardsList = tempPlayArea.cardsList;
        enemyPlayArea.displayCards();
        enemyDeck.deckList = tempDeck.deckList;
        enemyPlayerManager = tempPlayerManager;
        */
        activePlayer.manaCrystal1 = crystal1;
        activePlayer.manaCrystal2 = crystal2;
        activePlayer.manaCrystal3 = crystal3;
        inactivePlayer.manaCrystal1 = crystal4;
        inactivePlayer.manaCrystal2 = crystal5;
        inactivePlayer.manaCrystal3 = crystal6;
    }
}
