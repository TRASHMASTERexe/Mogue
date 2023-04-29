using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapStatBlock : AdversaryStatBlock
{

    public void StatBlockConstructor(int atk, int spd)
    {
        StatToValue[Stat.Atk] = atk;
        StatToValue[Stat.Spd] = spd;
    }
}
