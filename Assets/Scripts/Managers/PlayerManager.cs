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
    private Player player;

    public bool StartCombat(BaseStatBlock statBlock)
    {
        if(statBlock is TrapStatBlock)
        {
            return false;
        }

        player.Fight(statBlock);

        if(player.curHP <= 0)
        {
            return false;
        }else if (player.curHP > player.maxHP)
        {
            player.curHP = player.maxHP;
        }

        if(player.curExp >= player.maxExp)
        {
            player.LevelUp();
        }



        return true;
    }

    private void Awake()
    {
        player = new Player();

    }

    internal void GivePlayer(Item prize)
    {
        player.GiveItem(prize);
    }
}
