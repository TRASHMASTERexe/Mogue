using System.Linq;  
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrapManager : ManagerBase
{

    public GameObject trapPrefab;
    public GameObject trapStorage;
    private readonly Dictionary<int, List<Trap>> difficultyToListTrap = new();

    public void InitTrap()
    {

        List<Trap> traps = difficultyToListTrap.GetValueOrDefault(CalcDifficultyNum());
        Trap trap = traps[Random.Range(0, traps.Count - 1)];

        GameObject go = Instantiate(trapPrefab, contentBoxTransform);
        TMP_Text[] tmps = go.GetComponentsInChildren<TMP_Text>();
        Image[] images = go.GetComponentsInChildren<Image>();
        TrapInfoStorage trapInfoStorage = go.GetComponent<TrapInfoStorage>();


        TrapStatBlock stats = trap.initTrap();
        tmps.Where(txt => txt.name.ToLower().StartsWith("dmgtext")).FirstOrDefault().text = stats.Dmg.ToString();
        tmps.Where(txt => txt.name.ToLower().StartsWith("spdtext")).FirstOrDefault().text = stats.Spd.ToString();
        tmps.Where(txt => txt.name.ToLower().StartsWith("goldtext")).FirstOrDefault().text = stats.Gold.ToString();
        trapInfoStorage.StatBlock = stats;

        Item item = itemManager.rollItem();
        images.Where(txt => txt.name.ToLower().StartsWith("rewardimage")).FirstOrDefault().sprite = item.Sprite;
        trapInfoStorage.Item = item;


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
}
