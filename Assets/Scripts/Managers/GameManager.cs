using System;
using System.Linq;  
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject boxContainer;
    public BoxChanceManager boxChanceManager;
    public EnemyManager enemyManager;
    public TrapManager trapManager;
    public ItemManager itemManager;
    public static TMP_Text killCounter;
    public static TMP_Text worldName;

    void Start()
    {
        Transform transform = boxContainer.transform;
        enemyManager.Init(transform, itemManager);
        trapManager.Init(transform, itemManager);

        for (int i = 0; i < 5; i++)
        {
            addPrefab();
        }
    }

    private void addPrefab()
    {
        BoxType boxType = boxChanceManager.getRandomPrefab();
        initBox(boxType);
        
    }

    private void initBox(BoxType boxType)
    {
        switch(boxType)
        {
            case BoxType.Enemy:
                enemyManager.InitEnemy();
                break;
            case BoxType.Trap:
                trapManager.InitTrap();
                break;
            case BoxType.Merchant:
                trapManager.InitTrap();
                break;
            case BoxType.Boss:
                break;
        }
    }
}
