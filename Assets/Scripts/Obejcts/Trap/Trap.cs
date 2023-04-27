using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{

    public Sprite TrapImage;
    public abstract int MinDmg { get; }
    public abstract int MaxDmg { get; }
    public abstract int MinSpd { get; }
    public abstract int MaxSpd { get; }
    public abstract int MinGold { get; }
    public abstract int MaxGold { get; }
    public abstract List<Rarity> LootRarities { get; }
    public abstract int DifficultyLevel { get; }

    public TrapStatBlock initTrap()
    {
        int dmg = Random.Range(MinDmg, MaxDmg);
        int spd = Random.Range(MinSpd, MaxSpd);
        int gold = Random.Range(MinGold, MaxGold);
        TrapStatBlock sb = gameObject.AddComponent<TrapStatBlock>();
        sb.StatBlockConstructor(Target.Enemy, dmg, spd, gold);
        return sb;
    }

    public void OnClick()
    {

    }
}
