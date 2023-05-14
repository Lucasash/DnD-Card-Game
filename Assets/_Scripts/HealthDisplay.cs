using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    public PlayerManager playerManager;
    private GameManager gameManager;
    [SerializeField] TextMeshPro healthText;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    private void Update()
    {
        updateHealth();    
    }

    private void updateHealth()
    {
        if (healthText.text != playerManager.health.ToString())
        {
            healthText.text = playerManager.health.ToString();
        }
    }

    private void OnMouseEnter()
    {
        gameManager.targetPlayer = playerManager;
    }
    private void OnMouseExit()
    {
        gameManager.targetPlayer = null;
    }
    void OnMouseUp() {
        gameManager.selectingCard.select(gameManager.targetPlayer);
    }
}
