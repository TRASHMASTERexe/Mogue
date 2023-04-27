using System.Linq;  
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrapManager : MonoBehaviour
{

    public GameObject trapPrefab;
    public GameObject trapStorage;
    private readonly Dictionary<int, List<Trap>> difficultyToListTrap = new();
    private readonly int difficulty = 1;
    private readonly int range = 1;
    private Transform t;
    private ItemManager itemManager;

    public void InitTrap()
    {
        Item item = itemManager.rollItem();
        int floor = difficulty - range > 0? difficulty - range : 1;
        int ceiling = difficulty + range < 100? difficulty + range : 99;

        List<Trap> enemies = difficultyToListTrap.GetValueOrDefault(Random.Range(floor, ceiling));
        Trap trap = enemies[Random.Range(0, enemies.Count - 1)];
        
        GameObject go = Instantiate(trapPrefab, t);

        TrapStatBlock stats = trap.initTrap();
        TMP_Text[] tmp = go.GetComponentsInChildren<TMP_Text>();
        tmp.Where(txt => txt.name.ToLower().StartsWith("dmg")).FirstOrDefault().text = stats.Dmg.ToString();
        tmp.Where(txt => txt.name.ToLower().StartsWith("spd")).FirstOrDefault().text = stats.Spd.ToString();
        tmp.Where(txt => txt.name.ToLower().StartsWith("gold")).FirstOrDefault().text = stats.Gold.ToString();
        go.GetComponent<TrapInfoStorage>().StatBlock = stats;

        Image[] images = go.GetComponentsInChildren<Image>();
        images.Where(txt => txt.name.ToLower().StartsWith("reward")).FirstOrDefault().sprite = item.Sprite;
        images.Where(txt => txt.name.ToLower().StartsWith("trapimage")).FirstOrDefault().sprite = trap.TrapImage;

    }

    private void Awake()
    {
        List<Trap> enimies = trapStorage.GetComponents<Trap>().ToList();

        enimies.ForEach(trap =>
        {
            int difLevel = trap.DifficultyLevel;
            if(difficultyToListTrap.ContainsKey(difLevel))
            {
                difficultyToListTrap.GetValueOrDefault(difLevel).Add(trap);
            }
            else
            {
                difficultyToListTrap.Add(difLevel, new List<Trap>() {trap});
            }
        });
    }

    //Maybe could put this into interface/abstract class? want a way to init all at same time instead of each individually
    public void Init(Transform t, ItemManager im)
    {
        this.t = t;
        this.itemManager = im;
    }
}
