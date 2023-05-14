using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atalante : Monster
{
    public override void battlecryEffect()
    {
        base.battlecryEffect();
        gameManager.inactivePlayer.health -= 1;
    }
}
