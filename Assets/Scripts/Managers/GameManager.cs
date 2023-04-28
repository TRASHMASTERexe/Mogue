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
    public PlayerManager playerManager;
    public static TMP_Text killCounter;
    public static TMP_Text worldName;
    private static GameManager gameManagerReference;


    public static GameManager GetManager()
    {
        return gameManagerReference;
    }

    private void AddPrefab()
    {
        BoxType boxType = boxChanceManager.getRandomPrefab();
        InitBox(boxType);
        
    }

    private void InitBox(BoxType boxType)
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

    public void InitCombat(BaseStatBlock statblock, Item prize)
    {
        if (playerManager.StartCombat(statblock))
        {
            playerManager.GivePlayer(prize);
            //update gold statblokc.gold()
            //update intenral kill count
            //determine if kill increases difficulty
            AddPrefab();
        }
        else
        {
            //gameOver
        }
    }

    #region unity awake
    //init game objects
    private void Awake()
    {
        if (gameManagerReference == null)
        { 
            gameManagerReference = this;
        }

        Transform transform = boxContainer.transform;
        ManagerBase.Init(transform, itemManager);
    }

    //init play
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            AddPrefab();
        }

        InitBox(BoxType.Boss);
    }
    #endregion
}
