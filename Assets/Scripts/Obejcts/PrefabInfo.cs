using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabInfo
{

    public BoxType boxType;
    public int chance;
    public int priority;
    public int maxChance;

    public PrefabInfo(BoxType boxType, int weight, int priority, int maxChance)
    {
        this.boxType = boxType;
        this.chance = weight;
        this.priority = priority;
        this.maxChance = maxChance;
    }
}
