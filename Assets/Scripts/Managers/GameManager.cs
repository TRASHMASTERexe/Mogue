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
    public static TMP_Text killCounter;
    public static TMP_Text worldName;
    BoxPrefabManager boxPrefabManager;
    public EnemyManager enemyManager;
    public ItemManager itemManager;






    // Start is called before the first frame update
    //maybe add a shake animation and boom sound effect on box creation
    void Start()
    {
        boxPrefabManager = initPrefabManager();
        
        for (int i = 0; i < 5; i++)
        {
            addPrefab();
        }
    }

    private void addPrefab()
    {
        BoxType boxType = boxPrefabManager.getRandomPrefab();
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

    private BoxPrefabManager initPrefabManager()
    {
        List<PrefabInfo> prefabInfos = new List<PrefabInfo>();

        prefabInfos.Add(new PrefabInfo(BoxType.Merchant, 20, 3, 50));
        prefabInfos.Add(new PrefabInfo(BoxType.Trap, 20, 3, 50));
        prefabInfos.Add(new PrefabInfo(BoxType.Boss, 0, 1, 100));


        BoxPrefabManager bpm = new BoxPrefabManager(prefabInfos);

        return bpm;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
