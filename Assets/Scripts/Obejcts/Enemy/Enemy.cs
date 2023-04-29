using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    public Sprite enemyImage;
    public abstract int MinAtk { get; } 
    public abstract int MaxAtk { get; }
    public abstract int MinDef { get; }
    public abstract int MaxDef { get; }
    public abstract int MinSpd { get; }
    public abstract int MaxSpd { get; }
    public abstract int MinHp { get; }
    public abstract int MaxHp { get; }
    public abstract int MinGold { get; }
    public abstract int MaxGold { get;}
    public abstract int DifficultyLevel { get;}

    public EnemyStatBlock initEnemy()
    {
        int atk = Random.Range(MinAtk, MaxAtk);
        int def = Random.Range(MinDef, MaxDef);
        int spd = Random.Range(MinSpd, MaxSpd);
        int hp = Random.Range(MinHp, MaxHp);
        EnemyStatBlock sb = gameObject.AddComponent<EnemyStatBlock>();
        sb.StatBlockConstructor(atk, def, spd, hp);
        return sb;
    }

    public int CalcGold()
    {
        return Random.Range(MinGold, MaxGold);
    }
}
