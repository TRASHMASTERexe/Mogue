using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    public Sprite playerImage;
    public PlayerStats PlayerStatBlock;
    private Dictionary<Item, int> itemsToCount;

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

        prize.Effect();
    }
}
