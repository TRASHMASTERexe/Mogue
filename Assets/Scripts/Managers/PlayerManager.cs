using System.Linq;  
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerManager : MonoBehaviour
{

    //public List<EnemyInfo> prefabs;
    public GameObject statBar;
    public GameObject headerBar;
    private Player player;
    private int killCount = 0;
    private int difficulty = 1;
    private int gold = 0;

    public bool StartCombat(AdversaryStatBlock statBlock)
    {
        if(statBlock is TrapStatBlock)
        {
            return false;
        }

        player.Fight(statBlock);

        PlayerStats ps = player.PlayerStatBlock;

        if (ps.GetStat(Stat.HP) <= 0)
        {
            return false;
        }

        killCount++;
        if (killCount % 10 == 0)
        {
            difficulty++;
        }

        ps.rewardExp(1);

        return true;
    }

    internal void GivePlayer(Item prize)
    {
        GivePlayer(prize, 0);
    }

    internal void GivePlayer(Item prize, int gold)
    {
        this.gold += gold;
        player.GiveItem(prize);
        UpdateUI();
    }

    private void UpdateUI()
    {
        List<TMP_Text> texts = statBar.GetComponentsInChildren<TMP_Text>().ToList();
        texts.AddRange(headerBar.GetComponentsInChildren<TMP_Text>());

        PlayerStats ps = player.PlayerStatBlock;

        texts.Where(t => t.name.ToLower().StartsWith("atktext")).FirstOrDefault().text = ps.GetStat(Stat.Atk).ToString();
        texts.Where(t => t.name.ToLower().StartsWith("deftext")).FirstOrDefault().text = ps.GetStat(Stat.Def).ToString();
        texts.Where(t => t.name.ToLower().StartsWith("spdtext")).FirstOrDefault().text = ps.GetStat(Stat.Spd).ToString();
        texts.Where(t => t.name.ToLower().StartsWith("goldtext")).FirstOrDefault().text = gold.ToString();
        texts.Where(t => t.name.ToLower().StartsWith("difficultytext")).FirstOrDefault().text = difficulty.ToString();

        List<Slider> bars = statBar.GetComponentsInChildren<Slider>().ToList();
        Slider hpBar = bars.Where(b => b.name.ToLower().Equals("hpbar")).FirstOrDefault();
        hpBar.maxValue = ps.GetStat(Stat.MaxHP);
        hpBar.value = ps.GetStat(Stat.HP);
        texts.Where(t => t.name.ToLower().StartsWith("hptext")).FirstOrDefault().text = hpBar.value + "/" + hpBar.maxValue;

        Slider expBar = bars.Where(b => b.name.ToLower().Equals("expbar")).FirstOrDefault();
        expBar.maxValue = ps.GetStat(Stat.MaxExp);
        expBar.value = ps.GetStat(Stat.Exp);
    }

    internal bool Buy(ShopItem shopItem)
    {
        if(gold >= shopItem.Price)
        {
            gold -= shopItem.Price;
            GivePlayer(shopItem.Item);
            return true;
        }
        return false;
    }

    internal bool StartTrapSequence(TrapStatBlock statBlock)
    {
        player.Evade(statBlock);

        PlayerStats ps = player.PlayerStatBlock;

        if (ps.GetStat(Stat.HP) <= 0)
        {
            return false;
        }

        ps.rewardExp(1);

        return true;
    }

    private void Awake()
    {
        player = new Player();
        UpdateUI();
    }
}
