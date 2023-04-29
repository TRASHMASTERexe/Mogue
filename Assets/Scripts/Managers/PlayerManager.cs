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

        if (ps.GetCalculatedStat(Stat.HP) <= 0)
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

    internal void GivePlayer(Item prize, int gold)
    {
        gold += gold;
        player.GiveItem(prize);
        UpdateUI();
    }

    private void UpdateUI()
    {
        List<TMP_Text> texts = statBar.GetComponentsInChildren<TMP_Text>().ToList();
        texts.AddRange(headerBar.GetComponentsInChildren<TMP_Text>());

        PlayerStats ps = player.PlayerStatBlock;

        texts.Where(t => t.name.ToLower().StartsWith("atktext")).FirstOrDefault().text = ps.GetCalculatedStat(Stat.Atk).ToString();
        texts.Where(t => t.name.ToLower().StartsWith("deftext")).FirstOrDefault().text = ps.GetCalculatedStat(Stat.Def).ToString();
        texts.Where(t => t.name.ToLower().StartsWith("spdtext")).FirstOrDefault().text = ps.GetCalculatedStat(Stat.Spd).ToString();
        texts.Where(t => t.name.ToLower().StartsWith("goldtext")).FirstOrDefault().text = gold.ToString();
        texts.Where(t => t.name.ToLower().StartsWith("difficultytext")).FirstOrDefault().text = difficulty.ToString();

        Slider hpbar = statBar.GetComponentInChildren<Slider>();
        hpbar.maxValue = ps.GetCalculatedStat(Stat.MaxHP);
        hpbar.value = ps.GetCalculatedStat(Stat.HP);
        texts.Where(t => t.name.ToLower().StartsWith("hptext")).FirstOrDefault().text = hpbar.value + "/" + hpbar.maxValue;
    }

    private void Awake()
    {
        player = new Player();
        UpdateUI();
    }
}
