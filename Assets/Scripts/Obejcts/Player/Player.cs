using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    public Sprite playerImage;
    public PlayerStats PlayerStatBlock = new();
    private Dictionary<Item, int> itemsToCount = new();

    internal void GiveItem(Item prize)
    {
        if(itemsToCount.ContainsKey(prize))
        {
            itemsToCount[prize]++;
        }
        else
        {
            itemsToCount.Add(prize, 1);
        }

        List<StatChange> changes = new List<StatChange>();
        //get player changes
        itemsToCount.Where(entry => entry.Key.Target.Equals(Target.Player))
            .Select(e => new { e.Key.statChanges, e.Value }).ToList().ForEach(e =>
            {
                for(int i = 0; i < e.Value; i++)
                {
                    changes.AddRange(e.statChanges);
                }
            });


        PlayerStatBlock.ApplyItemEffects(changes);

        //TODO apply changes to all other targets
    }

    internal void Fight(AdversaryStatBlock statBlock)
    {

        int enemyAtk = statBlock.StatToValue[Stat.Atk];
        int enemyDef = statBlock.StatToValue[Stat.Def];
        int enemySpd = 1000 / statBlock.StatToValue[Stat.Spd];
        int enemyHp = statBlock.StatToValue[Stat.HP];

        int playerAtk = PlayerStatBlock.GetStat(Stat.Atk);
        int playerDef = PlayerStatBlock.GetStat(Stat.Def);
        int playerSpd = 1000 / PlayerStatBlock.GetStat(Stat.Spd);
        int playerHp = PlayerStatBlock.GetStat(Stat.HP);

        //combat
        bool bothAlive = true;
        int turnNum = 1;

        while (bothAlive){ 
            if(turnNum % playerSpd == 0)
            {
                int damageCalc = playerAtk - enemyDef >= 0 ? playerAtk - enemyDef : 0;
                enemyHp -= damageCalc;
            }

            if(enemyHp <= 0)
            {
                bothAlive = false;
                continue;
            }

            if (turnNum % enemySpd == 0)
            {
                int damageCalc = enemyAtk - playerDef >= 0 ? enemyAtk - playerDef : 0;
                playerHp -= damageCalc;
            }

            if (playerHp <= 0)
            {
                bothAlive = false;
                continue;
            }

            turnNum++;
        };

        PlayerStatBlock.SetHp(playerHp);
    }

    internal void Evade(TrapStatBlock statBlock)
    {
       if(statBlock.StatToValue[Stat.Spd] > PlayerStatBlock.GetStat(Stat.Spd))
        {
            PlayerStatBlock.SetHp(PlayerStatBlock.GetStat(Stat.HP) - statBlock.StatToValue[Stat.Atk]);
        }
    }

    public void UpdateUI()
    {

    }
}
