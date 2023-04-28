using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    private readonly Dictionary<Stat, int> stats = new Dictionary<Stat, int>()
    {
        { Stat.Atk, 5 },
        { Stat.Def, 3 },
        { Stat.Spd, 1 },
        { Stat.HP, 100 },
        { Stat.Exp, 0 },
        { Stat.MaxHP, 100 },
        { Stat.MaxExp, 10 },
        { Stat.Level, 1 }
    };

    private readonly int maxLvl = 99;
    private int curLevel = 1;
    public int skillPoints = 0;

    public ChangeType changeType;

    public PlayerStats UpdateStatsAllItems(List<StatChange> changes, int curLevel, int curExpBase)
    {
        PlayerStats newStats = new();
        newStats.SetCurLevel(curLevel);
        newStats.DetermineMaxExp(curLevel);
        newStats.SetExpBase(curExpBase);

        changes.FindAll(change => change.changeType != ChangeType.Multiply)
            .ForEach(change => {
                newStats.UpdateStat(change);
            });
        changes.FindAll(change => change.changeType == ChangeType.Multiply)
            .ForEach(change => {
                newStats.UpdateStat(change);
            });

        newStats.AdjustStatsToMax();

        return newStats;
    }

    public void UpdateStat(StatChange change)
    {
        switch(change.changeType)
        {
            case ChangeType.Add:
                stats[change.stat] += change.changeAmt;
                break;
            case ChangeType.Subtract:
                stats[change.stat] -= change.changeAmt;
                break;
            case ChangeType.Multiply:
                stats[change.stat] *= change.changeAmt;
                break;
        }
    }

    private void SetExpBase(int curExpBase)
    {
        stats[Stat.Exp] = curExpBase;
    }

    private void SetCurLevel(int curLevel)
    {
        stats[Stat.Level] = curLevel;
    }

    private void DetermineMaxExp(int curLevel)
    {
        for(int i = 9; i >= 0; i--)
        {
            int v = i * 10;
            if (curLevel > v)
            {
                stats[Stat.MaxExp] += (i+1 * (curLevel - (v)));
                curLevel = v;
            }
        }
    }


    public void AdjustStatsToMax()
    {
        if(stats[Stat.HP] > stats[Stat.MaxHP])
        {
            stats[Stat.HP] = stats[Stat.MaxHP];
        }
        else if (stats[Stat.HP] < 1)
        {
            stats[Stat.HP] = 1;
        }

        while (stats[Stat.Exp] > stats[Stat.MaxExp])
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        if (curLevel < maxLvl)
        {
            stats[Stat.Exp] -= stats[Stat.MaxExp];
            stats[Stat.Level] += 1;
            skillPoints++;
            curLevel++;

            switch (curLevel / 10)
            {
                case 0:
                    stats[Stat.MaxExp] += 1;
                    break;
                case 1:
                    stats[Stat.MaxExp] += 2;
                    break;
                case 2:
                    stats[Stat.MaxExp] += 3;
                    break;
                case 3:
                    stats[Stat.MaxExp] += 4;
                    break;
                case 4:
                    stats[Stat.MaxExp] += 5;
                    break;
                case 5:
                    stats[Stat.MaxExp] += 6;
                    break;
                case 6:
                    stats[Stat.MaxExp] += 7;
                    break;
                case 7:
                    stats[Stat.MaxExp] += 8;
                    break;
                case 8:
                    stats[Stat.MaxExp] += 9;
                    break;
                case 9:
                    stats[Stat.MaxExp] += 10;
                    break;

            }
        }
        stats[Stat.Exp] = stats[Stat.MaxExp];
    }
}
