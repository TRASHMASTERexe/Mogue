using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    private readonly Dictionary<Stat, double> calculatedStats = new()
    {
        { Stat.Atk, 5 },
        { Stat.Def, 3 },
        { Stat.Spd, 100 },
        { Stat.HP, 100 },
        { Stat.MaxHP, 100 },
    };

    private Dictionary<Stat, double> baseStats = new()
    {
        { Stat.Atk, 5 },
        { Stat.Def, 3 },
        { Stat.Spd, 100 },
        { Stat.MaxHP, 100 },
    };

    private Dictionary<Stat, double> constantStats = new()
    {
        { Stat.Exp, 0 },
        { Stat.MaxExp, 10 },
        { Stat.Level, 1 }
    };

    private readonly int maxLvl = 99;
    public int skillPoints = 0;

    public void ApplyItemEffects(List<StatChange> changes)
    {
        CleanStats();

        changes.FindAll(change => change.changeType != ChangeType.Multiply)
            .ForEach(change => {
                UpdateStat(change);
            });
        changes.FindAll(change => change.changeType == ChangeType.Multiply)
            .ForEach(change => {
                UpdateStat(change);
            });

        AdjustStatsToMax();
    }

    internal int GetCalculatedStat(Stat stat)
    {
        return (int)calculatedStats[stat];
    }

    private void CleanStats()
    {
        foreach(Stat stat in baseStats.Keys)
        {
            if (calculatedStats.ContainsKey(stat))
            {
                calculatedStats[stat] = baseStats[stat];
            }
        }
    }

    public void UpdateStat(StatChange change)
    {
        switch(change.changeType)
        {
            case ChangeType.Add:
                calculatedStats[change.stat] += change.changeAmt;
                break;
            case ChangeType.Subtract:
                calculatedStats[change.stat] -= change.changeAmt;
                break;
            case ChangeType.Multiply:
                calculatedStats[change.stat] *= change.changeAmt;
                break;
            case ChangeType.Divide:
                calculatedStats[change.stat] /= change.changeAmt;
                break;
        }
    }

    internal void SetHp(int playerHp)
    {
        calculatedStats[Stat.HP] = playerHp;
    }

    public void rewardExp(int exp)
    {
        constantStats[Stat.Exp] += exp;

        if(constantStats[Stat.Exp] >= constantStats[Stat.MaxExp])
        {
            LevelUp();
        }
    }
    private void AdjustStatsToMax()
    {
        if(calculatedStats[Stat.HP] > calculatedStats[Stat.MaxHP])
        {
            calculatedStats[Stat.HP] = calculatedStats[Stat.MaxHP];
        }

        if(calculatedStats[Stat.Spd] <= 1)
        {
            calculatedStats[Stat.Spd] = 1;
        }
    }

    private void LevelUp()
    {
        if (constantStats[Stat.Level] < maxLvl)
        {
            constantStats[Stat.Exp] -= constantStats[Stat.MaxExp];
            constantStats[Stat.Level] += 1;
            skillPoints++;
            baseStats[Stat.MaxHP] += 20;
            calculatedStats[Stat.MaxHP] = baseStats[Stat.MaxHP];
            calculatedStats[Stat.HP] = baseStats[Stat.MaxHP];

            switch (constantStats[Stat.Level] / 10)
            {
                case 0:
                    constantStats[Stat.MaxExp] += 1;
                    break;
                case 1:
                    constantStats[Stat.MaxExp] += 2;
                    break;
                case 2:
                    constantStats[Stat.MaxExp] += 3;
                    break;
                case 3:
                    constantStats[Stat.MaxExp] += 4;
                    break;
                case 4:
                    constantStats[Stat.MaxExp] += 5;
                    break;
                case 5:
                    constantStats[Stat.MaxExp] += 6;
                    break;
                case 6:
                    constantStats[Stat.MaxExp] += 7;
                    break;
                case 7:
                    constantStats[Stat.MaxExp] += 8;
                    break;
                case 8:
                    constantStats[Stat.MaxExp] += 9;
                    break;
                case 9:
                    constantStats[Stat.MaxExp] += 10;
                    break;

            }
        }
        else
        {
            constantStats[Stat.Exp] = constantStats[Stat.MaxExp];
        }

        //recalc stats
    }
}
