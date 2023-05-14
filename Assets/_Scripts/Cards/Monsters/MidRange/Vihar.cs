using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vihar : Monster
{
    public override void battlecryEffect()
    {
        base.battlecryEffect();
        for (int i = 0; i < gameManager.inactivePlayer.playArea.cardsList.Count;i++)
        {
            gameManager.inactivePlayer.playArea.cardsList[i].damage += 1;
        }
    }
}
