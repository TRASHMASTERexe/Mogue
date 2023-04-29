using System.Linq;  
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : ManagerBase
{

    public GameObject bossPrefab;
    public GameObject bossStorage;
    private readonly Dictionary<int, List<Boss>> difficultyToListBoss = new();

    //list of instantiated blocks
    private List<BossInfoStorage> bossInfoStorages = new();

    public void InitBoss()
    {
        List<Boss> enemies = difficultyToListBoss.GetValueOrDefault(CalcDifficultyNum());
        Boss boss = enemies[Random.Range(0, enemies.Count - 1)];
        
        GameObject go = Instantiate(bossPrefab, contentBoxTransform);
        TMP_Text[] tmps = go.GetComponentsInChildren<TMP_Text>();
        Image[] images = go.GetComponentsInChildren<Image>();
        BossInfoStorage bossInfoStorage = go.GetComponent<BossInfoStorage>();

        bossInfoStorage.StatBlock = boss.initBoss();
        tmps.Where(txt => txt.name.ToLower().StartsWith("atktext")).FirstOrDefault().text = bossInfoStorage.StatBlock.StatToValue[Stat.Atk].ToString();
        tmps.Where(txt => txt.name.ToLower().StartsWith("deftext")).FirstOrDefault().text = bossInfoStorage.StatBlock.StatToValue[Stat.Def].ToString();
        tmps.Where(txt => txt.name.ToLower().StartsWith("spdtext")).FirstOrDefault().text = bossInfoStorage.StatBlock.StatToValue[Stat.Spd].ToString();
        tmps.Where(txt => txt.name.ToLower().StartsWith("hptext")).FirstOrDefault().text = bossInfoStorage.StatBlock.StatToValue[Stat.HP].ToString();

        bossInfoStorage.Item = itemManager.rollItem();
        images.Where(txt => txt.name.ToLower().StartsWith("rewardimage")).FirstOrDefault().sprite = bossInfoStorage.Item.Sprite;

        bossInfoStorage.Gold = boss.Gold;
        tmps.Where(txt => txt.name.ToLower().StartsWith("goldtext")).FirstOrDefault().text = bossInfoStorage.Gold.ToString();

        images.Where(txt => txt.name.ToLower().StartsWith("bossimage")).FirstOrDefault().sprite = boss.bossImage;

        bossInfoStorages.Add(bossInfoStorage);
    }

    private void Awake()
    {
        List<Boss> enimies = bossStorage.GetComponents<Boss>().ToList();

        enimies.ForEach(boss =>
        {
            int difLevel = boss.DifficultyLevel;
            if(difficultyToListBoss.ContainsKey(difLevel))
            {
                difficultyToListBoss.GetValueOrDefault(difLevel).Add(boss);
            }
            else
            {
                difficultyToListBoss.Add(difLevel, new List<Boss>() {boss});
            }
        });
    }
}
