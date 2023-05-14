using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arachne : Monster
{
    [SerializeField] private GameObject echo;
    public override void battlecryEffect()
    {
        summon(echo, player.playArea);
    }
}
