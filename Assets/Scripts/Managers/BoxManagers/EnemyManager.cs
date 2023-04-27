using System.Linq;  
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : ManagerBase
{

    public GameObject enemyPrefab;
    public GameObject enemyStorage;
    private readonly Dictionary<int, List<Enemy>> difficultyToListEnemy = new();

    public void InitEnemy()
    {
        List<Enemy> enemies = difficultyToListEnemy.GetValueOrDefault(CalcDifficultyNum());
        Enemy enemy = enemies[Random.Range(0, enemies.Count - 1)];
        
        GameObject go = Instantiate(enemyPrefab, contentBoxTransform);
        TMP_Text[] tmps = go.GetComponentsInChildren<TMP_Text>();
        Image[] images = go.GetComponentsInChildren<Image>();
        EnemyInfoStorage enemyInfoStorage = go.GetComponent<EnemyInfoStorage>();

        EnemyStatBlock stats = enemy.initEnemy();
        tmps.Where(txt => txt.name.ToLower().StartsWith("atktext")).FirstOrDefault().text = stats.Atk.ToString();
        tmps.Where(txt => txt.name.ToLower().StartsWith("deftext")).FirstOrDefault().text = stats.Def.ToString();
        tmps.Where(txt => txt.name.ToLower().StartsWith("spdtext")).FirstOrDefault().text = stats.Spd.ToString();
        tmps.Where(txt => txt.name.ToLower().StartsWith("hptext")).FirstOrDefault().text = stats.Hp.ToString();
        tmps.Where(txt => txt.name.ToLower().StartsWith("goldtext")).FirstOrDefault().text = stats.Gold.ToString();
        enemyInfoStorage.StatBlock = stats;

        Item item = itemManager.rollItem();
        images.Where(txt => txt.name.ToLower().StartsWith("rewardimage")).FirstOrDefault().sprite = item.Sprite;
        enemyInfoStorage.Item = item;

        images.Where(txt => txt.name.ToLower().StartsWith("enemyimage")).FirstOrDefault().sprite = enemy.enemyImage;
    }

    private void Awake()
    {
        List<Enemy> enimies = enemyStorage.GetComponents<Enemy>().ToList();

        enimies.ForEach(enemy =>
        {
            int difLevel = enemy.DifficultyLevel;
            if(difficultyToListEnemy.ContainsKey(difLevel))
            {
                difficultyToListEnemy.GetValueOrDefault(difLevel).Add(enemy);
            }
            else
            {
                difficultyToListEnemy.Add(difLevel, new List<Enemy>() {enemy});
            }
        });
    }
}
