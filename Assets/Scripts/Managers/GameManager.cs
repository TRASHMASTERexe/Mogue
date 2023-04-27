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
    public ItemManager itemManager;
    public static TMP_Text killCounter;
    public static TMP_Text worldName;






    // Start is called before the first frame update
    //maybe add a shake animation and boom sound effect on box creation
    void Start()
    {   
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
                Item item = itemManager.rollItem();
                Transform transform1 = boxContainer.transform;
                enemyManager.InitEnemy(item, transform1);
                break;
            case BoxType.Trap:
                break;
            case BoxType.Merchant:
                break;
            case BoxType.Boss:
                break;
        }
    }
}
