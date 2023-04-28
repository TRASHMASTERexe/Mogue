using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatBlock : BaseStatBlock
{
    public void StatBlockConstructor(int atk, int def, int spd, int hp, int gold)
    {
        Atk = atk;
        Spd = spd;
        Def = def;
        Hp = hp;
        Gold = gold;
    }
}
