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
    public MerchantManager merchantManager;
    public BossManager bossManager;
    public ItemManager itemManager;
    public static TMP_Text killCounter;
    public static TMP_Text worldName;

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
                merchantManager.InitMerchant();
                break;
            case BoxType.Boss:
                bossManager.InitBoss();
                break;
        }
    }

    //init game objects
    private void Awake()
    {
        Transform transform = boxContainer.transform;
        ManagerBase.Init(transform, itemManager);
    }

    //init play
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            addPrefab();
        }

        initBox(BoxType.Boss);
    }
}
