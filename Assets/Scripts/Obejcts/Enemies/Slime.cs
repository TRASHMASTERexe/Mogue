using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slime : Enemy
{
    public override int MinAtk { get;} = 1;
    public override int MaxAtk { get;} = 3;
    public override int MinDef { get;} = 1;
    public override int MaxDef { get;} = 2;
    public override int MinSpd { get;} = 1;
    public override int MaxSpd { get;} = 1;
    public override int MinHp { get;} = 3;
    public override int MaxHp { get;} = 5;
    public override int MinGold { get;} = 1;
    public override int MaxGold { get;} = 5;
    public override int DifficultyLevel { get;} = 1;
    public override Image enemyImage { get; }

}
