using System.Linq;  
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{

    //public List<EnemyInfo> prefabs;
    public GameObject EnemyPrefab;
    public GameObject EnemyStorage;
    private Dictionary<int, List<Enemy>> difficultyToListPrefabs = new();
    private int difficulty = 1;
    private int range = 1;

    public void InitEnemy(Item Item, Transform t)
    {
        int floor = difficulty - range > 0? difficulty - range : 1;
        int ceiling = difficulty + range < 100? difficulty + range : 99;

        List<Enemy> enemies = difficultyToListPrefabs.GetValueOrDefault(Random.Range(floor, ceiling));
        Enemy enemy = enemies[Random.Range(0, enemies.Count - 1)];
        EnemyStatBlock stats = enemy.initEnemy();
        TMP_Text[] tmp = EnemyPrefab.GetComponentsInChildren<TMP_Text>();
        tmp.Where(txt => txt.name.ToLower().StartsWith("atk")).FirstOrDefault().text = stats.Atk.ToString();
        tmp.Where(txt => txt.name.ToLower().StartsWith("def")).FirstOrDefault().text = stats.Def.ToString();
        tmp.Where(txt => txt.name.ToLower().StartsWith("spd")).FirstOrDefault().text = stats.Spd.ToString();
        tmp.Where(txt => txt.name.ToLower().StartsWith("hp")).FirstOrDefault().text = stats.Hp.ToString();
        tmp.Where(txt => txt.name.ToLower().StartsWith("gold")).FirstOrDefault().text = stats.Gold.ToString();

        Image[] images = EnemyPrefab.GetComponentsInChildren<Image>();
        images.Where(txt => txt.name.ToLower().StartsWith("reward")).FirstOrDefault().sprite = Item.Sprite;

        Instantiate(EnemyPrefab, t).GetComponent<EnemyInfoStorage>().StatBlock = stats;

    }

    private void Start()
    {
        List<Enemy> enimies = EnemyStorage.GetComponents<Enemy>().ToList();

        enimies.ForEach(enemy =>
        {
            int difLevel = enemy.DifficultyLevel;
            if(difficultyToListPrefabs.ContainsKey(difLevel))
            {
                difficultyToListPrefabs.GetValueOrDefault(difLevel).Add(enemy);
            }
            else
            {
                difficultyToListPrefabs.Add(difLevel, new List<Enemy>() {enemy});
            }
        });
    }
}
