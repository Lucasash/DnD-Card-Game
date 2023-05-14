using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onram : Monster
{
    [SerializeField] private GameObject tree;
    public override void battlecryEffect()
    {
        base.battlecryEffect();
        summon(tree,player.playArea);
    }
}
