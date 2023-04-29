using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Boss : MonoBehaviour
{
    public Sprite bossImage;
    public abstract int Atk { get; }
    public abstract int Def { get; }
    public abstract int Spd { get; }
    public abstract int Hp { get; }
    public abstract int Gold { get; }
    public abstract int DifficultyLevel { get; }

    public BossStatBlock initBoss()
    {
        BossStatBlock sb = gameObject.AddComponent<BossStatBlock>();
        sb.StatBlockConstructor(Atk, Def, Spd, Hp);
        return sb;
    }
}
