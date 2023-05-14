using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Madessa : Monster
{
    [SerializeField] private GameObject kani;

    public override void battlecryEffect()
    {
        base.battlecryEffect();
        summon(kani,player.playArea);
    }
}
