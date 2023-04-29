using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatBlock : AdversaryStatBlock
{
    public void StatBlockConstructor(int atk, int def, int spd, int hp)
    {
        StatToValue[Stat.Atk] = atk;
        StatToValue[Stat.Spd] = spd;
        StatToValue[Stat.Def] = def;
        StatToValue[Stat.HP] = hp;
    }
}
