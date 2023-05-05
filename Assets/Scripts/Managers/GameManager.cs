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

    public void AddBox()
    {
        BoxType boxType = boxChanceManager.getRandomPrefab();
        InitBox(boxType);
        
    }

    private void InitBox(BoxType boxType)
    {
        //keep list of gameobjects?
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

    public void InitCombatInteraction(AdversaryStatBlock statblock, Item prize, int gold)
    {
        if (playerManager.StartCombat(statblock))
        {
            playerManager.GivePlayer(prize, gold);

            AddBox();
        }
        else
        {
            //gameOver
        }
    }

    public void InitTrapInteraction(TrapStatBlock statblock, Item prize, int gold)
    {
        if (playerManager.StartTrapSequence(statblock))
        {
            playerManager.GivePlayer(prize, gold);

            AddBox();
        }
        else
        {
            //gameOver
        }
    }

    public bool InitShopInteraction(ShopItem shopItem)
    {
        if(playerManager.Buy(shopItem))
        {
            AddBox();
            return true;
        }
        return false;
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
        for (int i = 0; i < 8; i++)
        {
            AddBox();
        }
    }
    #endregion
}
