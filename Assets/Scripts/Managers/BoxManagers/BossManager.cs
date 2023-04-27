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

    public void InitBoss()
    {
        List<Boss> enemies = difficultyToListBoss.GetValueOrDefault(CalcDifficultyNum());
        Boss boss = enemies[Random.Range(0, enemies.Count - 1)];
        
        GameObject go = Instantiate(bossPrefab, contentBoxTransform);
        TMP_Text[] tmps = go.GetComponentsInChildren<TMP_Text>();
        Image[] images = go.GetComponentsInChildren<Image>();
        BossInfoStorage bossInfoStorage = go.GetComponent<BossInfoStorage>();

        BossStatBlock stats = boss.initBoss();
        tmps.Where(txt => txt.name.ToLower().StartsWith("atktext")).FirstOrDefault().text = stats.Atk.ToString();
        tmps.Where(txt => txt.name.ToLower().StartsWith("deftext")).FirstOrDefault().text = stats.Def.ToString();
        tmps.Where(txt => txt.name.ToLower().StartsWith("spdtext")).FirstOrDefault().text = stats.Spd.ToString();
        tmps.Where(txt => txt.name.ToLower().StartsWith("hptext")).FirstOrDefault().text = stats.Hp.ToString();
        tmps.Where(txt => txt.name.ToLower().StartsWith("goldtext")).FirstOrDefault().text = stats.Gold.ToString();
        bossInfoStorage.StatBlock = stats;

        Item item = itemManager.rollItem();
        images.Where(txt => txt.name.ToLower().StartsWith("rewardimage")).FirstOrDefault().sprite = item.Sprite;
        bossInfoStorage.Item = item;

        images.Where(txt => txt.name.ToLower().StartsWith("bossimage")).FirstOrDefault().sprite = boss.bossImage;
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
