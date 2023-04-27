using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonKing : Boss
{
    public override int Atk { get;} = 7;
    public override int Def { get;} = 3;
    public override int Spd { get;} = 3;
    public override int Hp { get;} = 25;
    public override int Gold { get;} = 5;
    public override int DifficultyLevel { get;} = 1;

}
