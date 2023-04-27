using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapStatBlock : MonoBehaviour
{

    public Target Target { get; private set; }
    public int BaseDmg { get; private set; }
    public int BaseSpd { get; private set; }
    public int Dmg { get; private set; }
    public int Spd { get; private set; }
    public int Gold { get; private set; }

    public void StatBlockConstructor(Target target, int dmg, int spd, int gold)
    {
        Target = target;
        Dmg = dmg;
        Spd = spd;
        Gold = gold;
    }
}
