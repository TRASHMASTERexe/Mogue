using System.Linq;  
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrapManager : MonoBehaviour
{

    public GameObject TrapPrefab;
    public GameObject TrapStorage;
    private Dictionary<int, List<Trap>> difficultyToListTrap = new();
    private int difficulty = 1;
    private int range = 1;

    public void InitTrap(Item Item, Transform t)
    {
        int floor = difficulty - range > 0? difficulty - range : 1;
        int ceiling = difficulty + range < 100? difficulty + range : 99;

        List<Trap> enemies = difficultyToListTrap.GetValueOrDefault(Random.Range(floor, ceiling));
        Trap trap = enemies[Random.Range(0, enemies.Count - 1)];
        
        GameObject go = Instantiate(TrapPrefab, t);

        //TrapStatBlock stats = trap.initTrap();
        //TMP_Text[] tmp = go.GetComponentsInChildren<TMP_Text>();
        //tmp.Where(txt => txt.name.ToLower().StartsWith("atk")).FirstOrDefault().text = stats.Atk.ToString();
        //tmp.Where(txt => txt.name.ToLower().StartsWith("def")).FirstOrDefault().text = stats.Def.ToString();
        //tmp.Where(txt => txt.name.ToLower().StartsWith("spd")).FirstOrDefault().text = stats.Spd.ToString();
        //tmp.Where(txt => txt.name.ToLower().StartsWith("hp")).FirstOrDefault().text = stats.Hp.ToString();
        //tmp.Where(txt => txt.name.ToLower().StartsWith("gold")).FirstOrDefault().text = stats.Gold.ToString();
        //go.GetComponent<TrapInfoStorage>().StatBlock = stats;

        //Image[] images = go.GetComponentsInChildren<Image>();
        //images.Where(txt => txt.name.ToLower().StartsWith("reward")).FirstOrDefault().sprite = Item.Sprite;
        //images.Where(txt => txt.name.ToLower().StartsWith("trapimage")).FirstOrDefault().sprite = trap.trapImage;




    }

    private void Awake()
    {
        List<Trap> enimies = TrapStorage.GetComponents<Trap>().ToList();

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
}
