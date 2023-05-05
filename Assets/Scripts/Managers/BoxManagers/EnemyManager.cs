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
        Enemy enemy = enemies[Random.Range(0, enemies.Count)];
        
        GameObject go = Instantiate(enemyPrefab, contentBoxTransform);
        TMP_Text[] tmps = go.GetComponentsInChildren<TMP_Text>();
        Image[] images = go.GetComponentsInChildren<Image>();
        EnemyInfoStorage enemyInfoStorage = go.GetComponent<EnemyInfoStorage>();
        enemyInfoStorage.parent = go;

        enemyInfoStorage.StatBlock = enemy.initEnemy();
        tmps.Where(txt => txt.name.ToLower().StartsWith("atktext")).FirstOrDefault().text = enemyInfoStorage.StatBlock.StatToValue[Stat.Atk].ToString();
        tmps.Where(txt => txt.name.ToLower().StartsWith("deftext")).FirstOrDefault().text = enemyInfoStorage.StatBlock.StatToValue[Stat.Def].ToString();
        tmps.Where(txt => txt.name.ToLower().StartsWith("spdtext")).FirstOrDefault().text = enemyInfoStorage.StatBlock.StatToValue[Stat.Spd].ToString();
        tmps.Where(txt => txt.name.ToLower().StartsWith("hptext")).FirstOrDefault().text = enemyInfoStorage.StatBlock.StatToValue[Stat.HP].ToString();

        enemyInfoStorage.Item = itemManager.rollItem();
        images.Where(txt => txt.name.ToLower().StartsWith("rewardimage")).FirstOrDefault().sprite = enemyInfoStorage.Item.Sprite;

        enemyInfoStorage.Gold = enemy.CalcGold();
        tmps.Where(txt => txt.name.ToLower().StartsWith("goldtext")).FirstOrDefault().text = enemyInfoStorage.Gold.ToString();

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
