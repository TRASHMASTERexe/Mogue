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
        int atk = Random.Range(MinAtk, MaxAtk+1);
        int def = Random.Range(MinDef, MaxDef+1);
        int spd = Random.Range(MinSpd, MaxSpd+1);
        int hp = Random.Range(MinHp, MaxHp+1);
        EnemyStatBlock sb = gameObject.AddComponent<EnemyStatBlock>();
        sb.StatBlockConstructor(atk, def, spd, hp);
        return sb;
    }

    public int CalcGold()
    {
        return Random.Range(MinGold, MaxGold);
    }
}
