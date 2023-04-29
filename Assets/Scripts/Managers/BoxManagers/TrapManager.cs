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

        trapInfoStorage.StatBlock = trap.initTrap();
        tmps.Where(txt => txt.name.ToLower().StartsWith("dmgtext")).FirstOrDefault().text = trapInfoStorage.StatBlock.StatToValue[Stat.Atk].ToString();
        tmps.Where(txt => txt.name.ToLower().StartsWith("spdtext")).FirstOrDefault().text = trapInfoStorage.StatBlock.StatToValue[Stat.Spd].ToString();

        trapInfoStorage.Gold = trap.CalcGold();
        tmps.Where(txt => txt.name.ToLower().StartsWith("goldtext")).FirstOrDefault().text = trapInfoStorage.Gold.ToString();

        trapInfoStorage.Item = itemManager.rollItem();
        images.Where(txt => txt.name.ToLower().StartsWith("rewardimage")).FirstOrDefault().sprite = trapInfoStorage.Item.Sprite;

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
