using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kasha : Monster
{
    [SerializeField] private GameObject mrNibbles;
    public override void battlecryEffect()
    {
        summon(mrNibbles,player.playArea);
    }
}
