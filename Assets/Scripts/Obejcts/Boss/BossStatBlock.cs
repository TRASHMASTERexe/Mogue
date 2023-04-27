using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatBlock : MonoBehaviour
{

    public Target Target { get; private set; }
    public int BaseAtk { get; private set; }
    public int BaseDef { get; private set; }
    public int BaseSpd { get; private set; }
    public int Atk { get; private set; }
    public int Def { get; private set; }
    public int Spd { get; private set; }
    public int Hp { get; private set; }
    public int Gold { get; private set; }

    public void StatBlockConstructor(Target target, int atk, int def, int spd, int hp, int gold)
    {
        Target = target;
        Atk = atk;
        Spd = spd;
        Def = def;
        Hp = hp;
        Gold = gold;
    }
}
