using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anya : Monster
{
    [SerializeField] private GameObject bitch1, bitch2;
    public override void battlecryEffect()
    {
        base.battlecryEffect();
        summon(bitch1,player.playArea);
        //summon(bitch2, player.playArea);
    }
}
