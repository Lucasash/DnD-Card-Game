using Kalkatos.DottedArrow;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    public string cardName;
    public int manaCost;

    [HideInInspector] public bool back;
    [HideInInspector] public TextMeshPro keywords;
    protected GameObject backSprite, manaSprite;
    protected GameObject prefab;

    [HideInInspector] public bool inHand = true;
    private bool hovering, dragging;
    private float hoverRaise = 1.25f;
    [HideInInspector] public Vector3 origin;

    protected PlayArea playArea,enemyPlayArea;
    protected Hand hand,enemyHand;
    protected GameManager gameManager;
    public PlayerManager player;
    protected Arrow arrow;



    public virtual void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        playArea = GameObject.FindGameObjectWithTag("FriendlyPlayArea").GetComponent<PlayArea>();
        enemyPlayArea = GameObject.FindGameObjectWithTag("EnemyPlayArea").GetComponent<PlayArea>();
        hand = GameObject.FindGameObjectWithTag("FriendlyHand").GetComponent<Hand>();
        enemyHand = GameObject.FindGameObjectWithTag("EnemyHand").GetComponent<Hand>();
        arrow = GameObject.FindGameObjectWithTag("Arrow").GetComponent<Arrow>();
        keywords = gameObject.transform.Find("Text").GetComponentInChildren<TextMeshPro>();
        manaSprite = gameObject.transform.Find("Mana").gameObject;
        backSprite = gameObject.transform.Find("Card Back").gameObject;
        gameObject.name = cardName;
    }
    public virtual void Update()
    {
        drag();
        ifShowBack();
        updateSprite(manaSprite,manaCost);
    }
    protected void updateSprite(GameObject sprite, int value)
    {
        if (sprite.GetComponentInChildren<TextMeshPro>().text != value.ToString())
        {
            sprite.GetComponentInChildren<TextMeshPro>().text = value.ToString();
        }
    }
    protected void drag()
    {
        if (dragging)
        {
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
        }
    }
    public virtual void ifShowBack()
    {
        if (gameManager.inactivePlayer.hand.cardsList.Contains(this))
        {
            showBack(true);
        }
        else if (back)
        {
            showBack(false);
        }
    }
    public virtual void showBack(bool trueFalse)
    {
        back = trueFalse;
        backSprite.SetActive(trueFalse);
    }
    public virtual void playCard()
    {
        player.hand.displayCards();
    }
    protected bool canBeUsed()
    {
        return true;
    }
    public virtual void OnMouseOver()
    {
        if (inHand && !(back))
        {
            if (!hovering)
            {
                origin = gameObject.transform.position;
                gameObject.transform.localScale = new Vector3(1.2f, 1.2f);
                gameObject.transform.position += new Vector3(0, hoverRaise);
                hovering = true;
            }
        }
    }
    public virtual void OnMouseExit()
    {
        if (inHand && !(back))
        {
            gameObject.transform.localScale = new Vector3(1f, 1f);
            gameObject.transform.position = origin;
            hovering = false;
        }
    }
    public virtual void OnMouseDown()
    {
        if (hovering && !back && inHand)
        {
            dragging = true;
            if (player.currentTurn)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                playArea.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
    public virtual void OnMouseUp()
    {
        if (dragging && !(back))
        {
            dragging = false;
            if (playArea.hover && enoughMana(gameManager.activePlayer.mana, manaCost, gameManager.activePlayer.storedMana))
            {
                    playCard();
            }
            else
            {
                gameObject.transform.position = origin;
            }
            if (player.currentTurn)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                playArea.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
    public virtual bool enoughMana(int mana, int manaCost, int storedMana)
    {
        if (mana >= manaCost)
        {
            return true;
        }
        return false;

    }
    public virtual void summon(GameObject monster,PlayArea summonPlayArea)
    {
        if (summonPlayArea.cardsList.Count <= summonPlayArea.maxCards)
        {
            Monster card = Instantiate(monster).GetComponent<Monster>();
            summonPlayArea.addCard(card);
            card.player = player;
        }
    }

    public virtual void startSelect()
    {
        arrow.SetupAndActivate(gameObject.transform);
        gameManager.selecting = true;
        gameManager.selectingCard = this;
    }

    public virtual void select(Monster card)
    {
        effect(card);
    }
    public virtual void select(PlayerManager targetPlayer)
    {
        effect(targetPlayer);
    }
    public virtual void effect(Monster card)
    {
        gameManager.selecting = false;
        gameManager.selectingCard = null;
        arrow.Deactivate();
    }
    public virtual void effect(PlayerManager targetPlayer)
    {
        gameManager.selecting = false;
        gameManager.selectingCard = null;
        arrow.Deactivate();
    }
}
