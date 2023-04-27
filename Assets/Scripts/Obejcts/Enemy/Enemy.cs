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
        int gold = Random.Range(MinGold, MaxGold);
        EnemyStatBlock sb = gameObject.AddComponent<EnemyStatBlock>();
        sb.StatBlockConstructor(Target.Enemy, atk, def, spd, hp, gold);
        return sb;
    }

    public void OnClick()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
