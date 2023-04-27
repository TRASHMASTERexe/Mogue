using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerBase : MonoBehaviour
{
    protected static Transform contentBoxTransform;
    protected static ItemManager itemManager;
    protected static int difficulty = 1;
    protected static int range = 1;

    public static void Init(Transform t, ItemManager im)
    {
        contentBoxTransform = t;
        itemManager = im;
    }

    public static void IncreaseDifficulty(int levels)
    {
        difficulty += levels;
        if (difficulty > 99) difficulty = 99;
    }

    public static void ReduceDifficulty(int levels)
    {
        difficulty -= levels;
        if (difficulty < 1) difficulty = 1;
    }

    private int CalcFloor()
    {
        int floor = difficulty - range;
        if (floor < 1) floor = 1;
        return floor;
    }

    private int CalcCeiling()
    {
        int ceiling = difficulty + range;
        if (ceiling > 99) ceiling = 99;
        return ceiling;
    }

    protected int CalcDifficultyNum()
    {
        return Random.Range(CalcFloor(), CalcCeiling());
    }

}
