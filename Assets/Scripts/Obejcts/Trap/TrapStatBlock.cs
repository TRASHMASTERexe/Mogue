using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapStatBlock : BaseStatBlock
{

    public void StatBlockConstructor(int atk, int spd, int gold)
    {
        Atk = atk;
        Spd = spd;
        Gold = gold;
    }
}
