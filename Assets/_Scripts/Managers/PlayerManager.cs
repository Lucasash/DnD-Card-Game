using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int mana, maxMana,storedMana,health,startingHealth;
    public Image manaCrystal1, manaCrystal2, manaCrystal3;
    public List<GameObject> deckList;

    public HealthDisplay healthDisplay;
    public TextMeshProUGUI manaText;
    public PlayArea playArea;
    public Hand hand;
    public Deck deck;
    public PlayerManager enemyPlayer;

    public bool currentTurn;

    public int spellDamageBonus, spellRefund;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    void Start()
    {
        health = startingHealth;
        deckList = deck.deckList;
    }
    private void Update()
    {
        updateHealthDisplay();
        updateManaCrystals();
        updateManaText();
    }
    public void startTurn()
    {
        Debug.Log("Start Turn");
        maxMana += 1;
        mana = maxMana;
        currentTurn = true;
        deck.drawCard(hand,this);
    }
    public void endTurn()
    {
        if ((mana > 0)&&(storedMana <= 3)) 
        {
            storedMana += mana;
            if (storedMana > 3)
            {
                storedMana = 3;
            }
        }
        mana = 0;
        currentTurn = false;
    }
    void updateHealthDisplay()
    {
        if (healthDisplay.playerManager != this)
        {
            healthDisplay.playerManager = this;
        }
    }
    void updateManaCrystals()
    {
        if (storedMana < 3)
        {
            manaCrystal3.color = Color.gray;
        }
        else
        {
            manaCrystal3.color = Color.white;
        }
        if (storedMana < 2)
        {
            manaCrystal2.color = Color.gray;
        }
        else
        {
            manaCrystal2.color = Color.white;
        }
        if (storedMana < 1)
        {
            manaCrystal1.color = Color.gray;
        }
        else
        {
            manaCrystal1.color = Color.white;
        }
    }
    void updateManaText()
    {
        if (manaText.text != mana.ToString() && currentTurn)
        {
            manaText.text = mana.ToString() + "/" + maxMana.ToString();
        }
    }
}
