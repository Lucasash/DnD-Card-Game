using Kalkatos.DottedArrow;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Monster : Card
{
    public int health, healthBonus, attack, attackBonus, damage;
    private bool attacking;
    protected GameObject attackSprite, healthSprite;
    public bool canAttack;
    protected SpriteRenderer attackAura, stealthAura, barrierAura;
    public bool battlecry, deathrattle, taunt, stealth, summon, barrier, charge, silence;
    public bool barrierHit,stealthy;
    

    public override void Awake()
    {
        base.Awake();
        attackSprite = gameObject.transform.Find("Attack").gameObject;
        healthSprite = gameObject.transform.Find("Health").gameObject;
        attackAura = gameObject.transform.Find("Attack Aura").GetComponentInChildren<SpriteRenderer>();
        stealthAura = gameObject.transform.Find("Stealth Aura").GetComponentInChildren<SpriteRenderer>();
        barrierAura = gameObject.transform.Find("Barrier Aura").GetComponentInChildren<SpriteRenderer>();
    }

    public override void Update()
    {
        base.Update();
        updateSprite(attackSprite,(attack + attackBonus));
        updateSprite(healthSprite,health-damage+healthBonus);
        checkDeath();
        showAttackAura();
        showAura(stealthAura,stealth,stealthy);
        showAura(barrierAura, barrier, barrierHit);
    }
    private void showAura(SpriteRenderer sprite, bool keyword, bool use)
    {
        if (keyword)
        {
            if (use)
            {
                sprite.enabled = true;
            }
            else
            {
                if (sprite.enabled)
                {
                    sprite.enabled = false;
                }
            }
        }
    }

    private void showAttackAura()
    {
        if ((!canAttack && attackAura.enabled) || enemyPlayArea.cardsList.Contains(this))
        {
            attackAura.enabled = false;
        }
        else if (canAttack && !attackAura.enabled)
        {
            attackAura.enabled = true;
        }
    }

    protected void checkDeath()
    {
        if (health+healthBonus-damage <= 0)
        {
            if (deathrattle)
            {
                deathrattleEffect();
            }
            death();
        }
    }
    public virtual void death()
    {
        player.playArea.cardsList.Remove(this);
        player.deck.discardedCards += 1;
        player.playArea.displayCards();
        Destroy(gameObject);
        Debug.Log(cardName + " died");
    }
    public override void showBack(bool trueFalse)
    {
        base.showBack(trueFalse);
        attackSprite.SetActive(!trueFalse);
        healthSprite.SetActive(!trueFalse);
    }
    public override void playCard()
    {
        Debug.Log("Play Card");
        if (playArea.addCard(this))
        {
            gameManager.activePlayer.mana -= manaCost;
            inHand = false;
            hand.cardsList.Remove(this);
            origin = new Vector3();
            if (battlecry)
            {
                battlecryEffect();
            }
            if (charge)
            {
                canAttack = true;
            }
            if (barrier)
            {
                barrierHit = true;
            }
            if (stealth)
            {
                stealthy = true;
            }
            base.playCard();
        }
    }
    public override void ifShowBack()
    {
        if (!(hand.cardsList.Contains(this)) && !(playArea.cardsList.Contains(this)) && !(enemyPlayArea.cardsList.Contains(this)))
        {
            showBack(true);
        }
        else if (back)
        {
            showBack(false);
        }
    }
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        if (playArea.cardsList.Contains(this) && canAttack && !gameManager.selecting)
        {
            arrow.SetupAndActivate(gameObject.transform);
            gameManager.attackingMonster = this;
            attacking = true;
        }
    }

    public override void OnMouseUp()
    {
        if (!(gameManager.selecting))
        {
            Debug.Log("Not Selecting");
            gameManager.attackingMonster = null;
            arrow.Deactivate();
        }
        else
        {
                gameManager.selectingCard.select(this);
            
        }
        base.OnMouseUp();
        ifCombat();
    }
    void ifCombat()
    {
        if ((gameManager.targetMonster != this) && (gameManager.targetMonster != null))
        {
            if (!(gameManager.targetMonster.stealthy) && !(!(gameManager.targetMonster.taunt) && (gameManager.inactivePlayer.playArea.hasTaunt())))
            {
                if (attacking)
                {
                    Debug.Log("Combat");
                    battle(gameManager.targetMonster);
                    canAttack = false;
                }
            }
            else
            {
                Debug.Log("Cant combat because of condition");
                if (gameManager.targetMonster.stealthy)
                {
                    Debug.Log("Can't Attack, Unit is stealth");
                }
                else if (!(!(gameManager.targetMonster.taunt) && (gameManager.inactivePlayer.playArea.hasTaunt())))
                {
                    Debug.Log("Can't Attack, Taunt unit in play");
                }
            }
            attacking = false;
        }
        else if ((gameManager.targetPlayer != null))
        {
            if (!(gameManager.inactivePlayer.playArea.hasTaunt()))
            {
                dealDamage(player.enemyPlayer);
            }
            else
            {
                Debug.Log("Can't Attack, Taunt unit in play");
            }
        }
    }
    public override void OnMouseOver()
    {
        base.OnMouseOver();
        gameManager.targetMonster = this;
    }

    public override void OnMouseExit()
    {
        base.OnMouseExit();
        gameManager.targetMonster = null;
    }
    public virtual void dealDamage(PlayerManager target)
    {
        gameManager.targetPlayer.health -= attack + attackBonus;
        canAttack = false;
    }
    public virtual bool battle(Monster target)
    {
        Debug.Log("Combat " + cardName + " " + target.cardName);
        if (!(target.taunt))
        {
            if (enemyPlayArea.hasTaunt())
            {
                return false;
            }
        }
        return dealDamage(target);
    }
    public virtual bool dealDamage(Monster target)
    {
        if (target.barrierHit)
        {
            target.barrierHit = false;
        }
        else
        {
            target.damage += attack + attackBonus;
        }
        if (barrierHit)
        {
            barrierHit = false;
        }
        else
        {
            damage += target.attack + attackBonus;
        }
        if (stealthy)
        {
            stealthy = false;
        }
        if (target.stealthy)
        {
            target.stealthy = false;
        }
        return true;
    }
    public virtual void battlecryEffect()
    {
        Debug.Log("Default Battlecry");
    }
    public virtual void deathrattleEffect()
    {
        Debug.Log("Default Deathrattle");
    }
}
